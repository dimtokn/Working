using System.Windows.Forms;
using System;

namespace CombinatoricsCalculator
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtN;
        private TextBox txtK;
        private ComboBox cmbOperation;
        private Button btnCalculate;
        private Label lblResult;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtK = new System.Windows.Forms.TextBox();
            this.cmbOperation = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(30, 31);
            this.txtN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(148, 26);
            this.txtN.TabIndex = 0;
            // 
            // txtK
            // 
            this.txtK.Location = new System.Drawing.Point(30, 92);
            this.txtK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(148, 26);
            this.txtK.TabIndex = 1;
            // 
            // cmbOperation
            // 
            this.cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperation.Location = new System.Drawing.Point(30, 154);
            this.cmbOperation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbOperation.Name = "cmbOperation";
            this.cmbOperation.Size = new System.Drawing.Size(298, 28);
            this.cmbOperation.TabIndex = 2;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(28, 216);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(150, 46);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(30, 277);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(450, 46);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Результат: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 385);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.txtK);
            this.Controls.Add(this.cmbOperation);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Комбинаторика";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
