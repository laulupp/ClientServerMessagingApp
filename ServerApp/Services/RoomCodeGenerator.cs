using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Services;

public class RoomCodeGenerator
{
    private static Random random = new Random();

    public static string GenerateRoomCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 5)
                                    .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}