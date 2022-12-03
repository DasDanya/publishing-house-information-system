﻿
namespace PublishingHouse
{
    partial class AdminMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.employeeTab = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.dataForSearchLabel = new System.Windows.Forms.Label();
            this.columnsComboBox = new System.Windows.Forms.ComboBox();
            this.columnLabel = new System.Windows.Forms.Label();
            this.changeLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.resetaddChangeButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.selectForChangeButton = new System.Windows.Forms.Button();
            this.addLabel = new System.Windows.Forms.Label();
            this.addEmployeeButton = new System.Windows.Forms.Button();
            this.inputButton = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.processingTab = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTab = new System.Windows.Forms.ToolStripMenuItem();
            this.employeePictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // employeeTab
            // 
            this.employeeTab.Image = ((System.Drawing.Image)(resources.GetObject("employeeTab.Image")));
            this.employeeTab.Name = "employeeTab";
            this.employeeTab.Size = new System.Drawing.Size(125, 24);
            this.employeeTab.Text = "Сотрудники";
            // 
            // employeeDataGridView
            // 
            this.employeeDataGridView.AllowUserToAddRows = false;
            this.employeeDataGridView.AllowUserToResizeColumns = false;
            this.employeeDataGridView.AllowUserToResizeRows = false;
            this.employeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.employeeDataGridView.Location = new System.Drawing.Point(20, 59);
            this.employeeDataGridView.Name = "employeeDataGridView";
            this.employeeDataGridView.RowHeadersVisible = false;
            this.employeeDataGridView.RowHeadersWidth = 51;
            this.employeeDataGridView.RowTemplate.Height = 50;
            this.employeeDataGridView.Size = new System.Drawing.Size(867, 347);
            this.employeeDataGridView.TabIndex = 1;
            this.employeeDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeeDataGridView_CellClick);
            this.employeeDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.employeeDataGridView_ColumnStateChanged);
            // 
            // Select
            // 
            this.Select.HeaderText = "Выбрать";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.Width = 125;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchTextBox);
            this.groupBox1.Controls.Add(this.dataForSearchLabel);
            this.groupBox1.Controls.Add(this.columnsComboBox);
            this.groupBox1.Controls.Add(this.columnLabel);
            this.groupBox1.Controls.Add(this.changeLabel);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.resetaddChangeButton);
            this.groupBox1.Controls.Add(this.changeButton);
            this.groupBox1.Controls.Add(this.selectForChangeButton);
            this.groupBox1.Controls.Add(this.addLabel);
            this.groupBox1.Controls.Add(this.addEmployeeButton);
            this.groupBox1.Controls.Add(this.inputButton);
            this.groupBox1.Controls.Add(this.menuStrip2);
            this.groupBox1.Location = new System.Drawing.Point(20, 443);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(6, 166);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(271, 27);
            this.searchTextBox.TabIndex = 12;
            this.searchTextBox.Visible = false;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // dataForSearchLabel
            // 
            this.dataForSearchLabel.AutoSize = true;
            this.dataForSearchLabel.Location = new System.Drawing.Point(28, 144);
            this.dataForSearchLabel.Name = "dataForSearchLabel";
            this.dataForSearchLabel.Size = new System.Drawing.Size(228, 20);
            this.dataForSearchLabel.TabIndex = 11;
            this.dataForSearchLabel.Text = "Данные для поиска сотрудника";
            this.dataForSearchLabel.Visible = false;
            // 
            // columnsComboBox
            // 
            this.columnsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnsComboBox.FormattingEnabled = true;
            this.columnsComboBox.Location = new System.Drawing.Point(6, 86);
            this.columnsComboBox.Name = "columnsComboBox";
            this.columnsComboBox.Size = new System.Drawing.Size(271, 28);
            this.columnsComboBox.TabIndex = 10;
            this.columnsComboBox.Visible = false;
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Location = new System.Drawing.Point(28, 63);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(231, 20);
            this.columnLabel.TabIndex = 9;
            this.columnLabel.Text = "Столбец для поиска сотрудника";
            this.columnLabel.Visible = false;
            // 
            // changeLabel
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.Location = new System.Drawing.Point(588, 121);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(209, 20);
            this.changeLabel.TabIndex = 8;
            this.changeLabel.Text = "Вы можете изменить запись";
            this.changeLabel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(560, 63);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(271, 49);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Удалить сотрудника";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // resetaddChangeButton
            // 
            this.resetaddChangeButton.Location = new System.Drawing.Point(283, 144);
            this.resetaddChangeButton.Name = "resetaddChangeButton";
            this.resetaddChangeButton.Size = new System.Drawing.Size(271, 49);
            this.resetaddChangeButton.TabIndex = 6;
            this.resetaddChangeButton.Text = "Отменить добавление/изменение";
            this.resetaddChangeButton.UseVisualStyleBackColor = true;
            this.resetaddChangeButton.Click += new System.EventHandler(this.resetaddChangeButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(560, 144);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(271, 49);
            this.changeButton.TabIndex = 5;
            this.changeButton.Text = "Изменить данные о сотруднике";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // selectForChangeButton
            // 
            this.selectForChangeButton.Location = new System.Drawing.Point(283, 63);
            this.selectForChangeButton.Name = "selectForChangeButton";
            this.selectForChangeButton.Size = new System.Drawing.Size(271, 49);
            this.selectForChangeButton.TabIndex = 4;
            this.selectForChangeButton.Text = "Выбрать для изменения";
            this.selectForChangeButton.UseVisualStyleBackColor = true;
            this.selectForChangeButton.Click += new System.EventHandler(this.selectForChangeButton_Click);
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Location = new System.Drawing.Point(35, 121);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(207, 20);
            this.addLabel.TabIndex = 3;
            this.addLabel.Text = "Вы можете добавить запись";
            this.addLabel.Visible = false;
            // 
            // addEmployeeButton
            // 
            this.addEmployeeButton.Location = new System.Drawing.Point(6, 144);
            this.addEmployeeButton.Name = "addEmployeeButton";
            this.addEmployeeButton.Size = new System.Drawing.Size(271, 49);
            this.addEmployeeButton.TabIndex = 1;
            this.addEmployeeButton.Text = "Добавить сотрудника";
            this.addEmployeeButton.UseVisualStyleBackColor = true;
            this.addEmployeeButton.Click += new System.EventHandler(this.addEmployeeButton_Click);
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(6, 63);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(271, 49);
            this.inputButton.TabIndex = 0;
            this.inputButton.Text = "Ввести данные";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processingTab,
            this.searchTab});
            this.menuStrip2.Location = new System.Drawing.Point(3, 23);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(837, 28);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // processingTab
            // 
            this.processingTab.Image = ((System.Drawing.Image)(resources.GetObject("processingTab.Image")));
            this.processingTab.Name = "processingTab";
            this.processingTab.Size = new System.Drawing.Size(119, 24);
            this.processingTab.Text = "Обработка";
            this.processingTab.Click += new System.EventHandler(this.processingTab_Click);
            // 
            // searchTab
            // 
            this.searchTab.Image = ((System.Drawing.Image)(resources.GetObject("searchTab.Image")));
            this.searchTab.Name = "searchTab";
            this.searchTab.Size = new System.Drawing.Size(86, 24);
            this.searchTab.Text = "Поиск";
            this.searchTab.Click += new System.EventHandler(this.searchTab_Click);
            // 
            // employeePictureBox
            // 
            this.employeePictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.employeePictureBox.Location = new System.Drawing.Point(907, 59);
            this.employeePictureBox.Name = "employeePictureBox";
            this.employeePictureBox.Size = new System.Drawing.Size(236, 236);
            this.employeePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.employeePictureBox.TabIndex = 3;
            this.employeePictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(961, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фото сотрудника:";
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 658);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.employeePictureBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.employeeDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AdminMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню ИС для администратора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminMenu_FormClosing);
            this.Load += new System.EventHandler(this.AdminMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem employeeTab;
        private System.Windows.Forms.DataGridView employeeDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.PictureBox employeePictureBox;
        private System.Windows.Forms.Button addEmployeeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem processingTab;
        private System.Windows.Forms.ToolStripMenuItem searchTab;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.Label changeLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button resetaddChangeButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button selectForChangeButton;
        private System.Windows.Forms.ComboBox columnsComboBox;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label dataForSearchLabel;
    }
}