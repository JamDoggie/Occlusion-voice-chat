using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls
{
    public class RatioCanvas : Canvas
    {
        public RatioCanvas()
        {
            RatioXProperty.Changed.Subscribe(x => HandleRatioXChange(x.Sender, x.NewValue.GetValueOrDefault<double>()));
            RatioYProperty.Changed.Subscribe(y => HandleRatioYChange(y.Sender, y.NewValue.GetValueOrDefault<double>()));
        }

        public static readonly AttachedProperty<double> RatioXProperty = AvaloniaProperty.RegisterAttached<Control, Interactive, double>(
        "RatioX", default(double), false, BindingMode.OneTime);

        public static readonly AttachedProperty<double> RatioYProperty = AvaloniaProperty.RegisterAttached<Control, Interactive, double>(
        "RatioY", default(double), false, BindingMode.OneTime);

        private void HandleRatioXChange(IAvaloniaObject element, double value)
        {
            if (element is AvaloniaObject obj)
                SetLeft(obj, Bounds.Width * (value / 100));
        }

        private void HandleRatioYChange(IAvaloniaObject element, double value)
        {
            if (element is AvaloniaObject obj)
                SetTop(obj, Bounds.Height * (value / 100));
        }
    }
}
