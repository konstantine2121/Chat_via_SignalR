using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chat.AvaloniaClient.ViewModels.Login;

public class LoginPageVm : ObservableObject
{
    private string _username;
    private bool _isValid;
    private string _errorMessage;

    public LoginPageVm()
    {
        LoginCommand = new RelayCommand(Login, CanLogin);
    }

    public string Username
    {
        get => _username;
        set
        {
            if (SetProperty(ref _username, value))
            {
                var validationResult = UsernameValidator.Validate(value);
                IsValid = validationResult.Result;
                ErrorMessage = validationResult.ErrorMessage;
            }
        }
    }

    public bool IsValid
    {
        get => _isValid;
        private set => SetProperty(ref _isValid, value);
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        private set => SetProperty(ref _errorMessage, value);
    }
    
    public string HasErrorMessage
    {
        get => _errorMessage;
        private set => SetProperty(ref _errorMessage, value);
    }
    
    public IRelayCommand LoginCommand;

    private bool CanLogin()
    {
        return IsValid;
    }

    private void Login()
    {
        if (CanLogin())
        {
            return;
        }
        
        //Login
        
        //Switch Page - send username to next page
    }
}