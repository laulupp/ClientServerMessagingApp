using Microsoft.EntityFrameworkCore;
using ServerApp.Context;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Repository;

class MessageRepository : GenericRepository<ChatMessage>
{
    public MessageRepository(AppDbContext context) : base(context) { }

    public async Task<List<ChatMessage>?> GetByRoomAsync(string roomCode)
    {
        var room = await _context.Set<ChatMessage>().Include(r => r.Room).Where(msg => msg.Room != null && msg.Room.Code == roomCode).ToListAsync();
        return room;
    }
}

