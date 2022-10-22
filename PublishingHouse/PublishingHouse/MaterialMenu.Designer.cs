
namespace PublishingHouse
{
    partial class MaterialMenu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialMenu));
            this.materialDataGridView = new System.Windows.Forms.DataGridView();
            this.materialGroupBox = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataGridView)).BeginInit();
            this.materialGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialDataGridView
            // 
            this.materialDataGridView.AllowUserToAddRows = false;
            this.materialDataGridView.AllowUserToResizeColumns = false;
            this.materialDataGridView.AllowUserToResizeRows = false;
            this.materialDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialDataGridView.Location = new System.Drawing.Point(12, 30);
            this.materialDataGridView.Name = "materialDataGridView";
            this.materialDataGridView.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.materialDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.materialDataGridView.RowHeadersVisible = false;
            this.materialDataGridView.RowHeadersWidth = 51;
            this.materialDataGridView.RowTemplate.Height = 29;
            this.materialDataGridView.Size = new System.Drawing.Size(659, 371);
            this.materialDataGridView.TabIndex = 0;
            // 
            // materialGroupBox
            // 
            this.materialGroupBox.Controls.Add(this.addButton);
            this.materialGroupBox.Controls.Add(this.costTextBox);
            this.materialGroupBox.Controls.Add(this.label8);
            this.materialGroupBox.Controls.Add(this.label9);
            this.materialGroupBox.Controls.Add(this.heightTextBox);
            this.materialGroupBox.Controls.Add(this.label7);
            this.materialGroupBox.Controls.Add(this.widthTextBox);
            this.materialGroupBox.Controls.Add(this.label6);
            this.materialGroupBox.Controls.Add(this.label5);
            this.materialGroupBox.Controls.Add(this.label3);
            this.materialGroupBox.Controls.Add(this.colorComboBox);
            this.materialGroupBox.Controls.Add(this.label4);
            this.materialGroupBox.Controls.Add(this.label2);
            this.materialGroupBox.Controls.Add(this.typeComboBox);
            this.materialGroupBox.Controls.Add(this.label1);
            this.materialGroupBox.Location = new System.Drawing.Point(693, 30);
            this.materialGroupBox.Name = "materialGroupBox";
            this.materialGroupBox.Size = new System.Drawing.Size(379, 466);
            this.materialGroupBox.TabIndex = 1;
            this.materialGroupBox.TabStop = false;
            this.materialGroupBox.Text = "Работа с данными";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 387);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(157, 43);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Добавить материал";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(98, 334);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(275, 27);
            this.costTextBox.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(284, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Введите стоимость материала в рублях";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Стоимость:";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(272, 250);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(107, 27);
            this.heightTextBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Длина:";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(80, 250);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(107, 27);
            this.widthTextBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ширина:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Введите размер материала в мм:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выберите цвет из списка или введите вручную";
            // 
            // colorComboBox
            // 
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Items.AddRange(new object[] {
            "Белый",
            "Голубой",
            "Жёлтый",
            "Зелёный",
            "Красный",
            "Оранжевый",
            "Серый",
            "Синий",
            "Фиолетовый",
            "Чёрный"});
            this.colorComboBox.Location = new System.Drawing.Point(144, 158);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(229, 28);
            this.colorComboBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Цвет материала:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите тип из списка или введите вручную";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Бумага для глубокой печати",
            "Газетная бумага",
            "Глянцевая бумага",
            "Матовая бумага",
            "Мелованная бумага",
            "Обложечная бумага",
            "Офсетная бумага",
            "Типографская бумага",
            "Форзацная бумага"});
            this.typeComboBox.Location = new System.Drawing.Point(144, 73);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(229, 28);
            this.typeComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип материала:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backTab
            // 
            this.backTab.Name = "backTab";
            this.backTab.Size = new System.Drawing.Size(65, 24);
            this.backTab.Text = "Назад";
            this.backTab.Click += new System.EventHandler(this.backTab_Click);
            // 
            // MaterialMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 508);
            this.Controls.Add(this.materialGroupBox);
            this.Controls.Add(this.materialDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MaterialMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Материалы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialMenu_FormClosing);
            this.Load += new System.EventHandler(this.MaterialMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materialDataGridView)).EndInit();
            this.materialGroupBox.ResumeLayout(false);
            this.materialGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView materialDataGridView;
        private System.Windows.Forms.GroupBox materialGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}