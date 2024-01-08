using Microsoft.EntityFrameworkCore;
using ServerApp.Context;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Repository;

class UserRoomLinkRepository : GenericRepository<UserRoomLink>
{
    public UserRoomLinkRepository(AppDbContext context) : base(context) { }
    public async Task<List<Room>?> GetAllRoomsByUsernameAsync(string username)
    {
        return await _context.Set<UserRoomLink>()
                             .Include(url => url.Room)
                             .Where(r => r.Username == username)
                             .Select(t => t.Room)
                             .ToListAsync();
    }
}

