using System;
using System.Windows.Forms;

namespace Касса_аэрофлота
{
    public partial class Form1 : Form
    {
        private Label labelFlight;
        private ComboBox comboBoxFlights;
        private Label labelClass;
        private ComboBox comboBoxClass;
        private Label labelAdults;
        private TextBox textBoxAdults;
        private Label labelChildren;
        private TextBox textBoxChildren;
        private CheckBox checkBoxLuggage;
        private Button buttonCalculate;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelFlight = new System.Windows.Forms.Label();
            this.comboBoxFlights = new System.Windows.Forms.ComboBox();
            this.labelClass = new System.Windows.Forms.Label();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.labelAdults = new System.Windows.Forms.Label();
            this.textBoxAdults = new System.Windows.Forms.TextBox();
            this.labelChildren = new System.Windows.Forms.Label();
            this.textBoxChildren = new System.Windows.Forms.TextBox();
            this.checkBoxLuggage = new System.Windows.Forms.CheckBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.checkBoxto = new System.Windows.Forms.CheckBox();
            this.dateTimePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.timePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerReturn = new System.Windows.Forms.DateTimePicker();
            this.timePickerReturn = new System.Windows.Forms.DateTimePicker();
            this.listBoxTickets = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelFlight
            // 
            this.labelFlight.AutoSize = true;
            this.labelFlight.Location = new System.Drawing.Point(12, 15);
            this.labelFlight.Name = "labelFlight";
            this.labelFlight.Size = new System.Drawing.Size(110, 20);
            this.labelFlight.TabIndex = 0;
            this.labelFlight.Text = "Выбор рейса:";
            // 
            // comboBoxFlights
            // 
            this.comboBoxFlights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFlights.Location = new System.Drawing.Point(457, 12);
            this.comboBoxFlights.Name = "comboBoxFlights";
            this.comboBoxFlights.Size = new System.Drawing.Size(200, 28);
            this.comboBoxFlights.TabIndex = 1;
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(12, 55);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(117, 20);
            this.labelClass.TabIndex = 2;
            this.labelClass.Text = "Класс полета:";
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClass.Location = new System.Drawing.Point(457, 52);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(200, 28);
            this.comboBoxClass.TabIndex = 3;
            // 
            // labelAdults
            // 
            this.labelAdults.AutoSize = true;
            this.labelAdults.Location = new System.Drawing.Point(12, 95);
            this.labelAdults.Name = "labelAdults";
            this.labelAdults.Size = new System.Drawing.Size(179, 20);
            this.labelAdults.TabIndex = 4;
            this.labelAdults.Text = "Количество взрослых:";
            // 
            // textBoxAdults
            // 
            this.textBoxAdults.Location = new System.Drawing.Point(457, 95);
            this.textBoxAdults.Name = "textBoxAdults";
            this.textBoxAdults.Size = new System.Drawing.Size(200, 26);
            this.textBoxAdults.TabIndex = 5;
            // 
            // labelChildren
            // 
            this.labelChildren.AutoSize = true;
            this.labelChildren.Location = new System.Drawing.Point(12, 135);
            this.labelChildren.Name = "labelChildren";
            this.labelChildren.Size = new System.Drawing.Size(155, 20);
            this.labelChildren.TabIndex = 6;
            this.labelChildren.Text = "Количество детей:";
            // 
            // textBoxChildren
            // 
            this.textBoxChildren.Location = new System.Drawing.Point(457, 132);
            this.textBoxChildren.Name = "textBoxChildren";
            this.textBoxChildren.Size = new System.Drawing.Size(200, 26);
            this.textBoxChildren.TabIndex = 7;
            // 
            // checkBoxLuggage
            // 
            this.checkBoxLuggage.AutoSize = true;
            this.checkBoxLuggage.Location = new System.Drawing.Point(12, 175);
            this.checkBoxLuggage.Name = "checkBoxLuggage";
            this.checkBoxLuggage.Size = new System.Drawing.Size(160, 24);
            this.checkBoxLuggage.TabIndex = 8;
            this.checkBoxLuggage.Text = "Наличие багажа";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(12, 214);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(645, 41);
            this.buttonCalculate.TabIndex = 9;
            this.buttonCalculate.Text = "Рассчитать стоимость";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // checkBoxto
            // 
            this.checkBoxto.AutoSize = true;
            this.checkBoxto.Location = new System.Drawing.Point(457, 173);
            this.checkBoxto.Name = "checkBoxto";
            this.checkBoxto.Size = new System.Drawing.Size(139, 24);
            this.checkBoxto.TabIndex = 10;
            this.checkBoxto.Text = "Туда-обратно";
            // 
            // dateTimePickerDeparture
            // 
            this.dateTimePickerDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDeparture.Location = new System.Drawing.Point(13, 275);
            this.dateTimePickerDeparture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDeparture.Name = "dateTimePickerDeparture";
            this.dateTimePickerDeparture.Size = new System.Drawing.Size(178, 26);
            this.dateTimePickerDeparture.TabIndex = 11;
            // 
            // timePickerDeparture
            // 
            this.timePickerDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerDeparture.Location = new System.Drawing.Point(13, 311);
            this.timePickerDeparture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timePickerDeparture.Name = "timePickerDeparture";
            this.timePickerDeparture.Size = new System.Drawing.Size(180, 26);
            this.timePickerDeparture.TabIndex = 12;
            this.timePickerDeparture.Value = new System.DateTime(2024, 4, 4, 0, 0, 0, 0);
            // 
            // dateTimePickerReturn
            // 
            this.dateTimePickerReturn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReturn.Location = new System.Drawing.Point(479, 275);
            this.dateTimePickerReturn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerReturn.Name = "dateTimePickerReturn";
            this.dateTimePickerReturn.Size = new System.Drawing.Size(178, 26);
            this.dateTimePickerReturn.TabIndex = 13;
            // 
            // timePickerReturn
            // 
            this.timePickerReturn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerReturn.Location = new System.Drawing.Point(477, 311);
            this.timePickerReturn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timePickerReturn.Name = "timePickerReturn";
            this.timePickerReturn.Size = new System.Drawing.Size(178, 26);
            this.timePickerReturn.TabIndex = 14;
            // 
            // listBoxTickets
            // 
            this.listBoxTickets.FormattingEnabled = true;
            this.listBoxTickets.ItemHeight = 20;
            this.listBoxTickets.Location = new System.Drawing.Point(12, 356);
            this.listBoxTickets.Name = "listBoxTickets";
            this.listBoxTickets.Size = new System.Drawing.Size(650, 224);
            this.listBoxTickets.TabIndex = 15;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(675, 589);
            this.Controls.Add(this.listBoxTickets);
            this.Controls.Add(this.timePickerReturn);
            this.Controls.Add(this.dateTimePickerReturn);
            this.Controls.Add(this.timePickerDeparture);
            this.Controls.Add(this.dateTimePickerDeparture);
            this.Controls.Add(this.checkBoxto);
            this.Controls.Add(this.labelFlight);
            this.Controls.Add(this.comboBoxFlights);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(this.labelAdults);
            this.Controls.Add(this.textBoxAdults);
            this.Controls.Add(this.labelChildren);
            this.Controls.Add(this.textBoxChildren);
            this.Controls.Add(this.checkBoxLuggage);
            this.Controls.Add(this.buttonCalculate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Касса Аэрофлота";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CheckBox checkBoxto;
        private DateTimePicker dateTimePickerDeparture;
        private DateTimePicker timePickerDeparture;
        private DateTimePicker dateTimePickerReturn;
        private DateTimePicker timePickerReturn;
        private ListBox listBoxTickets;
    }
}
