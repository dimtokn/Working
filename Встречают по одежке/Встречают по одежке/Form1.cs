using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Встречают_по_одежке
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
               
                string flightType = comboBoxFlights.SelectedItem.ToString();
                string classType = comboBoxClass.SelectedItem.ToString();

                // Получение базовой цены
                double basePrice = GetBasePrice(classType);
                double baseCity = GetCity(flightType);
                double totalPrice = 0;

                // Расчёт стоимости для взрослых
                totalPrice += baseCity;
                

                // Формирование корзины
                string ticketInfo = $"Одежда: {flightType}";
               
                ticketInfo += $", Размер: {classType}, Итог: {totalPrice:F2} руб.";
                listBoxTickets.Items.Add(ticketInfo);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных: " + ex.Message, "Ошибка");
            }
        }

        // Метод для отображения размера одежды
        private double GetBasePrice(string classType)
        {
            switch (classType)
            {
                case "S":
                  
                case "M":
                   
                case "L":
                    
                case "X":
                    return 0;
                default:
                    throw new Exception("Не выбраны данные для добавки в корзину.");
            }
        }

        // Метод для отображения списка одежды
        private double GetCity(string city)
        {
            switch (city)
            {
                case "Кофта":
                    return 5000;
                case "Брюки":
                    return 8000;
                case "Футболка":
                    return 15000;
                case "Куртка":
                    return 25000;
                case "Майка":
                    return 25000;
                default:
                    throw new Exception("Некорректный выбор одежды.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxFlights.Items.AddRange(new string[] { "","Кофта", "Брюки", "Футболка", "Куртка", "Майка" });
            comboBoxClass.Items.AddRange(new string[] {"", "S", "M", "L", "X" });
            comboBoxFlights.SelectedIndex = 0;
            comboBoxClass.SelectedIndex = 0;


            

            pictureBoxProduct.Image = null; // Начальное изображение
            labelDescription.Text = "Описание товара будет отображаться здесь.";
        }

        private void comboBoxFlights_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBoxFlights.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "Кофта":
                    pictureBoxProduct.Image = Properties.Resources.Кофта; // Пример пути к изображению
                    labelDescription.Text = "Уютная кофта с капюшоном для холодной погоды.";
                    break;
                case "Брюки":
                    pictureBoxProduct.Image = Properties.Resources.Брюки;
                    labelDescription.Text = "Элегантные брюки для офиса или повседневной носки.";
                    break;
                case "Футболка":
                    pictureBoxProduct.Image = Properties.Resources.Футболка;
                    labelDescription.Text = "Легкая футболка для жарких дней, с ярким принтом.";
                    break;
                case "Куртка":
                    pictureBoxProduct.Image = Properties.Resources.Куртка;
                    labelDescription.Text = "Зимняя куртка с утеплителем, подходящая для холодных дней.";
                    break;
                case "Майка":
                    pictureBoxProduct.Image = Properties.Resources.Майка;
                    labelDescription.Text = "Удобные кроссовки, подходящие на любой случай жизни.";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxTickets.Items.Count == 0)
                {
                    MessageBox.Show("Корзина пуста. Пожалуйста, добавьте товары перед покупкой.", "Ошибка");
                    return;
                }

                // Генерация информации о заказе
                string orderNumber = Guid.NewGuid().ToString().Substring(0, 8); // Уникальный номер заказа
                DateTime orderDate = DateTime.Now; // Текущая дата
                string orderItems = string.Join("\n", listBoxTickets.Items.Cast<string>()); // Состав заказа
                double totalPrice = CalculateTotalPrice(); // Подсчёт общей суммы
                string pickupPoint = "Пункт выдачи №1, ул. Сафонова, д. 5"; // Условный пункт выдачи
                DateTime deliveryDate = orderDate.AddDays(3); // Срок выполнения заказа (например, 3 дня)
                string pickupCode = new Random().Next(100000, 999999).ToString(); // Генерация кода получения

                // Формирование текста для MessageBox
                string message = $"Номер заказа: {orderNumber}\n" +
                                 $"Дата заказа: {orderDate}\n" +
                                 $"Состав заказа:\n{orderItems}\n" +
                                 $"Общая сумма: {totalPrice:F2} руб.\n" +
                                 $"Код получения: {pickupCode}\n" +
                                 $"Пункт выдачи: {pickupPoint}\n" +
                                 $"Срок исполнения: {deliveryDate:dd.MM.yyyy}";

                // Вывод информации в MessageBox
                MessageBox.Show(message, "Информация о заказе");

                // Очистка корзины после оформления заказа
                listBoxTickets.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при оформлении заказа: " + ex.Message, "Ошибка");
            }
        }

        // Метод для подсчёта общей суммы заказа
        private double CalculateTotalPrice()
        {
            double totalPrice = 0;

            foreach (string item in listBoxTickets.Items)
            {
                // Извлекаем цену из строки (предполагаем, что она в формате "... Итог: 12345.67 руб.")
                int index = item.LastIndexOf("Итог: ");
                if (index != -1)
                {
                    string priceText = item.Substring(index + 6).Replace(" руб.", "");
                    if (double.TryParse(priceText, out double price))
                    {
                        totalPrice += price;
                    }
                }
            }

            return totalPrice;
        }
    }
}