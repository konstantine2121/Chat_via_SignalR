using System;

namespace Chat.AvaloniaClient.ViewModels.Login;

public struct UsernameValidationResult
{
    public UsernameValidationResult(string username, bool result, string? errorMessage)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username), "Username cannot be null");
        Result = result;
        ErrorMessage = errorMessage;
    }

    public string Username { get; }

    public bool Result { get; }

    public string? ErrorMessage { get; }
}