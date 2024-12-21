using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            try
            {
                // Чтение данных с формы
                double Xmin = double.Parse(textBoxXmin.Text);
                double Xmax = double.Parse(textBoxXmax.Text);
                double Step = double.Parse(textBoxStep.Text);

                // Проверка корректности ввода
                if (Xmax <= Xmin || Step <= 0)
                {
                    MessageBox.Show("Введите корректные значения Xmin, Xmax и Step.");
                    return;
                }

                // Вычисление количества точек
                int count = (int)Math.Ceiling((Xmax - Xmin) / Step) + 1;

                // Инициализация массивов
                double[] x = new double[count];
                double[] y1 = new double[count];
                double[] z = new double[count];

                
                double y_fixed = Math.PI / 4; // Фиксированное значение для y

                // Заполнение массивов значениями
                for (int i = 0; i < count; i++)
                {
                    x[i] = Xmin + Step * i; // Значение X

                    // Вычисляем z как фиксированное значение
                    z[i] = 5;

                    // Вычисление y1 по формуле
                    y1[i] = Math.Pow(
                                Math.Abs(Math.Cos(x[i]) - Math.Cos(y_fixed)),
                                1 + 2 * Math.Pow(Math.Sin(y_fixed), 2)
                                ) * (1 + z[i] + Math.Pow(z[i], 2) / 2 + Math.Pow(z[i], 3) / 3 + Math.Pow(z[i], 4) / 4);
                }

                // Настройка осей графика
                chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;

                // Очистка предыдущих данных
                chart1.Series.Clear();

                // Добавляем серию для y1
                var seriesY1 = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "y1",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
                };
                chart1.Series.Add(seriesY1);
                chart1.Series["y1"].Points.DataBindXY(x, y1);

                // Добавляем серию для z
                var seriesZ = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "z",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
                };
                chart1.Series.Add(seriesZ);
                chart1.Series["z"].Points.DataBindXY(x, z);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

    }
}
