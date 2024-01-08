using Microsoft.EntityFrameworkCore;
using ServerApp.Context;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Repository;

class RoomRepository : GenericRepository<Room>
{
    public RoomRepository(AppDbContext context) : base(context) { }

    public async Task<Room?> GetByCodeAsync(string roomCode)
    {
        var room = await _context.Set<Room>().Where(r => r.Code == roomCode).FirstOrDefaultAsync();
        return room;
    }
}
