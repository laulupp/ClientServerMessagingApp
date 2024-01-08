using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models;

enum Action
{
    SendMessage = 0,
    GetRooms = 1,
    EnterRoom = 2,  //Connect to a room
    JoinRoom = 3,   //Add a new room
    CreateRoom = 4
}
