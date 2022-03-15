using ReactiveUI;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;

public class MessageBoxModel : ReactiveObject
{
    private string _title = "...";
    public string WindowTitle
    {
        get => _title;

        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    
    private string _message = "...";
    public string Message
    {
        get => _message;

        set => this.RaiseAndSetIfChanged(ref _message, value);
    }
    
}