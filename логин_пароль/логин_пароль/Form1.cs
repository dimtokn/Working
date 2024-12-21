using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourierRegistration
{
    public partial class Form1 : Form
    {
        private Random _random = new Random();
        public Form1()
        {
            InitializeComponent();
            //Скрытие элементов, которые не используются при инициализации формы
            labelPhoneNumber.Visible = false;
            textBoxPhoneNumber.Visible = false;
            labelDateOfBirth.Visible = false;
            dateTimePickerDateOfBirth.Visible = false;

        }

        // Обработчик события выбора радиокнопки категории пользователя
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCustomer.Checked)
            {
                labelPhoneNumber.Visible = true;
                textBoxPhoneNumber.Visible = true;
                labelDateOfBirth.Visible = false;
                dateTimePickerDateOfBirth.Visible = false;
                // При выборе Заказчика, скрываем дату рождения
            }
            else if (radioButtonEmployee.Checked)
            {
                labelPhoneNumber.Visible = false;
                textBoxPhoneNumber.Visible = false;
                labelDateOfBirth.Visible = true;
                dateTimePickerDateOfBirth.Visible = true;
                // При выборе Сотрудника, скрываем номер телефона
            }
        }
        // Метод генерации логина для сотрудника
        private string GenerateEmployeeLogin(string lastName, string firstName, string middleName, DateTime dateOfBirth)
        {
            // Получаем первые буквы ФИО
            string initials = $"{lastName[0]}{firstName[0]}{middleName[0]}".ToUpper();
            // Добавляем год рождения
            string year = dateOfBirth.Year.ToString();
            return $"{initials}{year}";
        }

        // Метод генерации логина для заказчика
        private string GenerateCustomerLogin(string lastName, string firstName, string middleName, string phoneNumber)
        {
            // Получаем первые буквы ФИО
            string initials = $"{lastName[0]}{firstName[0]}{middleName[0]}".ToUpper();

            if (phoneNumber.Length < 3)
            {
                throw new ArgumentException("Номер телефона должен содержать не менее трех цифр.");
            }
            // Добавляем последние три цифры номера телефона
            string lastThreeDigits = phoneNumber.Substring(phoneNumber.Length - 3);
            return $"{initials}{lastThreeDigits}";
        }
        // Метод генерации пароля
        private string GeneratePassword()
        {
            StringBuilder password = new StringBuilder();
            // Символы для генерации пароля
            const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string upperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";

            // Первые две позиции: строчные буквы
            password.Append(lowerCaseChars[_random.Next(lowerCaseChars.Length)]);
            password.Append(lowerCaseChars[_random.Next(lowerCaseChars.Length)]);
            // Следующие две позиции: прописные буквы
            password.Append(upperCaseChars[_random.Next(upperCaseChars.Length)]);
            password.Append(upperCaseChars[_random.Next(upperCaseChars.Length)]);
            // Пятая и шестая позиции: случайные цифры
            password.Append(digits[_random.Next(digits.Length)]);
            password.Append(digits[_random.Next(digits.Length)]);
            // Две последние позиции: прописные буквы
            password.Append(upperCaseChars[_random.Next(upperCaseChars.Length)]);
            password.Append(upperCaseChars[_random.Next(upperCaseChars.Length)]);

            return password.ToString();
        }
        // Обработчик события нажатия на кнопку регистрации
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение данных с формы
                string lastName = textBoxLastName.Text;
                string firstName = textBoxFirstName.Text;
                string middleName = textBoxMiddleName.Text;

                // Проверка на заполнение ФИО
                if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(middleName))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля ФИО.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string generatedLogin = "";
                // Генерация логина в зависимости от категории
                if (radioButtonCustomer.Checked)
                {
                    string phoneNumber = textBoxPhoneNumber.Text;
                    if (string.IsNullOrEmpty(phoneNumber))
                    {
                        MessageBox.Show("Пожалуйста, введите номер телефона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    generatedLogin = GenerateCustomerLogin(lastName, firstName, middleName, phoneNumber);
                }
                else if (radioButtonEmployee.Checked)
                {
                    DateTime dateOfBirth = dateTimePickerDateOfBirth.Value;
                    generatedLogin = GenerateEmployeeLogin(lastName, firstName, middleName, dateOfBirth);
                }

                // Генерация пароля
                string generatedPassword = GeneratePassword();

                // Вывод сгенерированных данных в текстовые поля
                textBoxLogin.Text = generatedLogin;
                textBoxPassword.Text = generatedPassword;

                
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}