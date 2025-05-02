using CommunityToolkit.Mvvm.ComponentModel;

namespace Chat.AvaloniaClient.ViewModels.Messages;

public class MessageEditorVm : ObservableObject
{
    public const int MaxMessageLength = 256;
    
    private string _text;

    public string Text
    {
        get => _text;
        set
        {
            if (SetProperty(ref _text, value))
            {
                OnPropertyChanged(nameof(IsEmpty));
                OnPropertyChanged(nameof(IsTooLong));
            }
        }
    }
    
    public bool IsEmpty => string.IsNullOrEmpty(Text);
    
    public bool IsTooLong => !string.IsNullOrEmpty(Text) && Text.Length > MaxMessageLength;
}