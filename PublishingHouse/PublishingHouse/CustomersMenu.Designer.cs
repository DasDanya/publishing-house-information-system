
namespace PublishingHouse
{
    partial class CustomersMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.customersDataGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeCustomerLabel = new System.Windows.Forms.Label();
            this.addCustomerLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.dataAboutCustomerLabel = new System.Windows.Forms.Label();
            this.columnsComboBox = new System.Windows.Forms.ComboBox();
            this.columnLabel = new System.Windows.Forms.Label();
            this.fashionCustomersButton = new System.Windows.Forms.Button();
            this.getOrdersButton = new System.Windows.Forms.Button();
            this.ordersTreeView = new System.Windows.Forms.TreeView();
            this.resetSelectRowsButton = new System.Windows.Forms.Button();
            this.selectAllRowsButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.resetAddOrChangeButton = new System.Windows.Forms.Button();
            this.selectForChangeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.inputDataButton = new System.Windows.Forms.Button();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.processingTab = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTab = new System.Windows.Forms.ToolStripMenuItem();
            this.selectTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
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
            // customersDataGridView
            // 
            this.customersDataGridView.AllowUserToAddRows = false;
            this.customersDataGridView.AllowUserToDeleteRows = false;
            this.customersDataGridView.AllowUserToResizeColumns = false;
            this.customersDataGridView.AllowUserToResizeRows = false;
            this.customersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.customersDataGridView.Location = new System.Drawing.Point(12, 31);
            this.customersDataGridView.Name = "customersDataGridView";
            this.customersDataGridView.RowHeadersVisible = false;
            this.customersDataGridView.RowHeadersWidth = 51;
            this.customersDataGridView.RowTemplate.Height = 50;
            this.customersDataGridView.Size = new System.Drawing.Size(776, 285);
            this.customersDataGridView.TabIndex = 1;
            this.customersDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.customersDataGridView_ColumnStateChanged);
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
            this.groupBox1.Controls.Add(this.changeCustomerLabel);
            this.groupBox1.Controls.Add(this.addCustomerLabel);
            this.groupBox1.Controls.Add(this.searchTextBox);
            this.groupBox1.Controls.Add(this.dataAboutCustomerLabel);
            this.groupBox1.Controls.Add(this.columnsComboBox);
            this.groupBox1.Controls.Add(this.columnLabel);
            this.groupBox1.Controls.Add(this.fashionCustomersButton);
            this.groupBox1.Controls.Add(this.getOrdersButton);
            this.groupBox1.Controls.Add(this.ordersTreeView);
            this.groupBox1.Controls.Add(this.resetSelectRowsButton);
            this.groupBox1.Controls.Add(this.selectAllRowsButton);
            this.groupBox1.Controls.Add(this.changeButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.resetAddOrChangeButton);
            this.groupBox1.Controls.Add(this.selectForChangeButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.inputDataButton);
            this.groupBox1.Controls.Add(this.menuStrip3);
            this.groupBox1.Location = new System.Drawing.Point(13, 347);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 190);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
            // 
            // changeCustomerLabel
            // 
            this.changeCustomerLabel.AutoSize = true;
            this.changeCustomerLabel.Location = new System.Drawing.Point(498, 112);
            this.changeCustomerLabel.Name = "changeCustomerLabel";
            this.changeCustomerLabel.Size = new System.Drawing.Size(0, 20);
            this.changeCustomerLabel.TabIndex = 18;
            // 
            // addCustomerLabel
            // 
            this.addCustomerLabel.AutoSize = true;
            this.addCustomerLabel.Location = new System.Drawing.Point(15, 112);
            this.addCustomerLabel.Name = "addCustomerLabel";
            this.addCustomerLabel.Size = new System.Drawing.Size(0, 20);
            this.addCustomerLabel.TabIndex = 17;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(492, 157);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(224, 27);
            this.searchTextBox.TabIndex = 16;
            this.searchTextBox.Visible = false;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // dataAboutCustomerLabel
            // 
            this.dataAboutCustomerLabel.AutoSize = true;
            this.dataAboutCustomerLabel.Location = new System.Drawing.Point(495, 136);
            this.dataAboutCustomerLabel.Name = "dataAboutCustomerLabel";
            this.dataAboutCustomerLabel.Size = new System.Drawing.Size(218, 20);
            this.dataAboutCustomerLabel.TabIndex = 15;
            this.dataAboutCustomerLabel.Text = "Данные для поиска заказчика";
            this.dataAboutCustomerLabel.Visible = false;
            // 
            // columnsComboBox
            // 
            this.columnsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnsComboBox.FormattingEnabled = true;
            this.columnsComboBox.Location = new System.Drawing.Point(492, 84);
            this.columnsComboBox.Name = "columnsComboBox";
            this.columnsComboBox.Size = new System.Drawing.Size(224, 28);
            this.columnsComboBox.TabIndex = 14;
            this.columnsComboBox.Visible = false;
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Location = new System.Drawing.Point(495, 63);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(221, 20);
            this.columnLabel.TabIndex = 13;
            this.columnLabel.Text = "Столбец для поиска заказчика";
            this.columnLabel.Visible = false;
            // 
            // fashionCustomersButton
            // 
            this.fashionCustomersButton.Location = new System.Drawing.Point(249, 136);
            this.fashionCustomersButton.Name = "fashionCustomersButton";
            this.fashionCustomersButton.Size = new System.Drawing.Size(225, 48);
            this.fashionCustomersButton.TabIndex = 12;
            this.fashionCustomersButton.Text = "Мода заказчиков";
            this.fashionCustomersButton.UseVisualStyleBackColor = true;
            this.fashionCustomersButton.Visible = false;
            this.fashionCustomersButton.Click += new System.EventHandler(this.fashionCustomersButton_Click);
            // 
            // getOrdersButton
            // 
            this.getOrdersButton.Location = new System.Drawing.Point(249, 64);
            this.getOrdersButton.Name = "getOrdersButton";
            this.getOrdersButton.Size = new System.Drawing.Size(225, 48);
            this.getOrdersButton.TabIndex = 11;
            this.getOrdersButton.Text = "Получить заказы";
            this.getOrdersButton.UseVisualStyleBackColor = true;
            this.getOrdersButton.Visible = false;
            this.getOrdersButton.Click += new System.EventHandler(this.getOrdersButton_Click);
            // 
            // ordersTreeView
            // 
            this.ordersTreeView.Location = new System.Drawing.Point(6, 63);
            this.ordersTreeView.Name = "ordersTreeView";
            this.ordersTreeView.Size = new System.Drawing.Size(225, 121);
            this.ordersTreeView.TabIndex = 10;
            this.ordersTreeView.Visible = false;
            // 
            // resetSelectRowsButton
            // 
            this.resetSelectRowsButton.Location = new System.Drawing.Point(6, 136);
            this.resetSelectRowsButton.Name = "resetSelectRowsButton";
            this.resetSelectRowsButton.Size = new System.Drawing.Size(225, 48);
            this.resetSelectRowsButton.TabIndex = 9;
            this.resetSelectRowsButton.Text = "Отменить выбор строк";
            this.resetSelectRowsButton.UseVisualStyleBackColor = true;
            this.resetSelectRowsButton.Visible = false;
            this.resetSelectRowsButton.Click += new System.EventHandler(this.resetSelectRowsButton_Click);
            // 
            // selectAllRowsButton
            // 
            this.selectAllRowsButton.Location = new System.Drawing.Point(6, 64);
            this.selectAllRowsButton.Name = "selectAllRowsButton";
            this.selectAllRowsButton.Size = new System.Drawing.Size(225, 48);
            this.selectAllRowsButton.TabIndex = 8;
            this.selectAllRowsButton.Text = "Выбрать всё";
            this.selectAllRowsButton.UseVisualStyleBackColor = true;
            this.selectAllRowsButton.Visible = false;
            this.selectAllRowsButton.Click += new System.EventHandler(this.selectAllRowsButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Enabled = false;
            this.changeButton.Location = new System.Drawing.Point(492, 136);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(225, 48);
            this.changeButton.TabIndex = 7;
            this.changeButton.Text = "Изменить данные о заказчике";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(492, 64);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(225, 48);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Удалить заказчиков";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // resetAddOrChangeButton
            // 
            this.resetAddOrChangeButton.Location = new System.Drawing.Point(249, 136);
            this.resetAddOrChangeButton.Name = "resetAddOrChangeButton";
            this.resetAddOrChangeButton.Size = new System.Drawing.Size(225, 48);
            this.resetAddOrChangeButton.TabIndex = 5;
            this.resetAddOrChangeButton.Text = "Отменить добавление/изменение";
            this.resetAddOrChangeButton.UseVisualStyleBackColor = true;
            this.resetAddOrChangeButton.Click += new System.EventHandler(this.resetAddOrChangeButton_Click);
            // 
            // selectForChangeButton
            // 
            this.selectForChangeButton.Location = new System.Drawing.Point(249, 64);
            this.selectForChangeButton.Name = "selectForChangeButton";
            this.selectForChangeButton.Size = new System.Drawing.Size(225, 48);
            this.selectForChangeButton.TabIndex = 4;
            this.selectForChangeButton.Text = "Выбрать для изменения";
            this.selectForChangeButton.UseVisualStyleBackColor = true;
            this.selectForChangeButton.Click += new System.EventHandler(this.selectForChangeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 136);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(225, 48);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Добавить заказчика";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // inputDataButton
            // 
            this.inputDataButton.Location = new System.Drawing.Point(6, 64);
            this.inputDataButton.Name = "inputDataButton";
            this.inputDataButton.Size = new System.Drawing.Size(225, 48);
            this.inputDataButton.TabIndex = 2;
            this.inputDataButton.Text = "Ввести данные";
            this.inputDataButton.UseVisualStyleBackColor = true;
            this.inputDataButton.Click += new System.EventHandler(this.inputDataButton_Click);
            // 
            // menuStrip3
            // 
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processingTab,
            this.searchTab,
            this.selectTab});
            this.menuStrip3.Location = new System.Drawing.Point(3, 23);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(729, 28);
            this.menuStrip3.TabIndex = 1;
            this.menuStrip3.Text = "menuStrip3";
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
            // CustomersMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customersDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "CustomersMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заказчики";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomersMenu_FormClosing);
            this.Load += new System.EventHandler(this.CustomersMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.DataGridView customersDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem processingTab;
        private System.Windows.Forms.ToolStripMenuItem searchTab;
        private System.Windows.Forms.ToolStripMenuItem selectTab;
        private System.Windows.Forms.Button inputDataButton;
        private System.Windows.Forms.Button selectForChangeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button resetAddOrChangeButton;
        private System.Windows.Forms.Button resetSelectRowsButton;
        private System.Windows.Forms.Button selectAllRowsButton;
        private System.Windows.Forms.Button fashionCustomersButton;
        private System.Windows.Forms.Button getOrdersButton;
        private System.Windows.Forms.TreeView ordersTreeView;
        private System.Windows.Forms.Label dataAboutCustomerLabel;
        private System.Windows.Forms.ComboBox columnsComboBox;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label changeCustomerLabel;
        private System.Windows.Forms.Label addCustomerLabel;
    }
}