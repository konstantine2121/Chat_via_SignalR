using System.Collections.Generic;
using System.Linq;

namespace Chat.AvaloniaClient.ViewModels.Login;

public class UsernameValidator
{
    public const int MinLength = 4;
    public const int MaxLength = 16;

    private static readonly HashSet<char> SupportedCharacters;

    public static bool IsSupported(char ch) 
        => SupportedCharacters.Contains(ch);
    
    static UsernameValidator()
    {
        SupportedCharacters = GetSupportedChars().ToHashSet();
        
        IList<char> GetSupportedChars()
        {
            List<char> chars = new List<char>();

            for (int i = 'A'; i <= 'Z'; i++)
            {
                chars.Add((char)i);
            }
            
            for (int i = 'a'; i <= 'z'; i++)
            {
                chars.Add((char)i);
            }
            
            for (int i = '0'; i <= '9'; i++)
            {
                chars.Add((char)i);
            }
            
            chars.Add('_');
            chars.Add('.');
            chars.Add('!');
            chars.Add('#');
            chars.Add('(');
            chars.Add(')');
            chars.Add('<');
            chars.Add('>');
            
            return chars;
        }
    }
            
    public static UsernameValidationResult Validate(string username)
    {
        bool isValid = true;
        string? errorMessage = null;
        
        if (string.IsNullOrWhiteSpace(username))
        {
            isValid = false;
            errorMessage = "Username cannot be empty";
        }
        else if (username.Length < MinLength)
        {
                isValid = false;
                errorMessage = $"Username lenght must be greater than {MinLength} characters";
        }
        else if (username.Length > MaxLength)
        {
            isValid = false;
            errorMessage = $"Username lenght must be less than {MaxLength} characters";
        }
        else if (username.Contains(' '))
        {
            isValid = false;
            errorMessage = $"Username can't contain 'space' characters";
        }
        else if (username.ToCharArray().Any(ch => !IsSupported(ch)))
        {
            isValid = false;
            
            var unsupportedCharacters = username.ToCharArray().Where(ch => !IsSupported(ch));
            var unsupportedCharactersString = "'" + string.Join("', '", unsupportedCharacters) + "'";
            errorMessage = $"Username can't contain unsupported characters (like these: {unsupportedCharactersString})";
        }
        
        return new UsernameValidationResult(username, isValid, errorMessage);
    }
}