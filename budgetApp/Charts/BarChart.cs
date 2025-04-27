using System.Drawing;
using System.Windows.Forms;

namespace budgetApp.Charts;

public class BarChart
{
    private Panel _targetPanel;

    public BarChart(Panel targetPanel)
    {
        _targetPanel = targetPanel;
    }

    public Panel CreateSavingsProgressPanel(string label, int percent, Color fillColor)
    {
        var container = new Panel
        {
            BackColor = Color.FromArgb(35, 23, 74),
            Padding = new Padding(10),
            Margin = new Padding(10),
            Dock = DockStyle.Bottom,
        };

        var titleLabel = new Label
        {
            Text = $"{label} - {percent}%",
            ForeColor = Color.White,
            Dock = DockStyle.Top,
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            Height = 20
        };

        var progressBarBackground = new Panel
        {
            BackColor = Color.Black,
            Height = 10,
            Dock = DockStyle.Top,
            Margin = new Padding(0, 5, 0, 0)
        };

        var progressFill = new Panel
        {
            BackColor = fillColor,
            Height = 10,
            Dock = DockStyle.Left
        };

        progressBarBackground.Resize += (s, e) =>
        {
            progressFill.Width = (int)(progressBarBackground.Width * percent / 100.0);
        };

        progressBarBackground.Controls.Add(progressFill);
        container.Controls.Add(progressBarBackground);
        container.Controls.Add(titleLabel);

        return container;
    }

}
