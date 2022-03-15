using System.Threading.Tasks;
using Avalonia.Controls;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls.messagebox;

public class OcclusionMessageBox
{
    public MessageBoxWindow Window { get; private set; }

    protected string? Result { get; set; }
    
    public static OcclusionMessageBox GetMessageBox(MessageBoxType type, string title, string message)
    {
        OcclusionMessageBox messageBox = new OcclusionMessageBox();
        messageBox.Window = new MessageBoxWindow();

        messageBox.Window.ViewModel.Message = message;
        messageBox.Window.ViewModel.WindowTitle = title;

        Button okButton = new Button() { Content = "Ok" };
        Button cancelButton = new Button() { Content = "Cancel" };
        Button yesButton = new Button() { Content = "Yes" };
        Button noButton = new Button() { Content = "No" };

        okButton.Click += (sender, args) => { messageBox.Result = "Ok"; messageBox.Window.Close(); };
        cancelButton.Click += (sender, args) => { messageBox.Result = "Cancel"; messageBox.Window.Close(); };
        yesButton.Click += (sender, args) => { messageBox.Result = "Yes"; messageBox.Window.Close(); };
        noButton.Click += (sender, args) => { messageBox.Result = "No"; messageBox.Window.Close(); };
        
        switch(type)
        {
            case MessageBoxType.OK:
            default:
                messageBox.Window.ButtonsPanel.Children.Add(okButton);
                break;
            
            case MessageBoxType.OK_CANCEL:
                messageBox.Window.ButtonsPanel.Children.Add(okButton);
                messageBox.Window.ButtonsPanel.Children.Add(cancelButton);
                break;
            
            case MessageBoxType.YES_NO:
                messageBox.Window.ButtonsPanel.Children.Add(yesButton);
                messageBox.Window.ButtonsPanel.Children.Add(noButton);
                break;
            
            case MessageBoxType.YES_CANCEL:
                messageBox.Window.ButtonsPanel.Children.Add(yesButton);
                messageBox.Window.ButtonsPanel.Children.Add(cancelButton);
                break;
            
            case MessageBoxType.YES_NO_CANCEL:
                messageBox.Window.ButtonsPanel.Children.Add(yesButton);
                messageBox.Window.ButtonsPanel.Children.Add(noButton);
                messageBox.Window.ButtonsPanel.Children.Add(cancelButton);
                break;
        }
        
        return messageBox;
    }
    
    public async Task<MessageBoxResult> Show(Window owner)
    {
        await Window.ShowDialog(owner);

        return new MessageBoxResult(Result);
    }
}

public enum MessageBoxType
{
    OK,
    OK_CANCEL,
    YES_NO,
    YES_CANCEL,
    YES_NO_CANCEL
}

public struct MessageBoxResult
{
    public string? Result;
    
    public MessageBoxResult(string? result)
    {
        Result = result;
    }
}