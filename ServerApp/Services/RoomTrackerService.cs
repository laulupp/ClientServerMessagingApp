using ServerApp.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ServerApp.Services;
static class RoomTrackerService
{
    private static readonly ConcurrentDictionary<string, HashSet<string>> _roomUserMap = new ConcurrentDictionary<string, HashSet<string>>();

    public static bool AddUserToRoom(string username, Room room)
    {
        var usersInRoom = _roomUserMap.GetOrAdd(room.Code, new HashSet<string>());
        return usersInRoom.Add(username);
    }

    public static bool RemoveUserFromRoom(string username)
    {
        var userRoom = GetRoomFromUser(username);

        if (userRoom != null && _roomUserMap.TryGetValue(userRoom.Code, out var usersInRoom))
        {
            bool removed = usersInRoom.Remove(username);
            if (usersInRoom.Count == 0)
            {
                _roomUserMap.TryRemove(userRoom.Code, out _);
            }
            return removed;
        }

        return false;
    }

    public static Room? GetRoomFromUser(string username)
    {
        foreach (var entry in _roomUserMap)
        {
            if (entry.Value.Contains(username))
            {
                return new Room { Code = entry.Key };
            }
        }

        return null;
    }

    public static HashSet<string> GetUsersInRoom(Room room)
    {
        if (_roomUserMap.TryGetValue(room.Code, out var usersInRoom))
        {
            return usersInRoom;
        }
        return new HashSet<string>();
    }

    public static bool IsUserInRoom(string username, Room room)
    {
        if (_roomUserMap.TryGetValue(room.Code, out var usersInRoom))
        {
            return usersInRoom.Contains(username);
        }
        return false;
    }
}
