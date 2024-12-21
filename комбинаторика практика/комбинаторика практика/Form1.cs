using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombinatoricsCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(txtN.Text);
                int k = int.Parse(txtK.Text);
                string operation = cmbOperation.SelectedItem.ToString();//выбор операции
                double result = 0;

                switch (operation)
                {
                    case "Перестановка без повторения":
                        result = Factorial(n);
                        // Перестановка без повторения: P(n) = n!
                        break;

                    case "Перестановка с повторением":
                        result = Math.Pow(n, n);
                        // Перестановка с повторением: P= n^n
                        break;

                    case "Сочетание без повторения":
                        result = Factorial(n) / (Factorial(k) * Factorial(n - k));
                        // Сочетание без повторения: C= n! / (k! * (n-k)!)
                        break;

                    case "Сочетание с повторением":
                        result = Factorial(n + k - 1) / (Factorial(k) * Factorial(n - 1));
                        // Сочетание с повторением: C = (n+k-1)! / (k! * (n-1)!)
                        break;

                    case "Размещение без повторения":
                        result = Factorial(n) / Factorial(n - k);
                        // Размещение без повторения: A = n! / (n-k)!
                        break;

                    case "Размещение с повторением":
                        result = Math.Pow(n, k);
                        // Размещение с повторением: A = n^k
                        break;

                    default:
                        MessageBox.Show("Выберите операцию.");//если операция не выбрана
                        return;
                }

                lblResult.Text = $"Результат: {result}";//вывод результата
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");//если не ввести значение and k
            }
        }

        private double Factorial(int x)
        {
            // Факториал числа: n! = 1 * 2 * ... * n
            if (x <= 1) return 1;
            return x * Factorial(x - 1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Добавление операций в выпадающий список при загрузке формы
            cmbOperation.Items.AddRange(new string[]
            {
                "Перестановка без повторения",
                "Перестановка с повторением",
                "Сочетание без повторения",
                "Сочетание с повторением",
                "Размещение без повторения",
                "Размещение с повторением"
            });

            cmbOperation.SelectedIndex = 0; // Выбирается первый элемент по умолчанию
        }
    }
}