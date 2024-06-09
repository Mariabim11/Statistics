using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Timer = System.Timers.Timer;

namespace PenetrationSimulation
{
    public partial class PenetrationSimulationForm : Form
    {
        private bool isDragging = false;
        private Point lastCursorPosition;

        private bool isResizing = false;
        private Point resizeStart;
        private Size originalSize;

        private PictureBox pictureBox1;

        private Chart lineChart, histogramChart, partialHistogramChart;
        private Bitmap lineBitmap, columnBitmap, partialBitmap, finalBitmap;

        private int prev = 0;
        private int curr = 1;
        private Timer myTimer;
        private bool status1 = false;

        private int max_value;
        private int max_histogram;
        private int[] values_lines;

        private ChartArea chartArea, histogramArea, histogramPartialArea;

        public PenetrationSimulationForm()
        {
            InitializeComponent();

            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = int.MaxValue;

            numericUpDown2.Minimum = 1;
            numericUpDown2.Maximum = int.MaxValue;

            numericUpDown3.Minimum = 1;
            numericUpDown3.Maximum = int.MaxValue;
        }

        private void PenetrationSimulationForm_Load(object sender, EventArgs e)
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(0, 100);
            WindowState = FormWindowState.Maximized;
            pictureBox1.Height = Size.Height;
            pictureBox1.Width = Size.Width;
            Controls.Add(pictureBox1);

            panel1.Width = pictureBox1.Width;
            panel1.Height = pictureBox1.Height - 139;
            panel1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            int attackRatio = (int)numericUpDown1.Value;
            int intervals = (int)numericUpDown2.Value;
            int numberServers = (int)numericUpDown3.Value;

            if (attackRatio > intervals)
            {
                MessageBox.Show("Invalid values selected. Exiting...");
                Environment.Exit(-1);
            }

            myTimer = new Timer();
            myTimer.Interval = 500;
            myTimer.Elapsed += MyElapsed;
            myTimer.AutoReset = true;
            myTimer.Start();

            CreateAttackGraphsPanel(attackRatio, intervals, numberServers);

            myTimer.Stop();
        }

