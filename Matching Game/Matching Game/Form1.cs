using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class Form1 : Form
    {
        //firstClicked указывает на первый элемент управления меткой,
        //который нажимает игрок, но он будет равен нулю, если игрок
        //еще не нажимал на метку
        Label firstClicked = null;
        //secondClicked указывает на второй элемент
        //управления меткой, который нажимает игрок
        Label secondClicked = null;
        //Использование объекта Random для появления рандомных значков для квадратиков
        Random random = new Random();
        //Каждая из этих букв представляет собой значок шрифта Webdings,
        //и каждый значок появляется в этом списке дважды
        List<string> icons = new List<string>()//отслеживание объектов различного типа
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "c","c", "n", "n", "*","*", "$", "$", "#", "#",
            "%", "%", ";", ";", ":", ":", "&", "&", "~", "~", "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();//заполнение игровой дойски значками
        }

        private void AssignIconsToSquares()//случайные значки из списка
        {
            //В панели TableLayoutPanel есть 16 меток,
            //а в списке значков -16 значков, поэтому значок выбирается
            //случайным образом из списка
            //и добавляется к каждой метке
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;//преобразование control
                                                   //в метку с именем iconLabel 
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];//присваивание свойству текст
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);//удаление из списка значка, добавленного в форму
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            //Таймер включается только после того, как
            //игроку будут показаны два несовпадающих значка,
            //поэтому не обращайте внимания на щелчки, если таймер запущен

            if (timer1.Enabled == true)
                return;
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                //Если метка, на которую был сделан щелчок, черная,
                //игрок нажал на значок, который уже был
                //показан - проигнорируйте щелчок
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                //Если значение firstClicked равно null,
                //это первый значок в паре, по которому щелкнул игрок,
                //поэтому установите значение firstClicked на метку,
                //по которой щелкнул игрок, измените ее цвет на черный и верните
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                //Если игрок заходит так далеко, значит, таймер не запущен,
                //а значение firstClicked не равно нулю, так что, должно быть,
                //это второй значок, на который игрок нажал,
                //установив его цвет на черный
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                CheckForWinner();
                //Если игрок нажал на два одинаковых значка, оставьте их черными и сбросьте
                //первый и второй щелчки, чтобы игрок мог нажать на другой значок

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                //Если игрок зашел так далеко, значит,
                //он нажал на две разные иконки, поэтому
                //запустите таймер (который подождет три четверти секунды,
                //а затем скроет иконки).
                timer1.Start();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //stop the timer
            timer1.Stop();
            //Скрыть оба значка
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            //Сбросьте значения firstClicked и secondClicked,
            //чтобы при следующем нажатии на метку
            //программа знала, что это был первый щелчок
            firstClicked = null;
            secondClicked = null;
        }
        private void CheckForWinner()
        {
            //Проверка цвета значка каждой метки, чтобы он совпадал с фоном
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }

            }
            System.Console.Beep();
            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
