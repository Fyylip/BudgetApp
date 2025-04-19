using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.WinForms;
using System.Collections.Generic;

namespace ViewModelsSamples.Pies.Basic;

public class PieChartViewModel
{
    // Poprawione - zwracamy PieChart zamiast CartesianChart
    public PieChart CreatePieChart()
    {
        return new PieChart
        {
            Series = this.Series,
            Title = this.Title
        };
    }

    public IEnumerable<ISeries> Series { get; set; } =
        new[] { 2, 4, 1, 4, 3 }.AsPieSeries();

    public LabelVisual Title { get; set; } = new LabelVisual
    {
        Text = "My chart title",
        TextSize = 25,
        Padding = new LiveChartsCore.Drawing.Padding(15)
    };
}