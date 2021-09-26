using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia
{ 
    public class ScrollbarAnimationExtensions
    {
        public static AvaloniaProperty<Vector> OffsetProperty =
        AvaloniaProperty.RegisterAttached<ScrollbarAnimationExtensions, ScrollViewer, Vector>("Offset");

        public static void SetValue(ScrollViewer pb, Vector value) =>
            pb.SetValue(OffsetProperty, value, Avalonia.Data.BindingPriority.Animation);

        static ScrollbarAnimationExtensions()
        {
            OffsetProperty.Changed.Subscribe(ev =>
            {
                ((ScrollViewer)ev.Sender).Offset = ev.NewValue.Value;
            });
        }
    }
}
