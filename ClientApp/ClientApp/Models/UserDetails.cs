using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models;

static class UserDetails
{
    public static string Username = "";
    public static string FirstName = "";
    public static string LastName = "";
    public static string Token = "";
    public static string ConnectedRoomCode = "";
    public static int? Level = 0;
    public static int? CurrentMessageId = 0;

    public static string GetSenderDisplayName()
    {
        return FirstName + " " + LastName + " (" + Username + ")";
    }

    public static void SetUserDetails(AuthResponse response)
    {
        Token = response.Token!;
        Username = response.Username!;
        FirstName = response.FirstName!;
        LastName = response.LastName!;
        Level = response.Level;
    }
}
