
namespace PublishingHouse
{
    partial class EmployeeMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fashionButton = new System.Windows.Forms.Button();
            this.searchEmployeeOrdersButton = new System.Windows.Forms.Button();
            this.ordersTreeView = new System.Windows.Forms.TreeView();
            this.resetSelectAllButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.resetSearchDataButton = new System.Windows.Forms.Button();
            this.searchDataButton = new System.Windows.Forms.Button();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.selectDatelabel = new System.Windows.Forms.Label();
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
            this.selectTab = new System.Windows.Forms.ToolStripMenuItem();
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
            this.backTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 28);
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
            // employeeDataGridView
            // 
            this.employeeDataGridView.AllowUserToAddRows = false;
            this.employeeDataGridView.AllowUserToDeleteRows = false;
            this.employeeDataGridView.AllowUserToResizeColumns = false;
            this.employeeDataGridView.AllowUserToResizeRows = false;
            this.employeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.employeeDataGridView.Location = new System.Drawing.Point(20, 36);
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
            this.groupBox1.Controls.Add(this.fashionButton);
            this.groupBox1.Controls.Add(this.searchEmployeeOrdersButton);
            this.groupBox1.Controls.Add(this.ordersTreeView);
            this.groupBox1.Controls.Add(this.resetSelectAllButton);
            this.groupBox1.Controls.Add(this.selectAllButton);
            this.groupBox1.Controls.Add(this.resetSearchDataButton);
            this.groupBox1.Controls.Add(this.searchDataButton);
            this.groupBox1.Controls.Add(this.toLabel);
            this.groupBox1.Controls.Add(this.fromLabel);
            this.groupBox1.Controls.Add(this.endDateTimePicker);
            this.groupBox1.Controls.Add(this.startDateTimePicker);
            this.groupBox1.Controls.Add(this.selectDatelabel);
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
            this.groupBox1.Location = new System.Drawing.Point(20, 413);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1123, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
            // 
            // fashionButton
            // 
            this.fashionButton.Location = new System.Drawing.Point(908, 144);
            this.fashionButton.Name = "fashionButton";
            this.fashionButton.Size = new System.Drawing.Size(197, 49);
            this.fashionButton.TabIndex = 23;
            this.fashionButton.Text = "Мода сотрудников";
            this.fashionButton.UseVisualStyleBackColor = true;
            this.fashionButton.Visible = false;
            this.fashionButton.Click += new System.EventHandler(this.fashionButton_Click);
            // 
            // searchEmployeeOrdersButton
            // 
            this.searchEmployeeOrdersButton.Location = new System.Drawing.Point(908, 63);
            this.searchEmployeeOrdersButton.Name = "searchEmployeeOrdersButton";
            this.searchEmployeeOrdersButton.Size = new System.Drawing.Size(197, 49);
            this.searchEmployeeOrdersButton.TabIndex = 22;
            this.searchEmployeeOrdersButton.Text = "Поиск заказов";
            this.searchEmployeeOrdersButton.UseVisualStyleBackColor = true;
            this.searchEmployeeOrdersButton.Visible = false;
            this.searchEmployeeOrdersButton.Click += new System.EventHandler(this.searchEmployeeOrdersButton_Click);
            // 
            // ordersTreeView
            // 
            this.ordersTreeView.Location = new System.Drawing.Point(692, 63);
            this.ordersTreeView.Name = "ordersTreeView";
            this.ordersTreeView.Size = new System.Drawing.Size(210, 130);
            this.ordersTreeView.TabIndex = 21;
            this.ordersTreeView.Visible = false;
            // 
            // resetSelectAllButton
            // 
            this.resetSelectAllButton.Location = new System.Drawing.Point(6, 144);
            this.resetSelectAllButton.Name = "resetSelectAllButton";
            this.resetSelectAllButton.Size = new System.Drawing.Size(271, 49);
            this.resetSelectAllButton.TabIndex = 20;
            this.resetSelectAllButton.Text = "Отменить выбор строк";
            this.resetSelectAllButton.UseVisualStyleBackColor = true;
            this.resetSelectAllButton.Visible = false;
            this.resetSelectAllButton.Click += new System.EventHandler(this.resetSelectAllButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(6, 63);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(271, 51);
            this.selectAllButton.TabIndex = 19;
            this.selectAllButton.Text = "Выбрать всё";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Visible = false;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // resetSearchDataButton
            // 
            this.resetSearchDataButton.Location = new System.Drawing.Point(528, 144);
            this.resetSearchDataButton.Name = "resetSearchDataButton";
            this.resetSearchDataButton.Size = new System.Drawing.Size(158, 49);
            this.resetSearchDataButton.TabIndex = 5;
            this.resetSearchDataButton.Text = "Сбросить поиск";
            this.resetSearchDataButton.UseVisualStyleBackColor = true;
            this.resetSearchDataButton.Visible = false;
            this.resetSearchDataButton.Click += new System.EventHandler(this.resetSearchDataButton_Click);
            // 
            // searchDataButton
            // 
            this.searchDataButton.Location = new System.Drawing.Point(316, 144);
            this.searchDataButton.Name = "searchDataButton";
            this.searchDataButton.Size = new System.Drawing.Size(158, 49);
            this.searchDataButton.TabIndex = 18;
            this.searchDataButton.Text = "Поиск по дате";
            this.searchDataButton.UseVisualStyleBackColor = true;
            this.searchDataButton.Visible = false;
            this.searchDataButton.Click += new System.EventHandler(this.searchDataButton_Click);
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(490, 89);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(32, 20);
            this.toLabel.TabIndex = 17;
            this.toLabel.Text = "По:";
            this.toLabel.Visible = false;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(289, 89);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(21, 20);
            this.fromLabel.TabIndex = 16;
            this.fromLabel.Text = "С:";
            this.fromLabel.Visible = false;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(528, 86);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(158, 27);
            this.endDateTimePicker.TabIndex = 15;
            this.endDateTimePicker.Visible = false;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(316, 86);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(158, 27);
            this.startDateTimePicker.TabIndex = 14;
            this.startDateTimePicker.Visible = false;
            // 
            // selectDatelabel
            // 
            this.selectDatelabel.AutoSize = true;
            this.selectDatelabel.Location = new System.Drawing.Point(416, 63);
            this.selectDatelabel.Name = "selectDatelabel";
            this.selectDatelabel.Size = new System.Drawing.Size(138, 20);
            this.selectDatelabel.TabIndex = 13;
            this.selectDatelabel.Text = "Период рождения";
            this.selectDatelabel.Visible = false;
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
            this.changeLabel.Size = new System.Drawing.Size(0, 20);
            this.changeLabel.TabIndex = 8;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(560, 63);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(271, 49);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Удалить сотрудников";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
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
            this.changeButton.Enabled = false;
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
            this.addLabel.Size = new System.Drawing.Size(0, 20);
            this.addLabel.TabIndex = 3;
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
            this.searchTab,
            this.selectTab});
            this.menuStrip2.Location = new System.Drawing.Point(3, 23);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1117, 28);
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
            // selectTab
            // 
            this.selectTab.Image = ((System.Drawing.Image)(resources.GetObject("selectTab.Image")));
            this.selectTab.Name = "selectTab";
            this.selectTab.Size = new System.Drawing.Size(90, 24);
            this.selectTab.Text = "Выбор";
            this.selectTab.Click += new System.EventHandler(this.selectTab_Click);
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
            this.label1.Location = new System.Drawing.Point(959, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фото сотрудника:";
            // 
            // EmployeeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 637);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.employeePictureBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.employeeDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "EmployeeMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сотрудники";
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
        private System.Windows.Forms.ToolStripMenuItem backTab;
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
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label selectDatelabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Button resetSearchDataButton;
        private System.Windows.Forms.Button searchDataButton;
        private System.Windows.Forms.Button resetSelectAllButton;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.ToolStripMenuItem selectTab;
        private System.Windows.Forms.Button searchEmployeeOrdersButton;
        private System.Windows.Forms.TreeView ordersTreeView;
        private System.Windows.Forms.Button fashionButton;
    }
}