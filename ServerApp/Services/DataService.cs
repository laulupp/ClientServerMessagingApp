using ServerApp.Models;
using ServerApp.Repository;
using ServerApp.Repository.Interfaces;

namespace ServerApp.Services;

class DataService
{
    private readonly RoomRepository _roomRepository;
    private readonly UserRoomLinkRepository _userRoomLinkRepository;
    private readonly MessageRepository _messageRepository;

    public DataService(RoomRepository roomRepository,
                       UserRoomLinkRepository userRoomLinkRepository,
                       MessageRepository messageRepository)
    {
        _roomRepository = roomRepository;
        _userRoomLinkRepository = userRoomLinkRepository;
        _messageRepository = messageRepository;
    }

    #region Room Methods
    public async Task<List<Room>?> GetAllRoomsAsync()
    {
        return (List<Room>?)await _roomRepository.GetAllAsync();
    }

    public async Task<Room?> GetRoomByIdAsync(int id)
    {
        return await _roomRepository.GetByIdAsync(id);
    }

    public async Task<Room?> GetRoomByCodeAsync(string roomCode)
    {
        return await _roomRepository.GetByCodeAsync(roomCode);
    }

    public async Task CreateRoomAsync(Room room)
    {
        await _roomRepository.AddAsync(room);
    }

    public async Task UpdateRoomAsync(Room room)
    {
        await _roomRepository.UpdateAsync(room);
    }

    public async Task DeleteRoomAsync(int id)
    {
        await _roomRepository.DeleteAsync(id);
    }
    #endregion

    #region UserRoomLink Methods
    public async Task<bool> IsLinkBetween(string username, string roomCode)
    {
        var links = await _userRoomLinkRepository.GetAllRoomsByUsernameAsync(username);

        if(links == null)
        {
            return false;
        }

        return links.Where(l => l.Code == roomCode).Count() == 1;
    }
    public async Task AddUserToRoomAsync(string username, string roomCode)
    {
        var room = await _roomRepository.GetByCodeAsync(roomCode);

        if(room == null)
        {
            return;
        }

        var userRoomLink = new UserRoomLink
        {
            Username = username,
            RoomId = room.Id
        };

        await _userRoomLinkRepository.AddAsync(userRoomLink);
    }

    public async Task<List<Room>?> GetAllRoomsByUsernameAsync(string username)
    {
        return await _userRoomLinkRepository.GetAllRoomsByUsernameAsync(username);
    }
    #endregion

    #region Message Methods
    public async Task AddMessageToRoomAsync(string content, string username, string roomCode)
    {
        var room = await _roomRepository.GetByCodeAsync(roomCode);
        if(room == null)
        {
            return;
        }

        var message = new ChatMessage
        {
            Message = content,
            Username = username,
            RoomId = room.Id,
            CreatedTime = DateTime.UtcNow
        };

        await _messageRepository.AddAsync(message);
    }

    public async Task<List<ChatMessage>?> GetMessagesFromRoomAsync(string roomCode)
    {
        var messages = await _messageRepository.GetByRoomAsync(roomCode);
        return messages.OrderBy(s => s.CreatedTime).ToList();
    }
    #endregion
}
