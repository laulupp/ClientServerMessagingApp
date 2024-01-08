using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Persistence.Models;

[Table("users", Schema = "auth_schema")]
public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? HashedPassword { get; set; }
    public int Level { get; set; }
    public DateTime DateCreated { get; set; }

}
