using ServerApp.Models;
using System.Net.Sockets;

namespace ServerApp.Services;
class MessageHandlerService
{
    private readonly DataService _dataService;
    private readonly TcpServer _server;
    private readonly TokenService _tokenService;
    private bool IsAdmin = false;
    public MessageHandlerService(DataService dataService, TcpServer server, TokenService tokenService)
    {
        _dataService = dataService;
        _server = server;
        _tokenService = tokenService;
    }

    public async Task<ResponseMessage?> HandleMessageAsync(ActionMessage message, TcpClient client)
    {
        if (message == null || message.Username == null || message.Token == null)
        {
            return null;
        }

        if (!_tokenService.VerifyUsername(message.Username, message.Token))
        {
            return null;
        }

        IsAdmin = _tokenService.IsAdmin(message.Token);

        switch (message.Action)
        {
            case Models.Action.SendMessage: return await HandleSendMessageAsync(message, client);
            case Models.Action.GetRooms: return await HandleGetRooms(message);
            case Models.Action.CreateRoom: return await HandleCreateRoom(message);
            case Models.Action.EnterRoom: return await HandleEnterRoom(message, client);
            case Models.Action.JoinRoom: return await HandleJoinRoom(message);
            default:
                return null;
        }
    }

    public async Task<ResponseMessage?> HandleSendMessageAsync(ActionMessage message, TcpClient client)
    {
        if (message.RoomCode == null || message.Username == null || message.Message == null || message.MessageId == null)
        {
            return null;
        }

        //Check if user belongs to the room or is admin
        if (!IsAdmin)
        {
            var rooms = await _dataService.GetAllRoomsByUsernameAsync(message.Username);
            if (rooms == null || !rooms.Select(r => r.Code).Contains(message.RoomCode))
            {
                return null;
            }
        }

        await _dataService.AddMessageToRoomAsync(message.Message, message.Username, message.RoomCode);

        _server.BroadcastMessage(new ResponseMessage { ReceivedMessage = true, Message = new ChatMessage { Message = message.Message, Username = message.Username } }, client);

        return new ResponseMessage
        {
            Status = 200,
            MessageId = message.MessageId
        };
    }

    public async Task<ResponseMessage?> HandleGetRooms(ActionMessage message)
    {
        if (IsAdmin)
        {
            return new ResponseMessage
            {
                Status = 200,
                Rooms = await _dataService.GetAllRoomsAsync()
            };
        }

        return new ResponseMessage
        {
            Status = 200,
            Rooms = await _dataService.GetAllRoomsByUsernameAsync(message.Username!)
        };
    }

    public async Task<ResponseMessage?> HandleCreateRoom(ActionMessage message)
    {
        if (message.RoomName == null)
        {
            return new ResponseMessage
            {
                Status = 400,
            };
        }

        string roomCode;
        do
        {
            roomCode = RoomCodeGenerator.GenerateRoomCode();
        } while (await _dataService.GetRoomByCodeAsync(roomCode) != null);

        await _dataService.CreateRoomAsync(new Room()
        {
            Code = roomCode,
            Name = message.RoomName
        });

        return new ResponseMessage
        {
            Status = 200,
            Rooms = new List<Room> { (await _dataService.GetRoomByCodeAsync(roomCode))! },
            Confirmation = "A new room was created. Room code : " + roomCode
        };
    }

    public async Task<ResponseMessage?> HandleEnterRoom(ActionMessage message, TcpClient client)
    {
        if (message.RoomCode == null || message.Username == null)
        {
            return null;
        }

        _server.ChangeClientRoom(client, message.Username, message.RoomCode);

        return new ResponseMessage
        {
            Status = 200,
            RoomCode = message.RoomCode,
            Messages = await _dataService.GetMessagesFromRoomAsync(message.RoomCode)
        };
    }

    public async Task<ResponseMessage?> HandleJoinRoom(ActionMessage message)
    {
        if (message.Username == null || message.RoomCode == null)
        {
            return null;
        }

        var room = await _dataService.GetRoomByCodeAsync(message.RoomCode);

        if (room == null)
        {
            return new ResponseMessage
            {
                Status = 400,
                Error = "Room not found"
            };
        }

        if (await _dataService.IsLinkBetween(message.Username, message.RoomCode))
        {
            return new ResponseMessage
            {
                Status = 400,
                Error = "You are already in that room"
            };
        }

        await _dataService.AddUserToRoomAsync(message.Username, message.RoomCode);

        return new ResponseMessage
        {
            Status = 200,
            Rooms = new List<Room> { room }
        };
    }
}
