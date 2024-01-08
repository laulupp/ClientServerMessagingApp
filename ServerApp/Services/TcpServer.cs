using Newtonsoft.Json;
using ServerApp.Models;
using ServerApp.Services;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using ServerApp.Context;
using ServerApp.Repository;

class TcpServer
{
    private TcpListener tcpListener;
    private Thread listenThread;
    private ConcurrentDictionary<TcpClient, string> connectedClients = new ConcurrentDictionary<TcpClient, string>();
    private readonly IServiceProvider _serviceProvider;

    public TcpServer(int port, IServiceProvider serviceProvider)
    {
        tcpListener = new TcpListener(IPAddress.Any, port);
        listenThread = new Thread(new ThreadStart(ListenForClients));
        _serviceProvider = serviceProvider;
    }

    public void Start()
    {
        listenThread.Start();
        Console.WriteLine("Server started...");
    }

    private void ListenForClients()
    {
        tcpListener.Start();

        while (true)
        {
            TcpClient client = tcpListener.AcceptTcpClient();
            connectedClients.TryAdd(client, null);  // Initialize with no associated username

            Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
            clientThread.Start(client);
        }
    }

    private async void HandleClientComm(object client)
    {
        TcpClient tcpClient = (TcpClient)client;
        NetworkStream clientStream = tcpClient.GetStream();

        try
        {
            while (true)
            {
                if (clientStream.DataAvailable)
                {
                    using (var reader = new StreamReader(clientStream, leaveOpen: true))
                    {
                        string? message = await reader.ReadLineAsync();
                        if (string.IsNullOrEmpty(message))
                            continue;

                        var actionMessage = JsonConvert.DeserializeObject<ActionMessage>(message);
                        if (actionMessage == null)
                            continue;

                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var dataService = scope.ServiceProvider.GetRequiredService<DataService>();
                            var tokenService = scope.ServiceProvider.GetRequiredService<TokenService>();
                            var messageHandlerService = new MessageHandlerService(dataService, this, tokenService);

                            var response = await messageHandlerService.HandleMessageAsync(actionMessage, tcpClient);
                            string jsonResponse = JsonConvert.SerializeObject(response);
                            byte[] buffer = Encoding.UTF8.GetBytes(jsonResponse + "\n");
                            await clientStream.WriteAsync(buffer, 0, buffer.Length);
                            await clientStream.FlushAsync();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            LeaveRoom(tcpClient);
            tcpClient.Close();
        }
    }

    private void LeaveRoom(TcpClient client)
    {
        if (connectedClients.TryRemove(client, out string username))
        {
            if (!string.IsNullOrEmpty(username))
            {
                RoomTrackerService.RemoveUserFromRoom(username);
            }
        }
    }

    public void ChangeClientRoom(TcpClient client, string username, string newRoomCode)
    {
        if (connectedClients.TryGetValue(client, out _))
        {
            RoomTrackerService.RemoveUserFromRoom(username);
            RoomTrackerService.AddUserToRoom(username, new Room { Code = newRoomCode });
            var sfdfdsx = RoomTrackerService.GetUsersInRoom(new Room { Code = newRoomCode });
            connectedClients[client] = username;
        }
    }

    public void BroadcastMessage(ResponseMessage message, TcpClient originClient)
    {
        var originUsername = connectedClients[originClient];
        var userRoom = RoomTrackerService.GetRoomFromUser(originUsername);
        if(userRoom == null)
        {
            return;
        }

        byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message) + "\n"); 

        HashSet<string> usersInRoom = RoomTrackerService.GetUsersInRoom(userRoom);

        foreach (var username in usersInRoom)
        {
            if (username != originUsername)
            {
                var client = connectedClients.FirstOrDefault(c => c.Value == username).Key;
                if (client != null)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error broadcasting message to {username}: {ex.Message}");
                    }
                }
            }
        }
    }
}
