using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

public class AttackSimulationForm : Form
{
    private Chart attackChart;
    private Timer simulationTimer;
    private int systemCount;
    private int dayCount;
    private double[] attackProbabilities;
    private Random rng;

    public AttackSimulationForm()
    {
        systemCount = 20; // systems
        dayCount = 50; //  days
        rng = new Random();

        Text = "System Attacks Simulation";
        Size = new Size(800, 600);
        
        SetupComponents();
        InitializeProbabilities();

        simulationTimer = new Timer { Interval = 1500 };
        simulationTimer.Tick += PerformSimulation;
        simulationTimer.Start();
    }

    private void SetupComponents()
    {
        attackChart = new Chart
        {
            Dock = DockStyle.Fill,
            Palette = ChartColorPalette.Bright,
            BorderlineColor = Color.Black,
            BorderlineDashStyle = ChartDashStyle.Solid,
            BorderlineWidth = 1,
        };

        var chartArea = new ChartArea
        {
            Name = "AttackArea",
            AxisX = { Title = "Day" },
            AxisY = { Title = "Cumulative Number of Attacks" }
        };

        attackChart.ChartAreas.Add(chartArea);
        Controls.Add(attackChart);

        for (int i = 0; i < systemCount; i++)
        {
            var series = new Series
            {
                Name = $"System {i + 1}",
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };
            attackChart.Series.Add(series);
        }
    }

    private void InitializeProbabilities()
    {
        attackProbabilities = new double[systemCount];
        for (int i = 0; i < systemCount; i++)
        {
            attackProbabilities[i] = rng.NextDouble();
        }
    }

    private void PerformSimulation(object sender, EventArgs e)
    {
        foreach (var series in attackChart.Series)
        {
            series.Points.Clear();
        }

        for (int i = 0; i < systemCount; i++)
        {
            int cumulativeAttacks = 0;
            for (int j = 0; j < dayCount; j++)
            {
                if (rng.NextDouble() < attackProbabilities[i])
                {
                    cumulativeAttacks++;
                }
                attackChart.Series[$"System {i + 1}"].Points.AddXY(j + 1, cumulativeAttacks);
            }
        }
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new AttackSimulationForm());
    }
}
