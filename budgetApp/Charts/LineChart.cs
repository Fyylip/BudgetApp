using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;

namespace budgetApp.Charts
{
    public class LineChart
    {
        public CartesianChart CreateLineChart()
        {
            return new CartesianChart
            {
                // Podstawowa konfiguracja wykresu liniowego
                Series = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = new double[] { 4000, 6000, 5000, 2000, 4000, 6000, 8000, 10000, 3000, 5000, 2000, 900 },
                        GeometrySize = 5,
                        LineSmoothness = 1
                    }
                },
                XAxes = new List<Axis>
                {
                    new Axis { Name = "Oś X", Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } }
                },
                YAxes = new List<Axis>
                {
                    new Axis { Name = "Oś Y", Labeler = value => value.ToString("N") }
                }
            };
        }
    }
}