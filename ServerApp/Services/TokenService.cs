using Microsoft.Extensions.Configuration;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerApp.Services;

public class TokenService
{
    private readonly RSA _privateKey;

    public TokenService(IConfiguration configuration)
    {
        string publicKeyPath = configuration["TokenSettings:PrivateKeyPath"];
        _privateKey = LoadPrivateKey(publicKeyPath);
    }

    private static RSA LoadPrivateKey(string path)
    {
        string publicKeyPem = File.ReadAllText(path);

        RSA rsa = RSA.Create();
        rsa.ImportFromPem(publicKeyPem.ToCharArray());
        return rsa;
    }

    public bool VerifyUsername(string username, string token)
    {
        byte[] decryptedBytes = _privateKey.Decrypt(Convert.FromBase64String(token), RSAEncryptionPadding.OaepSHA256);

        var contents = JsonSerializer.Deserialize<TokenContents>(Encoding.UTF8.GetString(decryptedBytes));

        if (contents == null)
        {
            return false;
        }

        return contents.Username == username;
    }

    public bool IsAdmin(string token)
    {
        byte[] decryptedBytes = _privateKey.Decrypt(Convert.FromBase64String(token), RSAEncryptionPadding.OaepSHA256);

        var contents = JsonSerializer.Deserialize<TokenContents>(Encoding.UTF8.GetString(decryptedBytes));

        if (contents == null)
        {
            return false;
        }

        return contents.Level == 1;
    }
}