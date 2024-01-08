using AuthService.Persistence.Models;

namespace AuthService.Services.Interfaces;

public interface ITokenService
{
    string GenerateEncryptedToken(User user);
}
