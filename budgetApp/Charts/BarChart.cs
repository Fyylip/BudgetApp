using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace budgetApp.Charts;

public class BarChart
{
    public CartesianChart CreateBarChart()
    {
        return new CartesianChart
        {
            Series = new ISeries[]
            {
                new RowSeries<int>
                {
                    Values = new int[] { 8 },
                    Stroke = null,
                    DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
                    DataLabelsSize = 14,
                    DataLabelsPosition = DataLabelsPosition.End,
                    Name = "Cars",
                },
                new RowSeries<int>
                {
                    Values = new int[] { 6 },
                    Stroke = null,
                    DataLabelsPaint = new SolidColorPaint(new SKColor(20, 20, 20)),
                    DataLabelsSize = 14,
                    DataLabelsPosition = DataLabelsPosition.End,
                    Name = "Cars",
                },
            }
        };
    }
}
        
   