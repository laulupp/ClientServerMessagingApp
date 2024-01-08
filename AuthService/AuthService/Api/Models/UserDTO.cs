using System.ComponentModel.DataAnnotations;

namespace AuthService.Api.Models;

public class UserDTO
{
    [Required]
    [MaxLength(50)]
    public string? Username { get; set; }

    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Password { get; set; }
}
