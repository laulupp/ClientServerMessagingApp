namespace AuthService.Api.Models;

public class LoginResponseDTO
{
    public string? Token { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Level { get; set; } //Not verified
}
