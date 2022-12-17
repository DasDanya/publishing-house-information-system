
namespace PublishingHouse
{
    partial class PrintingHouseMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintingHouseMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.printingHouseDataGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.inputButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.workWithPrHouseGroupBox = new System.Windows.Forms.GroupBox();
            this.resetSelectButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchDataLabel = new System.Windows.Forms.Label();
            this.ordersTreeView = new System.Windows.Forms.TreeView();
            this.fashionButton = new System.Windows.Forms.Button();
            this.columnsComboBox = new System.Windows.Forms.ComboBox();
            this.columnsLabel = new System.Windows.Forms.Label();
            this.changeButton = new System.Windows.Forms.Button();
            this.resetChangeButton = new System.Windows.Forms.Button();
            this.infoChangeLabel = new System.Windows.Forms.Label();
            this.selectForChangeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchOrdersButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.processingTab = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTab = new System.Windows.Forms.ToolStripMenuItem();
            this.selectTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingHouseDataGridView)).BeginInit();
            this.workWithPrHouseGroupBox.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1363, 28);
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
            // printingHouseDataGridView
            // 
            this.printingHouseDataGridView.AllowUserToAddRows = false;
            this.printingHouseDataGridView.AllowUserToDeleteRows = false;
            this.printingHouseDataGridView.AllowUserToResizeColumns = false;
            this.printingHouseDataGridView.AllowUserToResizeRows = false;
            this.printingHouseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.printingHouseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.printingHouseDataGridView.Location = new System.Drawing.Point(13, 32);
            this.printingHouseDataGridView.Name = "printingHouseDataGridView";
            this.printingHouseDataGridView.RowHeadersVisible = false;
            this.printingHouseDataGridView.RowHeadersWidth = 51;
            this.printingHouseDataGridView.RowTemplate.Height = 50;
            this.printingHouseDataGridView.Size = new System.Drawing.Size(1338, 305);
            this.printingHouseDataGridView.TabIndex = 1;
            this.printingHouseDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.printingHouseDataGridView_ColumnStateChanged);
            // 
            // Select
            // 
            this.Select.HeaderText = "Выбрать";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.ToolTipText = "\"\"";
            this.Select.Width = 125;
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(6, 64);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(211, 57);
            this.inputButton.TabIndex = 22;
            this.inputButton.Text = "Ввести данные";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 152);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(211, 57);
            this.addButton.TabIndex = 21;
            this.addButton.Text = "Добавить типографию";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // workWithPrHouseGroupBox
            // 
            this.workWithPrHouseGroupBox.Controls.Add(this.resetSelectButton);
            this.workWithPrHouseGroupBox.Controls.Add(this.selectAllButton);
            this.workWithPrHouseGroupBox.Controls.Add(this.searchTextBox);
            this.workWithPrHouseGroupBox.Controls.Add(this.searchDataLabel);
            this.workWithPrHouseGroupBox.Controls.Add(this.ordersTreeView);
            this.workWithPrHouseGroupBox.Controls.Add(this.fashionButton);
            this.workWithPrHouseGroupBox.Controls.Add(this.columnsComboBox);
            this.workWithPrHouseGroupBox.Controls.Add(this.columnsLabel);
            this.workWithPrHouseGroupBox.Controls.Add(this.changeButton);
            this.workWithPrHouseGroupBox.Controls.Add(this.resetChangeButton);
            this.workWithPrHouseGroupBox.Controls.Add(this.infoChangeLabel);
            this.workWithPrHouseGroupBox.Controls.Add(this.selectForChangeButton);
            this.workWithPrHouseGroupBox.Controls.Add(this.deleteButton);
            this.workWithPrHouseGroupBox.Controls.Add(this.searchOrdersButton);
            this.workWithPrHouseGroupBox.Controls.Add(this.infoLabel);
            this.workWithPrHouseGroupBox.Controls.Add(this.menuStrip2);
            this.workWithPrHouseGroupBox.Controls.Add(this.addButton);
            this.workWithPrHouseGroupBox.Controls.Add(this.inputButton);
            this.workWithPrHouseGroupBox.Location = new System.Drawing.Point(35, 360);
            this.workWithPrHouseGroupBox.Name = "workWithPrHouseGroupBox";
            this.workWithPrHouseGroupBox.Size = new System.Drawing.Size(704, 224);
            this.workWithPrHouseGroupBox.TabIndex = 23;
            this.workWithPrHouseGroupBox.TabStop = false;
            this.workWithPrHouseGroupBox.Text = "Работа с данными";
            // 
            // resetSelectButton
            // 
            this.resetSelectButton.Location = new System.Drawing.Point(7, 152);
            this.resetSelectButton.Name = "resetSelectButton";
            this.resetSelectButton.Size = new System.Drawing.Size(210, 57);
            this.resetSelectButton.TabIndex = 36;
            this.resetSelectButton.Text = "Отменить выбор строк";
            this.resetSelectButton.UseVisualStyleBackColor = true;
            this.resetSelectButton.Visible = false;
            this.resetSelectButton.Click += new System.EventHandler(this.resetSelectButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(6, 64);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(211, 56);
            this.selectAllButton.TabIndex = 24;
            this.selectAllButton.Text = "Выбрать всё";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Visible = false;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(378, 189);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(233, 27);
            this.searchTextBox.TabIndex = 35;
            this.searchTextBox.Visible = false;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // searchDataLabel
            // 
            this.searchDataLabel.AutoSize = true;
            this.searchDataLabel.Location = new System.Drawing.Point(378, 162);
            this.searchDataLabel.Name = "searchDataLabel";
            this.searchDataLabel.Size = new System.Drawing.Size(233, 20);
            this.searchDataLabel.TabIndex = 34;
            this.searchDataLabel.Text = "Данные для поиска типографии";
            this.searchDataLabel.Visible = false;
            // 
            // ordersTreeView
            // 
            this.ordersTreeView.Location = new System.Drawing.Point(7, 64);
            this.ordersTreeView.Name = "ordersTreeView";
            this.ordersTreeView.Size = new System.Drawing.Size(116, 154);
            this.ordersTreeView.TabIndex = 23;
            this.ordersTreeView.Visible = false;
            // 
            // fashionButton
            // 
            this.fashionButton.Location = new System.Drawing.Point(128, 162);
            this.fashionButton.Name = "fashionButton";
            this.fashionButton.Size = new System.Drawing.Size(211, 56);
            this.fashionButton.TabIndex = 33;
            this.fashionButton.Text = "Мода типографий";
            this.fashionButton.UseVisualStyleBackColor = true;
            this.fashionButton.Visible = false;
            this.fashionButton.Click += new System.EventHandler(this.fashionButton_Click);
            // 
            // columnsComboBox
            // 
            this.columnsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnsComboBox.FormattingEnabled = true;
            this.columnsComboBox.Location = new System.Drawing.Point(378, 92);
            this.columnsComboBox.Name = "columnsComboBox";
            this.columnsComboBox.Size = new System.Drawing.Size(236, 28);
            this.columnsComboBox.TabIndex = 32;
            this.columnsComboBox.Visible = false;
            // 
            // columnsLabel
            // 
            this.columnsLabel.AutoSize = true;
            this.columnsLabel.Location = new System.Drawing.Point(378, 64);
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(236, 20);
            this.columnsLabel.TabIndex = 31;
            this.columnsLabel.Text = "Столбец для поиска типографии";
            this.columnsLabel.Visible = false;
            // 
            // changeButton
            // 
            this.changeButton.Enabled = false;
            this.changeButton.Location = new System.Drawing.Point(440, 152);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(211, 57);
            this.changeButton.TabIndex = 30;
            this.changeButton.Text = "Изменить данные о типографии";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // resetChangeButton
            // 
            this.resetChangeButton.Location = new System.Drawing.Point(224, 152);
            this.resetChangeButton.Name = "resetChangeButton";
            this.resetChangeButton.Size = new System.Drawing.Size(210, 57);
            this.resetChangeButton.TabIndex = 29;
            this.resetChangeButton.Text = "Отменить добавление/изменение";
            this.resetChangeButton.UseVisualStyleBackColor = true;
            this.resetChangeButton.Click += new System.EventHandler(this.resetChangeButton_Click);
            // 
            // infoChangeLabel
            // 
            this.infoChangeLabel.AutoSize = true;
            this.infoChangeLabel.Location = new System.Drawing.Point(440, 129);
            this.infoChangeLabel.Name = "infoChangeLabel";
            this.infoChangeLabel.Size = new System.Drawing.Size(0, 20);
            this.infoChangeLabel.TabIndex = 28;
            // 
            // selectForChangeButton
            // 
            this.selectForChangeButton.Location = new System.Drawing.Point(223, 64);
            this.selectForChangeButton.Name = "selectForChangeButton";
            this.selectForChangeButton.Size = new System.Drawing.Size(211, 57);
            this.selectForChangeButton.TabIndex = 27;
            this.selectForChangeButton.Text = "Выбрать для изменения";
            this.selectForChangeButton.UseVisualStyleBackColor = true;
            this.selectForChangeButton.Click += new System.EventHandler(this.selectForChangeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(440, 64);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(211, 57);
            this.deleteButton.TabIndex = 26;
            this.deleteButton.Text = "Удалить типографии";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // searchOrdersButton
            // 
            this.searchOrdersButton.Location = new System.Drawing.Point(128, 64);
            this.searchOrdersButton.Name = "searchOrdersButton";
            this.searchOrdersButton.Size = new System.Drawing.Size(211, 57);
            this.searchOrdersButton.TabIndex = 25;
            this.searchOrdersButton.Text = "Поиск заказов";
            this.searchOrdersButton.UseVisualStyleBackColor = true;
            this.searchOrdersButton.Visible = false;
            this.searchOrdersButton.Click += new System.EventHandler(this.searchOrdersButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(6, 129);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 20);
            this.infoLabel.TabIndex = 24;
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
            this.menuStrip2.Size = new System.Drawing.Size(698, 28);
            this.menuStrip2.TabIndex = 0;
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
            // PrintingHouseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 596);
            this.Controls.Add(this.workWithPrHouseGroupBox);
            this.Controls.Add(this.printingHouseDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PrintingHouseMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Типографии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintingHouseMenu_FormClosing);
            this.Load += new System.EventHandler(this.PrintingHouseMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingHouseDataGridView)).EndInit();
            this.workWithPrHouseGroupBox.ResumeLayout(false);
            this.workWithPrHouseGroupBox.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.DataGridView printingHouseDataGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.GroupBox workWithPrHouseGroupBox;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem processingTab;
        private System.Windows.Forms.ToolStripMenuItem searchTab;
        private System.Windows.Forms.TreeView ordersTreeView;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button searchOrdersButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button selectForChangeButton;
        private System.Windows.Forms.Button resetChangeButton;
        private System.Windows.Forms.Label infoChangeLabel;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.ComboBox columnsComboBox;
        private System.Windows.Forms.Label columnsLabel;
        private System.Windows.Forms.Button fashionButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchDataLabel;
        private System.Windows.Forms.Button resetSelectButton;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.ToolStripMenuItem selectTab;
    }
}