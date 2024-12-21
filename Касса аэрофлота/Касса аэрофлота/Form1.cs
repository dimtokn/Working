using System;
using System.Windows.Forms;

namespace Касса_аэрофлота
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timePickerDeparture.Format = DateTimePickerFormat.Time;
            timePickerDeparture.ShowUpDown = true;
            timePickerReturn.Format = DateTimePickerFormat.Time;
            timePickerReturn.ShowUpDown = true;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение данных с формы
                if (string.IsNullOrEmpty(textBoxAdults.Text) || string.IsNullOrEmpty(textBoxChildren.Text))
                {
                    throw new Exception("Поля для ввода количества взрослых и детей не могут быть пустыми.");
                }

                int adults = int.Parse(textBoxAdults.Text);
                int children = int.Parse(textBoxChildren.Text);
                bool hasLuggage = checkBoxLuggage.Checked;
                bool hastu = checkBoxto.Checked;
                string flightType = comboBoxFlights.SelectedItem.ToString();
                string classType = comboBoxClass.SelectedItem.ToString();
                DateTime departureDate = dateTimePickerDeparture.Value;
                DateTime returnDate = dateTimePickerReturn.Value;

                // Получение базовой цены
                double basePrice = GetBasePrice(classType);
                double baseCity = GetCity(flightType);
                double totalPrice = 0;

                // Расчёт стоимости для взрослых
                totalPrice += adults * (basePrice + baseCity);

                // Расчёт стоимости для детей со скидкой 10%
                totalPrice += children * ((basePrice + baseCity) * 0.9);

                // Учёт багажа (+2%)
                if (hasLuggage)
                {
                    totalPrice *= 1.02;
                }

                // Учёт рейса туда-обратно (удвоение стоимости)
                if (hastu)
                {
                    totalPrice *= 2;
                }

                // Формирование строки билета
                string ticketInfo = $"Рейс: {flightType}, Дата: {departureDate.ToShortDateString()}";
                if (hastu)
                {
                    ticketInfo += $", Возврат: {returnDate.ToShortDateString()}";
                }
                ticketInfo += $", Класс: {classType}, Взрослых: {adults}, Детей: {children}, Багаж: {(hasLuggage ? "Да" : "Нет")}, Итог: {totalPrice:F2} руб.";

                // Добавление информации о билете в ListBox
                listBoxTickets.Items.Add(ticketInfo);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных: " + ex.Message, "Ошибка");
            }
        }

        // Метод для получения базовой цены билета в зависимости от класса
        private double GetBasePrice(string classType)
        {
            switch (classType)
            {
                case "Эконом":
                    return 5000;
                case "Комфорт":
                    return 8000;
                case "Бизнес":
                    return 15000;
                case "1-й класс":
                    return 25000;
                default:
                    throw new Exception("Некорректный класс обслуживания.");
            }
        }

        // Метод для получения базовой цены рейса в зависимости от города
        private double GetCity(string city)
        {
            switch (city)
            {
                case "Москва":
                    return 5000;
                case "Сочи":
                    return 8000;
                case "Алмата":
                    return 15000;
                case "Краснодар":
                    return 25000;
                default:
                    throw new Exception("Некорректный пункт назначения.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxFlights.Items.AddRange(new string[] { "Москва", "Сочи", "Алмата", "Краснодар" });
            comboBoxClass.Items.AddRange(new string[] { "Эконом", "Комфорт", "Бизнес", "1-й класс" });
            comboBoxFlights.SelectedIndex = 0;
            comboBoxClass.SelectedIndex = 0;
        }
    }
}