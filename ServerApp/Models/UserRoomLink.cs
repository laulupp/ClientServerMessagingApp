using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Models;

[Table("user_room_links", Schema = "server_schema")]
class UserRoomLink
{
    public int Id { get; set; }

    public string? Username { get; set; }

    [ForeignKey("Room")]
    public int? RoomId { get; set; }

    public virtual Room? Room { get; set; }
}
