using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Models;

class ResponseMessage
{
    public int? Status { get; set; }
    public string? Error { get; set; }
    public string? Confirmation { get; set; }
    public List<Room>? Rooms { get; set; }
    public List<ChatMessage>? Messages { get; set; }
    public string? RoomCode { get; set; }
    public bool? ReceivedMessage { get; set; }
    public ChatMessage? Message { get; set; }
    public int? MessageId { get; set; }

}
