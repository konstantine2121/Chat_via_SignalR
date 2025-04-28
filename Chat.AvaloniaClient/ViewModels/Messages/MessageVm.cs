namespace Chat.AvaloniaClient.ViewModels.Messages;

public class MessageVm
{
    public MessageVm(string user, string message)
    {
        User = user;
        Message = message;
    }

    public string User { get; }
    public string Message { get; }
}