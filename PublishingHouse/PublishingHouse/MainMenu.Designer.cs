
namespace PublishingHouse
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.Tabs = new System.Windows.Forms.MenuStrip();
            this.employeeTab = new System.Windows.Forms.ToolStripMenuItem();
            this.materialTab = new System.Windows.Forms.ToolStripMenuItem();
            this.printingHouseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.customersTab = new System.Windows.Forms.ToolStripMenuItem();
            this.productTab = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingDataGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.inputDataButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resetSearchButton = new System.Windows.Forms.Button();
            this.toDataLabel = new System.Windows.Forms.Label();
            this.fromDataLabel = new System.Windows.Forms.Label();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateComboBox = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.searchDateButton = new System.Windows.Forms.Button();
            this.searchNumbersButton = new System.Windows.Forms.Button();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.fromLabel = new System.Windows.Forms.Label();
            this.numberComboBox = new System.Windows.Forms.ComboBox();
            this.intLabel = new System.Windows.Forms.Label();
            this.stringTextBox = new System.Windows.Forms.TextBox();
            this.stringDataLabel = new System.Windows.Forms.Label();
            this.stringComboBox = new System.Windows.Forms.ComboBox();
            this.stringColumnLabel = new System.Windows.Forms.Label();
            this.changeLabel = new System.Windows.Forms.Label();
            this.completeBookingButton = new System.Windows.Forms.Button();
            this.resetSelectRowsButton = new System.Windows.Forms.Button();
            this.selectAllRowsButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.resetAddOrChangeButton = new System.Windows.Forms.Button();
            this.selectForChangeButton = new System.Windows.Forms.Button();
            this.addLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.processingTab = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTab = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Tabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeTab,
            this.materialTab,
            this.printingHouseTab,
            this.customersTab,
            this.productTab});
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.Size = new System.Drawing.Size(1291, 28);
            this.Tabs.TabIndex = 0;
            this.Tabs.Text = "menuStrip1";
            // 
            // employeeTab
            // 
            this.employeeTab.Image = ((System.Drawing.Image)(resources.GetObject("employeeTab.Image")));
            this.employeeTab.Name = "employeeTab";
            this.employeeTab.Size = new System.Drawing.Size(125, 24);
            this.employeeTab.Text = "Сотрудники";
            this.employeeTab.Click += new System.EventHandler(this.employeeTab_Click);
            // 
            // materialTab
            // 
            this.materialTab.Image = ((System.Drawing.Image)(resources.GetObject("materialTab.Image")));
            this.materialTab.Name = "materialTab";
            this.materialTab.Size = new System.Drawing.Size(123, 24);
            this.materialTab.Text = "Материалы";
            this.materialTab.Click += new System.EventHandler(this.materialTab_Click);
            // 
            // printingHouseTab
            // 
            this.printingHouseTab.Image = ((System.Drawing.Image)(resources.GetObject("printingHouseTab.Image")));
            this.printingHouseTab.Name = "printingHouseTab";
            this.printingHouseTab.Size = new System.Drawing.Size(129, 24);
            this.printingHouseTab.Text = "Типографии";
            this.printingHouseTab.Click += new System.EventHandler(this.printingHouseTab_Click);
            // 
            // customersTab
            // 
            this.customersTab.Image = ((System.Drawing.Image)(resources.GetObject("customersTab.Image")));
            this.customersTab.Name = "customersTab";
            this.customersTab.Size = new System.Drawing.Size(114, 24);
            this.customersTab.Text = "Заказчики";
            this.customersTab.Click += new System.EventHandler(this.customersTab_Click);
            // 
            // productTab
            // 
            this.productTab.Image = ((System.Drawing.Image)(resources.GetObject("productTab.Image")));
            this.productTab.Name = "productTab";
            this.productTab.Size = new System.Drawing.Size(188, 24);
            this.productTab.Text = "Печатная продукция";
            this.productTab.Click += new System.EventHandler(this.productTab_Click);
            // 
            // bookingDataGridView
            // 
            this.bookingDataGridView.AllowUserToAddRows = false;
            this.bookingDataGridView.AllowUserToDeleteRows = false;
            this.bookingDataGridView.AllowUserToResizeColumns = false;
            this.bookingDataGridView.AllowUserToResizeRows = false;
            this.bookingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.bookingDataGridView.Location = new System.Drawing.Point(12, 47);
            this.bookingDataGridView.Name = "bookingDataGridView";
            this.bookingDataGridView.RowHeadersVisible = false;
            this.bookingDataGridView.RowHeadersWidth = 51;
            this.bookingDataGridView.RowTemplate.Height = 50;
            this.bookingDataGridView.Size = new System.Drawing.Size(1267, 308);
            this.bookingDataGridView.TabIndex = 1;
            this.bookingDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.bookingDataGridView_ColumnStateChanged);
            // 
            // Select
            // 
            this.Select.HeaderText = "Выбрать";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.Width = 125;
            // 
            // inputDataButton
            // 
            this.inputDataButton.Location = new System.Drawing.Point(6, 66);
            this.inputDataButton.Name = "inputDataButton";
            this.inputDataButton.Size = new System.Drawing.Size(207, 53);
            this.inputDataButton.TabIndex = 2;
            this.inputDataButton.Text = "Сформировать заказ";
            this.inputDataButton.UseVisualStyleBackColor = true;
            this.inputDataButton.Click += new System.EventHandler(this.inputDataButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resetSearchButton);
            this.groupBox1.Controls.Add(this.toDataLabel);
            this.groupBox1.Controls.Add(this.fromDataLabel);
            this.groupBox1.Controls.Add(this.toDateTimePicker);
            this.groupBox1.Controls.Add(this.fromDateTimePicker);
            this.groupBox1.Controls.Add(this.dateComboBox);
            this.groupBox1.Controls.Add(this.dateLabel);
            this.groupBox1.Controls.Add(this.searchDateButton);
            this.groupBox1.Controls.Add(this.searchNumbersButton);
            this.groupBox1.Controls.Add(this.generateReportButton);
            this.groupBox1.Controls.Add(this.fromTextBox);
            this.groupBox1.Controls.Add(this.toLabel);
            this.groupBox1.Controls.Add(this.toTextBox);
            this.groupBox1.Controls.Add(this.fromLabel);
            this.groupBox1.Controls.Add(this.numberComboBox);
            this.groupBox1.Controls.Add(this.intLabel);
            this.groupBox1.Controls.Add(this.stringTextBox);
            this.groupBox1.Controls.Add(this.stringDataLabel);
            this.groupBox1.Controls.Add(this.stringComboBox);
            this.groupBox1.Controls.Add(this.stringColumnLabel);
            this.groupBox1.Controls.Add(this.changeLabel);
            this.groupBox1.Controls.Add(this.completeBookingButton);
            this.groupBox1.Controls.Add(this.resetSelectRowsButton);
            this.groupBox1.Controls.Add(this.selectAllRowsButton);
            this.groupBox1.Controls.Add(this.changeButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.resetAddOrChangeButton);
            this.groupBox1.Controls.Add(this.selectForChangeButton);
            this.groupBox1.Controls.Add(this.addLabel);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.inputDataButton);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Location = new System.Drawing.Point(12, 375);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1267, 226);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
            // 
            // resetSearchButton
            // 
            this.resetSearchButton.Location = new System.Drawing.Point(1086, 66);
            this.resetSearchButton.Name = "resetSearchButton";
            this.resetSearchButton.Size = new System.Drawing.Size(175, 136);
            this.resetSearchButton.TabIndex = 33;
            this.resetSearchButton.Text = "Сброс поиска";
            this.resetSearchButton.UseVisualStyleBackColor = true;
            this.resetSearchButton.Visible = false;
            this.resetSearchButton.Click += new System.EventHandler(this.resetSearchButton_Click);
            // 
            // toDataLabel
            // 
            this.toDataLabel.AutoSize = true;
            this.toDataLabel.Location = new System.Drawing.Point(768, 182);
            this.toDataLabel.Name = "toDataLabel";
            this.toDataLabel.Size = new System.Drawing.Size(29, 20);
            this.toDataLabel.TabIndex = 32;
            this.toDataLabel.Text = "По";
            this.toDataLabel.Visible = false;
            // 
            // fromDataLabel
            // 
            this.fromDataLabel.AutoSize = true;
            this.fromDataLabel.Location = new System.Drawing.Point(771, 151);
            this.fromDataLabel.Name = "fromDataLabel";
            this.fromDataLabel.Size = new System.Drawing.Size(18, 20);
            this.fromDataLabel.TabIndex = 31;
            this.fromDataLabel.Text = "С";
            this.fromDataLabel.Visible = false;
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Location = new System.Drawing.Point(803, 178);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(225, 27);
            this.toDateTimePicker.TabIndex = 30;
            this.toDateTimePicker.Visible = false;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Location = new System.Drawing.Point(803, 147);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(225, 27);
            this.fromDateTimePicker.TabIndex = 29;
            this.fromDateTimePicker.Visible = false;
            // 
            // dateComboBox
            // 
            this.dateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateComboBox.FormattingEnabled = true;
            this.dateComboBox.Location = new System.Drawing.Point(764, 89);
            this.dateComboBox.Name = "dateComboBox";
            this.dateComboBox.Size = new System.Drawing.Size(264, 28);
            this.dateComboBox.TabIndex = 28;
            this.dateComboBox.Visible = false;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(822, 66);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(148, 20);
            this.dateLabel.TabIndex = 27;
            this.dateLabel.Text = "Столбец для поиска";
            this.dateLabel.Visible = false;
            // 
            // searchDateButton
            // 
            this.searchDateButton.Location = new System.Drawing.Point(607, 151);
            this.searchDateButton.Name = "searchDateButton";
            this.searchDateButton.Size = new System.Drawing.Size(146, 51);
            this.searchDateButton.TabIndex = 26;
            this.searchDateButton.Text = "Поиск по дате";
            this.searchDateButton.UseVisualStyleBackColor = true;
            this.searchDateButton.Visible = false;
            // 
            // searchNumbersButton
            // 
            this.searchNumbersButton.Location = new System.Drawing.Point(607, 64);
            this.searchNumbersButton.Name = "searchNumbersButton";
            this.searchNumbersButton.Size = new System.Drawing.Size(146, 53);
            this.searchNumbersButton.TabIndex = 25;
            this.searchNumbersButton.Text = "Поиск числовых данных";
            this.searchNumbersButton.UseVisualStyleBackColor = true;
            this.searchNumbersButton.Visible = false;
            this.searchNumbersButton.Click += new System.EventHandler(this.searchNumbersButton_Click);
            // 
            // generateReportButton
            // 
            this.generateReportButton.Location = new System.Drawing.Point(1086, 151);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(175, 51);
            this.generateReportButton.TabIndex = 24;
            this.generateReportButton.Text = "Сформировать отчёт";
            this.generateReportButton.UseVisualStyleBackColor = true;
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(330, 175);
            this.fromTextBox.MaxLength = 8;
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(125, 27);
            this.fromTextBox.TabIndex = 23;
            this.fromTextBox.Visible = false;
            this.fromTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fromTextBox_KeyPress);
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(515, 154);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(28, 20);
            this.toLabel.TabIndex = 22;
            this.toLabel.Text = "До";
            this.toLabel.Visible = false;
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(469, 175);
            this.toTextBox.MaxLength = 8;
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(125, 27);
            this.toTextBox.TabIndex = 21;
            this.toTextBox.Visible = false;
            this.toTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fromTextBox_KeyPress);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(377, 154);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(26, 20);
            this.fromLabel.TabIndex = 20;
            this.fromLabel.Text = "От";
            this.fromLabel.Visible = false;
            // 
            // numberComboBox
            // 
            this.numberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberComboBox.FormattingEnabled = true;
            this.numberComboBox.Location = new System.Drawing.Point(330, 89);
            this.numberComboBox.Name = "numberComboBox";
            this.numberComboBox.Size = new System.Drawing.Size(264, 28);
            this.numberComboBox.TabIndex = 19;
            this.numberComboBox.Visible = false;
            // 
            // intLabel
            // 
            this.intLabel.AutoSize = true;
            this.intLabel.Location = new System.Drawing.Point(392, 66);
            this.intLabel.Name = "intLabel";
            this.intLabel.Size = new System.Drawing.Size(148, 20);
            this.intLabel.TabIndex = 18;
            this.intLabel.Text = "Столбец для поиска";
            this.intLabel.Visible = false;
            // 
            // stringTextBox
            // 
            this.stringTextBox.Location = new System.Drawing.Point(6, 175);
            this.stringTextBox.Name = "stringTextBox";
            this.stringTextBox.Size = new System.Drawing.Size(264, 27);
            this.stringTextBox.TabIndex = 17;
            this.stringTextBox.Visible = false;
            this.stringTextBox.TextChanged += new System.EventHandler(this.stringTextBox_TextChanged);
            // 
            // stringDataLabel
            // 
            this.stringDataLabel.AutoSize = true;
            this.stringDataLabel.Location = new System.Drawing.Point(43, 152);
            this.stringDataLabel.Name = "stringDataLabel";
            this.stringDataLabel.Size = new System.Drawing.Size(194, 20);
            this.stringDataLabel.TabIndex = 16;
            this.stringDataLabel.Text = "Данные для поиска заказа";
            this.stringDataLabel.Visible = false;
            // 
            // stringComboBox
            // 
            this.stringComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stringComboBox.FormattingEnabled = true;
            this.stringComboBox.Location = new System.Drawing.Point(6, 89);
            this.stringComboBox.Name = "stringComboBox";
            this.stringComboBox.Size = new System.Drawing.Size(264, 28);
            this.stringComboBox.TabIndex = 15;
            this.stringComboBox.Visible = false;
            // 
            // stringColumnLabel
            // 
            this.stringColumnLabel.AutoSize = true;
            this.stringColumnLabel.Location = new System.Drawing.Point(68, 66);
            this.stringColumnLabel.Name = "stringColumnLabel";
            this.stringColumnLabel.Size = new System.Drawing.Size(148, 20);
            this.stringColumnLabel.TabIndex = 14;
            this.stringColumnLabel.Text = "Столбец для поиска";
            this.stringColumnLabel.Visible = false;
            // 
            // changeLabel
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.Location = new System.Drawing.Point(546, 129);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(0, 20);
            this.changeLabel.TabIndex = 13;
            // 
            // completeBookingButton
            // 
            this.completeBookingButton.Location = new System.Drawing.Point(1086, 66);
            this.completeBookingButton.Name = "completeBookingButton";
            this.completeBookingButton.Size = new System.Drawing.Size(175, 53);
            this.completeBookingButton.TabIndex = 12;
            this.completeBookingButton.Text = "Выполнить заказ";
            this.completeBookingButton.UseVisualStyleBackColor = true;
            this.completeBookingButton.Click += new System.EventHandler(this.completeBookingButton_Click);
            // 
            // resetSelectRowsButton
            // 
            this.resetSelectRowsButton.Location = new System.Drawing.Point(816, 152);
            this.resetSelectRowsButton.Name = "resetSelectRowsButton";
            this.resetSelectRowsButton.Size = new System.Drawing.Size(207, 53);
            this.resetSelectRowsButton.TabIndex = 11;
            this.resetSelectRowsButton.Text = "Отменить выбор строк";
            this.resetSelectRowsButton.UseVisualStyleBackColor = true;
            this.resetSelectRowsButton.Click += new System.EventHandler(this.resetSelectRowsButton_Click);
            // 
            // selectAllRowsButton
            // 
            this.selectAllRowsButton.Location = new System.Drawing.Point(816, 66);
            this.selectAllRowsButton.Name = "selectAllRowsButton";
            this.selectAllRowsButton.Size = new System.Drawing.Size(207, 53);
            this.selectAllRowsButton.TabIndex = 10;
            this.selectAllRowsButton.Text = "Выбрать всё";
            this.selectAllRowsButton.UseVisualStyleBackColor = true;
            this.selectAllRowsButton.Click += new System.EventHandler(this.selectAllRowsButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Enabled = false;
            this.changeButton.Location = new System.Drawing.Point(546, 152);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(207, 53);
            this.changeButton.TabIndex = 9;
            this.changeButton.Text = "Изменить данные о заказе";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(546, 66);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(207, 53);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Удалить заказ";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // resetAddOrChangeButton
            // 
            this.resetAddOrChangeButton.Location = new System.Drawing.Point(276, 152);
            this.resetAddOrChangeButton.Name = "resetAddOrChangeButton";
            this.resetAddOrChangeButton.Size = new System.Drawing.Size(207, 53);
            this.resetAddOrChangeButton.TabIndex = 7;
            this.resetAddOrChangeButton.Text = "Отменить добавление/ изменение";
            this.resetAddOrChangeButton.UseVisualStyleBackColor = true;
            this.resetAddOrChangeButton.Click += new System.EventHandler(this.resetAddOrChangeButton_Click);
            // 
            // selectForChangeButton
            // 
            this.selectForChangeButton.Location = new System.Drawing.Point(276, 66);
            this.selectForChangeButton.Name = "selectForChangeButton";
            this.selectForChangeButton.Size = new System.Drawing.Size(207, 53);
            this.selectForChangeButton.TabIndex = 6;
            this.selectForChangeButton.Text = "Выбрать для изменения";
            this.selectForChangeButton.UseVisualStyleBackColor = true;
            this.selectForChangeButton.Click += new System.EventHandler(this.selectForChangeButton_Click);
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Location = new System.Drawing.Point(6, 129);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(0, 20);
            this.addLabel.TabIndex = 5;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 152);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(207, 53);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Добавить заказ";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processingTab,
            this.searchTab});
            this.menuStrip1.Location = new System.Drawing.Point(3, 23);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1261, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
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
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 613);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bookingDataGridView);
            this.Controls.Add(this.Tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Tabs;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информационная система издательства";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Tabs.ResumeLayout(false);
            this.Tabs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Tabs;
        private System.Windows.Forms.ToolStripMenuItem employeeTab;
        private System.Windows.Forms.ToolStripMenuItem materialTab;
        private System.Windows.Forms.ToolStripMenuItem printingHouseTab;
        private System.Windows.Forms.ToolStripMenuItem customersTab;
        private System.Windows.Forms.ToolStripMenuItem productTab;
        private System.Windows.Forms.DataGridView bookingDataGridView;
        private System.Windows.Forms.Button inputDataButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem processingTab;
        private System.Windows.Forms.ToolStripMenuItem searchTab;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.Button selectForChangeButton;
        private System.Windows.Forms.Button resetAddOrChangeButton;
        private System.Windows.Forms.Label changeLabel;
        private System.Windows.Forms.Button completeBookingButton;
        private System.Windows.Forms.Button resetSelectRowsButton;
        private System.Windows.Forms.Button selectAllRowsButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label stringColumnLabel;
        private System.Windows.Forms.ComboBox stringComboBox;
        private System.Windows.Forms.TextBox stringTextBox;
        private System.Windows.Forms.Label stringDataLabel;
        private System.Windows.Forms.ComboBox numberComboBox;
        private System.Windows.Forms.Label intLabel;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.ComboBox dateComboBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button searchDateButton;
        private System.Windows.Forms.Button searchNumbersButton;
        private System.Windows.Forms.Label toDataLabel;
        private System.Windows.Forms.Label fromDataLabel;
        private System.Windows.Forms.Button resetSearchButton;
    }
}

