using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models;

class ActionMessage
{
    public string? Username { get; set; }
    public string? Token { get; set; }
    public Action? Action { get; set; }
    public string? RoomCode { get; set; }
    public string? RoomName { get; set; }
    public string? Message { get; set; }
    public int? MessageId { get; set; }
}
