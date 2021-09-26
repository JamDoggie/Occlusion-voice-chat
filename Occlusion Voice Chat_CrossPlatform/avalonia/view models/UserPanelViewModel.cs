using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models
{
    public class UserPanelViewModel : ReactiveObject
    {
        public PlotModel PlotModelLeft { get; private set; }
        public PlotModel PlotModelRight { get; private set; }

        public UserPanelViewModel()
        {
            var leftSeries = new LineSeries();
            
            leftSeries.MarkerType = MarkerType.Circle;
            leftSeries.InterpolationAlgorithm = InterpolationAlgorithms.CatmullRomSpline;


            PlotModelLeft = new PlotModel() { Title = "Left HRTF" };
            PlotModelLeft.Axes.Add(new LinearAxis() { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 128f, Key = "Horizontal" });
            PlotModelLeft.Axes.Add(new LinearAxis() { Position = AxisPosition.Left, Minimum = -1f, Maximum = 1f, Key = "Vertical" });
            PlotModelLeft.Series.Add(leftSeries);

            var rightSeries = new LineSeries();

            rightSeries.MarkerType = MarkerType.Circle;
            rightSeries.InterpolationAlgorithm = InterpolationAlgorithms.CatmullRomSpline;


            PlotModelRight = new PlotModel() { Title = "Right HRTF" };
            PlotModelRight.Axes.Add(new LinearAxis() { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 128f, Key = "Horizontal" });
            PlotModelRight.Axes.Add(new LinearAxis() { Position = AxisPosition.Left, Minimum = -1f, Maximum = 1f, Key = "Vertical" });
            PlotModelRight.Series.Add(rightSeries);
        }
    }
}
