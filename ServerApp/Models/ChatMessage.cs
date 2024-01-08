using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Models;

[Table("messages", Schema = "server_schema")]
class ChatMessage
{
    [Key]
    public int Id { get; set; }

    public string? Message { get; set; }

    public string? Username { get; set; }

    public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;

    [ForeignKey("Room")]
    public int? RoomId { get; set; }

    public virtual Room? Room { get; set; }
}
