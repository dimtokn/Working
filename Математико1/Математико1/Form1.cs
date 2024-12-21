using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MatematikoGame
{
    public partial class Form1 : Form
    {
        // Массив чисел от 1 до 13, используемых в игре.
        private int[] _numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        // Массив, отслеживающий количество оставшихся чисел каждого типа.
        private int[] _numberCounts;
        // Список всех кнопок игрового поля.
        private List<Button> _gameButtons;
        // Текущее число, которое нужно разместить на поле.
        private int _currentNumber;
        // Генератор случайных чисел.
        private Random _random = new Random();
        // Текущий счет игрока.
        private int _score = 0;
        // Флаг, указывающий, завершена ли игра.
        private bool _gameOver = false;
        // Счетчик ходов игрока
        private int _moves = 0;
        // Список для хранения всех чисел, которые уже были размещены
        private List<int> _placedNumbers = new List<int>();

        public Form1()
        {
            InitializeComponent(); 
           
            labelGameName.Text = "Математико";
            labelRules.Text = "Цель игры - разместить числа на поле таким образом, чтобы набрать наибольшее количество очков.\n" +
                             "Очки начисляются за последовательности (20 очков) и наборы одинаковых чисел (50 очков) в горизонтальных и вертикальных рядах.";
            labelAbout.Text = "Разработчик: dimtokn";
            // Получение списка всех кнопок игрового поля
            _gameButtons = Controls.OfType<Button>().Where(btn => btn.Name.StartsWith("button") && btn.Name != "buttonNewGame").ToList();
            InitializeGame(); 
        }

        private void InitializeGame()
        {
            // сбрасываем счетчик ходов при новой игре
            _moves = 0;
            // Очищаем список размещенных чисел при старте новой игры
            _placedNumbers.Clear();
            _gameOver = false; // Сброс флага окончания игры
            labelGameOver.Text = ""; // Очистка сообщения об окончании игры
            _score = 0; // Сброс счета
            labelScore.Text = $"Очки: {_score}"; // Обновление метки счета
            labelHint.Text = "Поместите число на поле"; // Вывод подсказки

            _numberCounts = new int[_numbers.Length]; // Инициализация массива счетчиков чисел
            for (int i = 0; i < _numberCounts.Length; i++)
            {
                _numberCounts[i] = 4; // Каждого числа по 4
            }

            // Очистка всех кнопок и возврат к начальному состоянию
            foreach (var button in _gameButtons)
            {
                button.Text = ""; // Очистка текста на кнопке
                button.Enabled = true; // Возвращение кнопок в активное состояние
                button.BackColor = SystemColors.Control; // Устанавливаем начальный цвет кнопок
            }
            GetRandomNumber(); // Получение случайного числа
        }

        // Метод получения случайного числа из доступных
        private void GetRandomNumber()
        {
            List<int> availableNumbers = new List<int>(); // Список для хранения доступных чисел
            // Добавляем в список доступные числа, количество которых больше 0
            for (int i = 0; i < _numbers.Length; i++)
            {
                if (_numberCounts[i] > 0)
                {
                    availableNumbers.Add(_numbers[i]);
                }
            }

            // Если доступных чисел нет, завершаем игру
            if (availableNumbers.Count == 0)
            {
                labelCurrentNumber.Text = "Игра окончена";
                GameOver();
                return;
            }

            // Выбор случайного числа из доступных
            _currentNumber = availableNumbers[_random.Next(availableNumbers.Count)];
            _numberCounts[_currentNumber - 1]--; // Уменьшаем количество выбранного числа
            labelCurrentNumber.Text = $"Число: {_currentNumber}"; // Вывод числа на экран
            _moves++; //Увеличиваем счетчик ходов
            UpdateHint(); //Обновляем подсказку
        }

        // Метод обновления подсказки
        private void UpdateHint()
        {
            // Если нет ходов, то подсказка что игра окончена
            if (labelCurrentNumber.Text == "Игра окончена")
            {
                labelHint.Text = "Игра окончена. Начните новую игру!";
                return;
            }

            // Подсказка для последовательности
            if (_moves < 25)
            {
                bool canMakeSequence = false;
                for (int i = 0; i < 25; i += 5)
                {
                    int[] row = new int[5];
                    bool isRowEmpty = true; // флаг для проверки, есть ли хотя бы одно число в линии

                    for (int j = 0; j < 5; j++)
                    {
                        if (_gameButtons[i + j].Text != "")
                        {
                            isRowEmpty = false;
                            row[j] = int.Parse(_gameButtons[i + j].Text);
                        }
                        else
                        {
                            row[j] = 0; // Замените на 0 или другое значение
                        }
                    }

                    if (!isRowEmpty)
                    {
                        //проверка возможности добавления последовательности в горизонтальном направлении
                        for (int j = 0; j < 5; j++)
                        {
                            if (row[j] == 0)
                            {
                                row[j] = _currentNumber; // временно добавим число
                                Array.Sort(row);
                                if (row[0] != 0 && row[0] == row[1] - 1 && row[1] == row[2] - 1 && row[2] == row[3] - 1 && row[3] == row[4] - 1)
                                {
                                    canMakeSequence = true;
                                    break;
                                }
                                row[j] = 0;
                            }
                        }
                        if (canMakeSequence)
                            break;
                    }
                }

                if (!canMakeSequence)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int[] column = new int[5];
                        bool isColumnEmpty = true;

                        for (int j = 0; j < 5; j++)
                        {
                            if (_gameButtons[i + (j * 5)].Text != "")
                            {
                                isColumnEmpty = false;
                                column[j] = int.Parse(_gameButtons[i + (j * 5)].Text);
                            }
                            else
                            {
                                column[j] = 0;
                            }
                        }
                        if (!isColumnEmpty)
                        {
                            //проверка возможности добавления последовательности в вертикальном направлении
                            for (int j = 0; j < 5; j++)
                            {
                                if (column[j] == 0)
                                {
                                    column[j] = _currentNumber;
                                    Array.Sort(column);
                                    if (column[0] != 0 && column[0] == column[1] - 1 && column[1] == column[2] - 1 && column[2] == column[3] - 1 && column[3] == column[4] - 1)
                                    {
                                        canMakeSequence = true;
                                        break;
                                    }
                                    column[j] = 0;
                                }
                            }
                            if (canMakeSequence)
                                break;
                        }

                    }
                }


                //Подсказка для набора из одинаковых чисел
                bool canMakeSame = false;
                for (int i = 0; i < 25; i += 5)
                {
                    int[] row = new int[5];
                    bool isRowEmpty = true;

                    for (int j = 0; j < 5; j++)
                    {
                        if (_gameButtons[i + j].Text != "")
                        {
                            isRowEmpty = false;
                            row[j] = int.Parse(_gameButtons[i + j].Text);
                        }
                        else
                        {
                            row[j] = 0;
                        }
                    }

                    if (!isRowEmpty)
                    {
                        //проверка возможности добавления набора из одинаковых чисел в горизонтальном направлении
                        for (int j = 0; j < 5; j++)
                        {
                            if (row[j] == 0)
                            {
                                row[j] = _currentNumber;
                                if (row[0] == row[1] && row[1] == row[2] && row[2] == row[3] && row[3] == row[4])
                                {
                                    canMakeSame = true;
                                    break;
                                }
                                row[j] = 0;
                            }
                        }
                        if (canMakeSame)
                            break;
                    }

                }

                if (!canMakeSame)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int[] column = new int[5];
                        bool isColumnEmpty = true;
                        for (int j = 0; j < 5; j++)
                        {
                            if (_gameButtons[i + (j * 5)].Text != "")
                            {
                                isColumnEmpty = false;
                                column[j] = int.Parse(_gameButtons[i + (j * 5)].Text);
                            }
                            else
                            {
                                column[j] = 0;
                            }
                        }
                        if (!isColumnEmpty)
                        {
                            //проверка возможности добавления набора из одинаковых чисел в вертикальном направлении
                            for (int j = 0; j < 5; j++)
                            {
                                if (column[j] == 0)
                                {
                                    column[j] = _currentNumber;
                                    if (column[0] == column[1] && column[1] == column[2] && column[2] == column[3] && column[3] == column[4])
                                    {
                                        canMakeSame = true;
                                        break;
                                    }
                                    column[j] = 0;
                                }
                            }
                            if (canMakeSame)
                                break;
                        }
                    }
                }


                if (canMakeSequence)
                {
                    labelHint.Text = "Попробуйте собрать последовательность";
                }
                else if (canMakeSame)
                {
                    labelHint.Text = "Попробуйте собрать набор из одинаковых чисел";
                }
                else
                {
                    labelHint.Text = "Поместите число на поле";
                }
            }
        }
        // Метод обработки нажатия на кнопку игрового поля
        private void button_Click(object sender, EventArgs e)
        {
            if (_gameOver) // Если игра окончена, ничего не делаем
                return;

            Button button = (Button)sender; // Получаем нажатую кнопку
            if (button.Text == "") // Если кнопка пуста
            {
                button.Text = _currentNumber.ToString(); // Размещаем число на кнопке
                button.Enabled = false; // Блокируем кнопку
                _placedNumbers.Add(_currentNumber); // Добавляем в список размещенных чисел
                GetRandomNumber(); // Получаем следующее число
                CalculateScore(); // Обновляем счет
            }

            if (_moves == 25 && labelCurrentNumber.Text != "Игра окончена")
            {
                GameOver();
            }
        }
        // Метод подсчета очков
        private void CalculateScore()
        {
            _score = 0; // Сбрасываем счет
            // Проверка на горизонтальные линии
            for (int i = 0; i < 25; i += 5)
            {
                if (_gameButtons[i].Text != "" && _gameButtons[i + 1].Text != "" && _gameButtons[i + 2].Text != "" && _gameButtons[i + 3].Text != "" && _gameButtons[i + 4].Text != "")
                {
                    int[] row = new int[5];
                    for (int j = 0; j < 5; j++)
                    {
                        row[j] = int.Parse(_gameButtons[i + j].Text);
                    }
                    _score += CalculateLineScore(row);
                }
            }

            // Проверка на вертикальные линии
            for (int i = 0; i < 5; i++)
            {
                if (_gameButtons[i].Text != "" && _gameButtons[i + 5].Text != "" && _gameButtons[i + 10].Text != "" && _gameButtons[i + 15].Text != "" && _gameButtons[i + 20].Text != "")
                {
                    int[] column = new int[5];
                    for (int j = 0; j < 5; j++)
                    {
                        column[j] = int.Parse(_gameButtons[i + (j * 5)].Text);
                    }
                    _score += CalculateLineScore(column);
                }
            }
            labelScore.Text = $"Очки: {_score}"; // Обновляем метку счета
        }

        // Метод расчета очков для одной линии
        private int CalculateLineScore(int[] line)
        {
            Array.Sort(line); // Сортируем линию для проверки на последовательности

            if (line[0] == line[1] - 1 && line[1] == line[2] - 1 && line[2] == line[3] - 1 && line[3] == line[4] - 1)
            {
                //Условие для последовательности
                return 20;
            }
            else if (line[0] == line[1] && line[1] == line[2] && line[2] == line[3] && line[3] == line[4])
            {
                //Условие для набора из одинаковых чисел
                return 50;
            }
            return 0; // Если нет совпадений, возвращаем 0
        }

        // Метод обработки нажатия на кнопку "Новая игра"
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            InitializeGame(); // Инициализируем новую игру
        }

        // Метод завершения игры
        private void GameOver()
        {
            _gameOver = true; // Устанавливаем флаг завершения игры
            labelGameOver.Text = $"Игра окончена! Ваш счет: {_score}"; // Выводим сообщение об окончании игры и итоговый счет
            foreach (var button in _gameButtons)
            {
                button.Enabled = false; // Блокируем кнопки
            }
        }
    }
}