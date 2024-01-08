using AuthService.Persistence.Models;
using AuthService.Services.Interfaces;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using ServerApp.Models;

namespace AuthService.Services;


public class TokenService : ITokenService
{
    private readonly RSA _publicKey;

    public TokenService(IConfiguration configuration)
    {
        string publicKeyPath = configuration["TokenSettings:PublicKeyPath"];
        _publicKey = LoadPublicKey(publicKeyPath);
    }

    private static RSA LoadPublicKey(string path)
    {
        string publicKeyPem = File.ReadAllText(path);

        RSA rsa = RSA.Create();
        rsa.ImportFromPem(publicKeyPem.ToCharArray());
        return rsa;
    }

    public string GenerateEncryptedToken(User user) 
    {
        var tokenData = new TokenContents
        {
            Level = user.Level,
            Username = user.Username!
        };

        string jsonToken = JsonSerializer.Serialize(tokenData);
        byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(jsonToken);

        byte[] encryptedBytes = _publicKey.Encrypt(bytesToEncrypt, RSAEncryptionPadding.OaepSHA256);
        return Convert.ToBase64String(encryptedBytes);
    }
}