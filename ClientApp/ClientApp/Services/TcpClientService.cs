using ClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services;

static class TcpClientProvider
{
    public static TcpClientService? Client { get; set; }

    public static void CreateInstance(string server, int port)
    {
        Client = new TcpClientService(server, port);
    }
}

class TcpClientService
{
    public event Action<ResponseMessage> MessageReceived;
    private TcpClient? client;
    private NetworkStream stream;
    private readonly string serverIp;
    private readonly int serverPort;
    private Thread? receiveThread;
    private volatile bool keepReceiving = true;

    public TcpClientService(string ip, int port)
    {
        serverIp = ip;
        serverPort = port;
    }

    public void Connect()
    {
        try
        {
            client = new TcpClient(serverIp, serverPort);
            stream = client.GetStream();

            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.Start();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Send(ActionMessage message)
    {
        string jsonMessage = JsonConvert.SerializeObject(message);
        byte[] data = Encoding.UTF8.GetBytes(jsonMessage + "\n");
        stream!.Write(data, 0, data.Length);
    }

    private void Receive()
    {
        while (keepReceiving)
        {
            try
            {
                if (stream.DataAvailable)
                {
                    using (var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true))
                    {
                        string? responseJson = reader.ReadLine();
                        if (!string.IsNullOrEmpty(responseJson))
                        {
                            var response = JsonConvert.DeserializeObject<ResponseMessage>(responseJson);
                            MessageReceived?.Invoke(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Receive error: {ex.Message}");
                keepReceiving = false;
            }
        }
    }

    public void CloseConnection()
    {
        keepReceiving = false;
        stream!.Close();
        client!.Close();
    }
}