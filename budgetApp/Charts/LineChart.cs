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

        public CartesianChart CreateLineChartYear(int userId)
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
                        new Axis { Name = "Months", Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } }
                    },
                YAxes = new List<Axis>
                    {
                        new Axis { Name = "Wydatki", Labeler = value => value.ToString("N") }
                    }
            };
        }

        public CartesianChart CreateLineChartWeek(int userId)
        {
            var currentDay = DateTime.Now.DayOfWeek;

            // Lista dni tygodnia
            var daysOfWeek = new[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            // Ustawienie kolejności: 6 poprzednich dni + dzisiaj
            var orderedDays = new List<string>();
            for (int i = -5; i <= 0; i++)
            {
                int dayIndex = ((int)currentDay + i + 7) % 7;
                orderedDays.Add(daysOfWeek[dayIndex]);
            }

            // Pobierz dane z bazy danych — za 7 dni
            var weeklyExpenses = _dbHelper.GetWeeklyExpenses(userId);

            // Jeśli weeklyExpenses ma mniej niż 7 elementów, to dodaj 0
            while (weeklyExpenses.Count < 7)
            {
                weeklyExpenses.Insert(0, 0);
            }

            return new CartesianChart
            {
                Series = new ISeries[]
                {
                        new LineSeries<double>
                        {
                            Values = weeklyExpenses.ConvertAll(e => (double)e),
                            GeometrySize = 5,
                            LineSmoothness = 1
                        }
                },
                XAxes = new List<Axis>
                    {
                        new Axis
                        {
                            Name = "Dni tygodnia",
                            Labels = orderedDays.ToArray()
                        }
                    },
                YAxes = new List<Axis>
                    {
                        new Axis
                        {
                            Name = "Wydatki",
                            Labeler = value => value.ToString("N")
                        }
                    }
            };
        }
    }
}
