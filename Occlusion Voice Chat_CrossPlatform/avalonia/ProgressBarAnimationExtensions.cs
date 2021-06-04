using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia
{
    /// <summary>
    /// https://github.com/AvaloniaUI/Avalonia/issues/2881
    /// </summary>
    public class ProgressBarAnimationExtensions
    {
        public static AvaloniaProperty<double> ValueProperty =
        AvaloniaProperty.RegisterAttached<ProgressBarAnimationExtensions, ProgressBar, double>("Value");

        public static void SetValue(ProgressBar pb, double value) =>
            pb.SetValue(ValueProperty, value);

        static ProgressBarAnimationExtensions()
        {
            ValueProperty.Changed.Subscribe(ev =>
            {
                ((ProgressBar)ev.Sender).Value = ev.NewValue.Value;
            });
        }
    }
}
