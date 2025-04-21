using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System.Collections.Generic;

namespace ViewModelsSamples.Pies.Basic;

public class PieChartViewModel
{
    public PieChart CreatePieChart(List<decimal> amounts, List<string> categories)
    {
        var series = new List<PieSeries<decimal>>();

        for (int i = 0; i < amounts.Count; i++)
        {
            var value = amounts[i];
            var category = categories[i];

            series.Add(new PieSeries<decimal>
            {
                Values = new[] { value },
                ToolTipLabelFormatter = (chartPoint) =>
                    $"{category}: {chartPoint.Coordinate.PrimaryValue} zł" // Use 'chartPoint.Coordinate.PrimaryValue' instead of 'chartPoint.PrimaryValue'
            });
        }

        return new PieChart
        {
            Series = series,
            Title = new LabelVisual
            {
                Text = "Wydatki",
                TextSize = 25,
                Padding = new LiveChartsCore.Drawing.Padding(15),
                Paint = new SolidColorPaint(SKColors.White)
            }
        };
    }
}