        private void MyElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            curr++;
        }

        private void MyRefresh()
        {
            if (status1)
            {
                max_value = values_lines.Max();
                chartArea.AxisY.Maximum = max_value;
                histogramArea.AxisX.Maximum = max_value;
                histogramPartialArea.AxisX.Maximum = max_value;

                int temp;
                max_histogram = 0;
                for (int i = 0; i < values_lines.Length; i++)
                {
                    temp = values_lines.Count(s => s == values_lines[i]);
                    if (temp > max_histogram) { max_histogram = temp; }
                }
                histogramArea.AxisY.Maximum = max_histogram * 1.05;

                lineChart.DrawToBitmap(lineBitmap, new Rectangle(0, 0, panel1.Width / 2, panel1.Height));
                histogram_partial.DrawToBitmap(partialBitmap, new Rectangle(panel1.Width / 4, 0, panel1.Width, panel1.Height));
                histogramChart.DrawToBitmap(columnBitmap, new Rectangle(panel1.Width / 2, 0, panel1.Width, panel1.Height));

                lineBitmap.MakeTransparent(Color.White);
                columnBitmap.MakeTransparent(Color.White);
                partialBitmap.MakeTransparent(Color.White);

                using (Graphics g = Graphics.FromImage(finalBitmap))
                {
                    g.Clear(Color.Transparent);
                    g.DrawImage(lineBitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
                    g.DrawImage(partialBitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
                    g.DrawImage(columnBitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
                }

                panel1.BackgroundImage = finalBitmap;
                panel1.BackgroundImageLayout = ImageLayout.Stretch;
                panel1.Refresh();
            }
            prev = curr;
        }

        private void CreateAttackGraphsPanel(float attackRatio, int intervals, int numberServers)
        {
            status1 = true;

            // Create the Chart for the security score 
            lineChart = new Chart();
            lineChart.Width = panel1.Width / 2;
            lineChart.Height = panel1.Height;

            // Create chart for security scores
            chartArea = new ChartArea("SecurityChart");
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;
            chartArea.AxisY.LabelStyle.Format = "0";
            chartArea.Position = new ElementPosition(0, 0, 100, 100);
            lineChart.ChartAreas.Add(chartArea);

            // Create chart for the histogram
            histogramChart = new Chart();
            histogramChart.Width = panel1.Width / 2;
            histogramChart.Height = panel1.Height;
            histogramArea = new ChartArea("HistogramChart");
            histogramArea.AxisY.Minimum = 0;
            histogramArea.AxisX.Minimum = 0;
            histogramArea.AxisX.MajorGrid.LineWidth = 0;
            histogramArea.AxisY.MajorGrid.LineWidth = 0;
            histogramArea.AxisX.LabelStyle.Format = "0";
            histogramArea.AxisX.LabelStyle.Enabled = false;
            histogramArea.AxisX.MajorTickMark.Enabled = false;
            histogramArea.AxisY.LabelStyle.Format = "0";
            histogramArea.Position = new ElementPosition(0, 1, 97, 99);
            histogramChart.ChartAreas.Add(histogramArea);

            // Create the Chart for the partial histogram
            partialHistogramChart = new Chart();
            partialHistogramChart.Width = panel1.Width;
            partialHistogramChart.Height = panel1.Height;
            histogramPartialArea = new ChartArea("HistogramChart");
            histogramPartialArea.AxisY.Minimum = 0;
            histogramPartialArea.AxisX.Minimum = 0;
            histogramPartialArea.AxisX.MajorGrid.LineWidth = 0;
            histogramPartialArea.AxisY.MajorGrid.LineWidth = 0;
            histogramPartialArea.AxisX.Enabled = AxisEnabled.False;
            histogramPartialArea.AxisY.Enabled = AxisEnabled.False;
            histogramPartialArea.Position = new ElementPosition(0, 2, 50, 97);
            partialHistogramChart.ChartAreas.Add(histogramPartialArea);

            // Create bitmap that will contain both charts
            lineBitmap = new Bitmap(panel1.Width, panel1.Height);
            columnBitmap = new Bitmap(panel1.Width, panel1.Height);
            partialBitmap = new Bitmap(panel1.Width, panel1.Height);
            finalBitmap = new Bitmap(panel1.Width, panel1.Height);

            // Variables for the security score chart
            Series[] linesArray = new Series[numberServers];
            values_lines = new int[numberServers];
            Random rnd = new Random();

            // Initialization of security score chart
            for (int i = 0; i < linesArray.Length; i++)
            {
                Series lineSeries = new Series();
                linesArray[i] = lineSeries;
                lineSeries.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                lineSeries.ChartType = SeriesChartType.Line;
                lineChart.Series.Add(lineSeries);
                lineSeries.Points.AddXY(0, 0);
                values_lines[i] = 0;
            }

            // Simulation to draw chart
            for (int i = 1; i < intervals + 1; i++)
            {
                if (i == intervals / 2)
                {
                    DrawPartialHistogram(values_lines, numberServers);
                }

                for (int j = 0; j < numberServers; j++)
                {
                    Series series = linesArray[j];

                    if (rnd.NextDouble() >= (attackRatio / intervals))
                    {
                        series.Points.AddXY(i, values_lines[j]);
                    }
                    else
                    {
                        series.Points.AddXY(i, values_lines[j] + 1);
                        values_lines[j] += 1;
                    }

                    lineChart.Series.Append(series);
                    lineChart.Update();
                }
                if (prev != curr) MyRefresh();
            }
            MyRefresh();

            Array.Sort(values_lines);
            int current = int.MinValue;
            for (int i = 0; i < values_lines.Length; i++)
            {
                if (values_lines[i] == current) continue;
                current = values_lines[i];
                Series histogramSeries = new Series();
                histogramSeries.ChartType = SeriesChartType.Bar;
                histogramSeries.Color = Color.Red;
                histogramSeries["PointWidth"] = "0.1";
                histogramSeries.SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                histogramSeries.Points.Add(new DataPoint(current, values_lines.Count(s => s == current)));
                histogramChart.Series.Add(histogramSeries);
                histogramChart.Update();
                if (prev != curr) MyRefresh();
            }
            MyRefresh();

            status1 = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.BringToFront();
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = e.Location;
            }

            if (e.Button == MouseButtons.Right)
            {
                isResizing = true;
                resizeStart = e.Location;
                originalSize = panel1.Size;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - lastCursorPosition.X;
                int deltaY = e.Y - lastCursorPosition.Y;
                panel1.Left += deltaX;
                panel1.Top += deltaY;
            }

            if (isResizing)
            {
                int deltaX = e.X - resizeStart.X;
                int deltaY = e.Y - resizeStart.Y;

                // Calculate the new size of the panel based on the mouse movement
                int newWidth = originalSize.Width + deltaX;
                int newHeight = originalSize.Height + deltaY;

                if (newWidth > 0 && newHeight > 0)
                {
                    panel1.Size = new Size(newWidth, newHeight);
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            isResizing = false;
        }

        private void DrawPartialHistogram(int[] valuesLines, int numberServers)
        {
            int[] temp = new int[numberServers];

            for (int i = 0; i < numberServers; i++) { temp[i] = valuesLines[i]; }

            Array.Sort(temp);
            int current = int.MinValue;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == current) continue;
                current = temp[i];
                Series histogramSeries = new Series();
                histogramSeries.ChartType = SeriesChartType.Bar;
                histogramSeries.Color = Color.Blue;
                histogramSeries["PointWidth"] = "0.1";
                histogramSeries.SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                histogramSeries.Points.Add(new DataPoint(current, temp.Count(s => s == current)));
                partialHistogramChart.Series.Add(histogramSeries);
                partialHistogramChart.Update();
            }
        }
    }
}
