using System;
using System.Windows.Forms;

namespace Встречают_по_одежке
{
    public partial class Form1 : Form
    {
        private Label labelFlight;
        private ComboBox comboBoxFlights;
        private Button buttonCalculate;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelFlight = new System.Windows.Forms.Label();
            this.comboBoxFlights = new System.Windows.Forms.ComboBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.listBoxTickets = new System.Windows.Forms.ListBox();
            this.labelClass = new System.Windows.Forms.Label();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFlight
            // 
            this.labelFlight.AutoSize = true;
            this.labelFlight.Location = new System.Drawing.Point(12, 15);
            this.labelFlight.Name = "labelFlight";
            this.labelFlight.Size = new System.Drawing.Size(128, 20);
            this.labelFlight.TabIndex = 0;
            this.labelFlight.Text = "Выбор одежды:";
            // 
            // comboBoxFlights
            // 
            this.comboBoxFlights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFlights.Location = new System.Drawing.Point(457, 12);
            this.comboBoxFlights.Name = "comboBoxFlights";
            this.comboBoxFlights.Size = new System.Drawing.Size(200, 28);
            this.comboBoxFlights.TabIndex = 1;
            this.comboBoxFlights.SelectedIndexChanged += new System.EventHandler(this.comboBoxFlights_SelectedIndexChanged);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(12, 301);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(651, 41);
            this.buttonCalculate.TabIndex = 9;
            this.buttonCalculate.Text = "Добавить в корзину";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // listBoxTickets
            // 
            this.listBoxTickets.FormattingEnabled = true;
            this.listBoxTickets.ItemHeight = 20;
            this.listBoxTickets.Location = new System.Drawing.Point(12, 352);
            this.listBoxTickets.Name = "listBoxTickets";
            this.listBoxTickets.Size = new System.Drawing.Size(650, 224);
            this.listBoxTickets.TabIndex = 15;
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(12, 55);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(69, 20);
            this.labelClass.TabIndex = 2;
            this.labelClass.Text = "Размер:";
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClass.Location = new System.Drawing.Point(457, 52);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(200, 28);
            this.comboBoxClass.TabIndex = 3;
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Location = new System.Drawing.Point(457, 105);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(199, 175);
            this.pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProduct.TabIndex = 16;
            this.pictureBoxProduct.TabStop = false;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(22, 105);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(51, 20);
            this.labelDescription.TabIndex = 17;
            this.labelDescription.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 586);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(652, 41);
            this.button1.TabIndex = 18;
            this.button1.Text = "Купить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(675, 639);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.pictureBoxProduct);
            this.Controls.Add(this.listBoxTickets);
            this.Controls.Add(this.labelFlight);
            this.Controls.Add(this.comboBoxFlights);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(this.buttonCalculate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Встречаю по одежке";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ListBox listBoxTickets;
        private Label labelClass;
        private ComboBox comboBoxClass;
        private PictureBox pictureBoxProduct;
        private Label labelDescription;
        private Button button1;
    }
}
