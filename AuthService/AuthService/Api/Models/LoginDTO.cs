using System.ComponentModel.DataAnnotations;

namespace AuthService.Api.Models;

public class LoginDTO
{
    [Required]
    [MaxLength(50)]
    public string? Username { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Password { get; set; }
}
