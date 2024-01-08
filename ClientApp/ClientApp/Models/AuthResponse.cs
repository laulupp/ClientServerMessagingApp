using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models;

public class AuthResponse
{
    public string? Token { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Level { get; set; }
    public string? Error { get; set; }
    public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

    public List<string> GetAllErrors()
    {
        List<string> allErrors = new List<string>();

        if (Errors.ContainsKey("loginDTO") && Errors["loginDTO"].Contains("The loginDTO field is required."))
        {
            return new List<string> { "Request is invalid." };
        }

        if (!string.IsNullOrEmpty(Error))
        {
            allErrors.Add(Error);
        }

        foreach (var errorList in Errors.Values)
        {
            allErrors.AddRange(errorList);
        }

        return allErrors;
    }
}