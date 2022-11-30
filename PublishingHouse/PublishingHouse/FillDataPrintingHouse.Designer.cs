
namespace PublishingHouse
{
    partial class FillDataPrintingHouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FillDataPrintingHouse));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.saveInputButton = new System.Windows.Forms.Button();
            this.houseTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.streetTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.phoneNumberTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputNameLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.typesStreetComboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.typesOfStateComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(653, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backTab
            // 
            this.backTab.Image = ((System.Drawing.Image)(resources.GetObject("backTab.Image")));
            this.backTab.Name = "backTab";
            this.backTab.Size = new System.Drawing.Size(85, 24);
            this.backTab.Text = "Назад";
            this.backTab.Click += new System.EventHandler(this.backTab_Click);
            // 
            // saveInputButton
            // 
            this.saveInputButton.Location = new System.Drawing.Point(351, 434);
            this.saveInputButton.Name = "saveInputButton";
            this.saveInputButton.Size = new System.Drawing.Size(262, 66);
            this.saveInputButton.TabIndex = 43;
            this.saveInputButton.Text = "Сохранить введённые данные";
            this.saveInputButton.UseVisualStyleBackColor = true;
            this.saveInputButton.Click += new System.EventHandler(this.saveInputButton_Click);
            // 
            // houseTextBox
            // 
            this.houseTextBox.Location = new System.Drawing.Point(400, 375);
            this.houseTextBox.MaxLength = 7;
            this.houseTextBox.Name = "houseTextBox";
            this.houseTextBox.Size = new System.Drawing.Size(213, 27);
            this.houseTextBox.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(351, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 20);
            this.label12.TabIndex = 41;
            this.label12.Text = "Дом:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(416, 336);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 20);
            this.label13.TabIndex = 40;
            this.label13.Text = "Введите номер дома";
            // 
            // streetTextBox
            // 
            this.streetTextBox.Location = new System.Drawing.Point(400, 277);
            this.streetTextBox.MaxLength = 30;
            this.streetTextBox.Name = "streetTextBox";
            this.streetTextBox.Size = new System.Drawing.Size(213, 27);
            this.streetTextBox.TabIndex = 39;
            this.streetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.streetTextBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(339, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Улица:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(400, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "Введите название улицы";
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(400, 81);
            this.cityTextBox.MaxLength = 30;
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(213, 27);
            this.cityTextBox.TabIndex = 36;
            this.cityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stateTextBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "Город:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(395, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "Введите название города";
            // 
            // stateTextBox
            // 
            this.stateTextBox.Location = new System.Drawing.Point(90, 473);
            this.stateTextBox.MaxLength = 30;
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(208, 27);
            this.stateTextBox.TabIndex = 33;
            this.stateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stateTextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 473);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Субъект:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 434);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Введите название субъекта";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(90, 277);
            this.emailTextBox.MaxLength = 64;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(208, 27);
            this.emailTextBox.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Почта:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Введите электронную почту";
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Location = new System.Drawing.Point(90, 179);
            this.phoneNumberTextBox.Mask = "+7-###-###-##-##";
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(208, 27);
            this.phoneNumberTextBox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Номер:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Введите номер телефона типографии";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(111, 81);
            this.nameTextBox.MaxLength = 30;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(187, 27);
            this.nameTextBox.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Название:";
            // 
            // inputNameLabel
            // 
            this.inputNameLabel.AutoSize = true;
            this.inputNameLabel.Location = new System.Drawing.Point(56, 42);
            this.inputNameLabel.Name = "inputNameLabel";
            this.inputNameLabel.Size = new System.Drawing.Size(223, 20);
            this.inputNameLabel.TabIndex = 22;
            this.inputNameLabel.Text = "Введите название типографии";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(417, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 20);
            this.label14.TabIndex = 44;
            this.label14.Text = "Выберите тип улицы";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(351, 179);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 20);
            this.label15.TabIndex = 45;
            this.label15.Text = "Тип:";
            // 
            // typesStreetComboBox
            // 
            this.typesStreetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typesStreetComboBox.FormattingEnabled = true;
            this.typesStreetComboBox.Items.AddRange(new object[] {
            "Улица",
            "Аллея",
            "Бульвар",
            "Линия",
            "Набережная",
            "Переулок",
            "Проезд",
            "Проспект",
            "Проулок",
            "Спуск",
            "Съезд",
            "Тупик",
            "Шоссе"});
            this.typesStreetComboBox.Location = new System.Drawing.Point(400, 179);
            this.typesStreetComboBox.Name = "typesStreetComboBox";
            this.typesStreetComboBox.Size = new System.Drawing.Size(213, 28);
            this.typesStreetComboBox.TabIndex = 46;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(90, 336);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(171, 20);
            this.label16.TabIndex = 47;
            this.label16.Text = "Выберите тип субъекта";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(32, 375);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 20);
            this.label17.TabIndex = 48;
            this.label17.Text = "Тип:";
            // 
            // typesOfStateComboBox
            // 
            this.typesOfStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typesOfStateComboBox.FormattingEnabled = true;
            this.typesOfStateComboBox.Items.AddRange(new object[] {
            "Область",
            "Автономная область",
            "Автономный округ",
            "Край",
            "Республика"});
            this.typesOfStateComboBox.Location = new System.Drawing.Point(90, 375);
            this.typesOfStateComboBox.Name = "typesOfStateComboBox";
            this.typesOfStateComboBox.Size = new System.Drawing.Size(208, 28);
            this.typesOfStateComboBox.TabIndex = 49;
            // 
            // FillDataPrintingHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 523);
            this.Controls.Add(this.typesOfStateComboBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.typesStreetComboBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.saveInputButton);
            this.Controls.Add(this.houseTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.streetTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputNameLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FillDataPrintingHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод данных о типографии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FillDataPrintingHouse_FormClosing);
            this.Load += new System.EventHandler(this.FillDataPrintingHouse_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.Button saveInputButton;
        private System.Windows.Forms.TextBox houseTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox streetTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox phoneNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label inputNameLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox typesStreetComboBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox typesOfStateComboBox;
    }
}