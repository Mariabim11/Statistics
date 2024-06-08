using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

public class SystemAttacksSimulationForm : Form
{
    private Chart chart;
    private Timer timer;
    private int M;
    private int N;
    private double[] probabilities;

    public SystemAttacksSimulationForm()
    {
        Text = "System Attacks Simulation";
        Size = new Size(800, 400);

        InitializeComponents();

        // Initialize default values for M and N
        M = 20; // Number of systems
        N = 50; // Number of days

        // Start the simulation
        StartSimulation();
    }

    private void InitializeComponents()
    {
        chart = new Chart
        {
            Size = new Size(800, 400),
            Dock = DockStyle.Fill,
            BorderlineColor = Color.Black,
            BorderlineWidth = 1,
            BorderlineDashStyle = ChartDashStyle.Solid
        };

        chart.ChartAreas.Add(new ChartArea());
        Controls.Add(chart);
    }

    private void StartSimulation()
    {
        // Generate random probabilities for each system
        Random random = new Random();
        probabilities = new double[M];
        for (int i = 0; i < M; i++)
        {
            probabilities[i] = random.NextDouble();
        }

        // Start the timer to update the chart
        timer = new Timer
        {
            Interval = 1500 // Update the chart every 1.5 seconds
        };
        timer.Tick += UpdateChart;
        timer.Start();
    }

    private void UpdateChart(object sender, EventArgs e)
    {
        for (int i = 0; i < M; i++)
        {
            int cumulativeAttacks = 0;
            for (int j = 0; j < N; j++)
            {
                if (new Random().NextDouble() < probabilities[i])
                {
                    cumulativeAttacks++;
                }
                chart.Series[$"System {i + 1}"].Points.AddXY($"Day {j + 1}", cumulativeAttacks);
            }
        }

        // Remove points older than N days to keep the chart readable
        foreach (var series in chart.Series)
        {
            while (series.Points.Count > N)
            {
                series.Points.RemoveAt(0);
            }
        }

        chart.Update();
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new SystemAttacksSimulationForm());
    }
}
