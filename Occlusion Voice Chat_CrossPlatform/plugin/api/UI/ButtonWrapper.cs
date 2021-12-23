using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Interactivity;

namespace Occlusion_Voice_Chat_CrossPlatform.plugin.api.UI
{
    /// <summary>
    /// This class is designed as a generic wrapper for a "button" control. If Occlusion ever changes UI frameworks, this will not change.
    /// </summary>
    public class ButtonWrapper
    {
        private Button _button = new Button();

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                _button.Name = value;
            }
        }

        private string _text = string.Empty;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                _button.Content = value;
            }
        }

        public ButtonWrapper()
        {

        }

        public ButtonWrapper(Button button)
        {
            _button = button;
        }
        
        public ButtonWrapper(Button button, string text, string name)
        {
            _button = button;
            _text = text;
            _name = name;
        }
        
        public ButtonWrapper(string text, string name)
        {
            Text = text;
            Name = name;
        }

        /// <summary>
        /// Returns the native control used by whatever UI framework Occlusion is using.
        /// You should check and make sure this returns the class you think it is going to return before using it.
        /// </summary>
        /// <returns></returns>
        public object GetNativeControl()
        {
            return _button;
        }
        
        /// <summary>
        /// Sets the click event for the underlying button control.
        /// </summary>
        /// <param name="handler"></param>
        public void SetClickHandler(Action<object, RoutedEventArgs> handler)
        {
            _button.Click += (sender, e) => handler(sender, e);
        }
    }
}
