using budgetApp.DataBase;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using System.Collections.Generic;

namespace budgetApp.Charts
{
    public class LineChart
    {
        private readonly DatabaseHelper _dbHelper;

        public LineChart(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public CartesianChart CreateLineChart(int userId)
        {
            var monthlyExpenses = _dbHelper.GetMonthlyExpenses(userId);

            return new CartesianChart
            {
                Series = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = monthlyExpenses.ConvertAll(e => (double)e),
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
