
namespace PublishingHouse
{
    partial class ProductMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.typesProductButton = new System.Windows.Forms.Button();
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.productPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchStringTextBox = new System.Windows.Forms.TextBox();
            this.stringLabel = new System.Windows.Forms.Label();
            this.stringComboBox = new System.Windows.Forms.ComboBox();
            this.secondLabel = new System.Windows.Forms.Label();
            this.resetSearchButton = new System.Windows.Forms.Button();
            this.getNumbersDataButton = new System.Windows.Forms.Button();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.fromLabel = new System.Windows.Forms.Label();
            this.numbersComboBox = new System.Windows.Forms.ComboBox();
            this.firstColumnsLabel = new System.Windows.Forms.Label();
            this.outputAllDataButton = new System.Windows.Forms.Button();
            this.searchOrdersButton = new System.Windows.Forms.Button();
            this.ordersTreeView = new System.Windows.Forms.TreeView();
            this.changeLabel = new System.Windows.Forms.Label();
            this.addLabel = new System.Windows.Forms.Label();
            this.resetSelectRowsButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.resetAddOrChangeButton = new System.Windows.Forms.Button();
            this.selectAllRowsButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.selectForChangeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.inputDataButton = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.processingTab = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1214, 28);
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
            // typesProductButton
            // 
            this.typesProductButton.Location = new System.Drawing.Point(920, 339);
            this.typesProductButton.Name = "typesProductButton";
            this.typesProductButton.Size = new System.Drawing.Size(272, 64);
            this.typesProductButton.TabIndex = 1;
            this.typesProductButton.Text = "Типы печатной продукции";
            this.typesProductButton.UseVisualStyleBackColor = true;
            this.typesProductButton.Click += new System.EventHandler(this.typesProductButton_Click);
            // 
            // productDataGridView
            // 
            this.productDataGridView.AllowUserToAddRows = false;
            this.productDataGridView.AllowUserToDeleteRows = false;
            this.productDataGridView.AllowUserToResizeColumns = false;
            this.productDataGridView.AllowUserToResizeRows = false;
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.productDataGridView.Location = new System.Drawing.Point(13, 45);
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.RowHeadersVisible = false;
            this.productDataGridView.RowHeadersWidth = 51;
            this.productDataGridView.RowTemplate.Height = 50;
            this.productDataGridView.Size = new System.Drawing.Size(878, 358);
            this.productDataGridView.TabIndex = 2;
            this.productDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productDataGridView_CellClick);
            this.productDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.productDataGridView_ColumnStateChanged);
            // 
            // Select
            // 
            this.Select.HeaderText = "Выбрать";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(953, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Макет печатной продукции:";
            // 
            // productPictureBox
            // 
            this.productPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.productPictureBox.Location = new System.Drawing.Point(920, 68);
            this.productPictureBox.Name = "productPictureBox";
            this.productPictureBox.Size = new System.Drawing.Size(272, 240);
            this.productPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productPictureBox.TabIndex = 4;
            this.productPictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchStringTextBox);
            this.groupBox1.Controls.Add(this.stringLabel);
            this.groupBox1.Controls.Add(this.stringComboBox);
            this.groupBox1.Controls.Add(this.secondLabel);
            this.groupBox1.Controls.Add(this.resetSearchButton);
            this.groupBox1.Controls.Add(this.getNumbersDataButton);
            this.groupBox1.Controls.Add(this.toTextBox);
            this.groupBox1.Controls.Add(this.toLabel);
            this.groupBox1.Controls.Add(this.fromTextBox);
            this.groupBox1.Controls.Add(this.fromLabel);
            this.groupBox1.Controls.Add(this.numbersComboBox);
            this.groupBox1.Controls.Add(this.firstColumnsLabel);
            this.groupBox1.Controls.Add(this.outputAllDataButton);
            this.groupBox1.Controls.Add(this.searchOrdersButton);
            this.groupBox1.Controls.Add(this.ordersTreeView);
            this.groupBox1.Controls.Add(this.changeLabel);
            this.groupBox1.Controls.Add(this.addLabel);
            this.groupBox1.Controls.Add(this.resetSelectRowsButton);
            this.groupBox1.Controls.Add(this.changeButton);
            this.groupBox1.Controls.Add(this.resetAddOrChangeButton);
            this.groupBox1.Controls.Add(this.selectAllRowsButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.selectForChangeButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.inputDataButton);
            this.groupBox1.Controls.Add(this.menuStrip2);
            this.groupBox1.Location = new System.Drawing.Point(13, 427);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1179, 215);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
            // 
            // searchStringTextBox
            // 
            this.searchStringTextBox.Location = new System.Drawing.Point(838, 177);
            this.searchStringTextBox.MaxLength = 150;
            this.searchStringTextBox.Name = "searchStringTextBox";
            this.searchStringTextBox.Size = new System.Drawing.Size(272, 27);
            this.searchStringTextBox.TabIndex = 25;
            this.searchStringTextBox.Visible = false;
            this.searchStringTextBox.TextChanged += new System.EventHandler(this.searchStringTextBox_TextChanged);
            // 
            // stringLabel
            // 
            this.stringLabel.AutoSize = true;
            this.stringLabel.Location = new System.Drawing.Point(884, 154);
            this.stringLabel.Name = "stringLabel";
            this.stringLabel.Size = new System.Drawing.Size(181, 20);
            this.stringLabel.TabIndex = 24;
            this.stringLabel.Text = "Данные для поиска типа";
            this.stringLabel.Visible = false;
            // 
            // stringComboBox
            // 
            this.stringComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stringComboBox.FormattingEnabled = true;
            this.stringComboBox.Location = new System.Drawing.Point(838, 86);
            this.stringComboBox.Name = "stringComboBox";
            this.stringComboBox.Size = new System.Drawing.Size(272, 28);
            this.stringComboBox.TabIndex = 23;
            this.stringComboBox.Visible = false;
            // 
            // secondLabel
            // 
            this.secondLabel.AutoSize = true;
            this.secondLabel.Location = new System.Drawing.Point(898, 63);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(148, 20);
            this.secondLabel.TabIndex = 22;
            this.secondLabel.Text = "Столбец для поиска";
            this.secondLabel.Visible = false;
            // 
            // resetSearchButton
            // 
            this.resetSearchButton.Location = new System.Drawing.Point(580, 154);
            this.resetSearchButton.Name = "resetSearchButton";
            this.resetSearchButton.Size = new System.Drawing.Size(243, 55);
            this.resetSearchButton.TabIndex = 21;
            this.resetSearchButton.Text = "Сбросить поиск";
            this.resetSearchButton.UseVisualStyleBackColor = true;
            this.resetSearchButton.Visible = false;
            this.resetSearchButton.Click += new System.EventHandler(this.resetSearchButton_Click);
            // 
            // getNumbersDataButton
            // 
            this.getNumbersDataButton.Location = new System.Drawing.Point(580, 63);
            this.getNumbersDataButton.Name = "getNumbersDataButton";
            this.getNumbersDataButton.Size = new System.Drawing.Size(243, 55);
            this.getNumbersDataButton.TabIndex = 20;
            this.getNumbersDataButton.Text = "Поиск числовых данных";
            this.getNumbersDataButton.UseVisualStyleBackColor = true;
            this.getNumbersDataButton.Visible = false;
            this.getNumbersDataButton.Click += new System.EventHandler(this.getNumbersDataButton_Click);
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(499, 154);
            this.toTextBox.MaxLength = 6;
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(75, 27);
            this.toTextBox.TabIndex = 19;
            this.toTextBox.Visible = false;
            this.toTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fromTextBox_KeyPress);
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(462, 154);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(31, 20);
            this.toLabel.TabIndex = 18;
            this.toLabel.Text = "До:";
            this.toLabel.Visible = false;
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(334, 154);
            this.fromTextBox.MaxLength = 6;
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(75, 27);
            this.fromTextBox.TabIndex = 17;
            this.fromTextBox.Visible = false;
            this.fromTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fromTextBox_KeyPress);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(299, 154);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(29, 20);
            this.fromLabel.TabIndex = 16;
            this.fromLabel.Text = "От:";
            this.fromLabel.Visible = false;
            // 
            // numbersComboBox
            // 
            this.numbersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numbersComboBox.FormattingEnabled = true;
            this.numbersComboBox.Location = new System.Drawing.Point(299, 86);
            this.numbersComboBox.Name = "numbersComboBox";
            this.numbersComboBox.Size = new System.Drawing.Size(275, 28);
            this.numbersComboBox.TabIndex = 15;
            this.numbersComboBox.Visible = false;
            // 
            // firstColumnsLabel
            // 
            this.firstColumnsLabel.AutoSize = true;
            this.firstColumnsLabel.Location = new System.Drawing.Point(364, 63);
            this.firstColumnsLabel.Name = "firstColumnsLabel";
            this.firstColumnsLabel.Size = new System.Drawing.Size(148, 20);
            this.firstColumnsLabel.TabIndex = 14;
            this.firstColumnsLabel.Text = "Столбец для поиска";
            this.firstColumnsLabel.Visible = false;
            // 
            // outputAllDataButton
            // 
            this.outputAllDataButton.Location = new System.Drawing.Point(112, 154);
            this.outputAllDataButton.Name = "outputAllDataButton";
            this.outputAllDataButton.Size = new System.Drawing.Size(181, 55);
            this.outputAllDataButton.TabIndex = 13;
            this.outputAllDataButton.Text = "Вывод всех данных о печ. продукции";
            this.outputAllDataButton.UseVisualStyleBackColor = true;
            this.outputAllDataButton.Visible = false;
            this.outputAllDataButton.Click += new System.EventHandler(this.outputAllDataButton_Click);
            // 
            // searchOrdersButton
            // 
            this.searchOrdersButton.Location = new System.Drawing.Point(112, 63);
            this.searchOrdersButton.Name = "searchOrdersButton";
            this.searchOrdersButton.Size = new System.Drawing.Size(181, 55);
            this.searchOrdersButton.TabIndex = 12;
            this.searchOrdersButton.Text = "Поиск заказа";
            this.searchOrdersButton.UseVisualStyleBackColor = true;
            this.searchOrdersButton.Visible = false;
            this.searchOrdersButton.Click += new System.EventHandler(this.searchOrdersButton_Click);
            // 
            // ordersTreeView
            // 
            this.ordersTreeView.Location = new System.Drawing.Point(6, 63);
            this.ordersTreeView.Name = "ordersTreeView";
            this.ordersTreeView.Size = new System.Drawing.Size(100, 146);
            this.ordersTreeView.TabIndex = 11;
            this.ordersTreeView.Visible = false;
            // 
            // changeLabel
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.Location = new System.Drawing.Point(598, 126);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(0, 20);
            this.changeLabel.TabIndex = 10;
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Location = new System.Drawing.Point(20, 126);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(0, 20);
            this.addLabel.TabIndex = 9;
            // 
            // resetSelectRowsButton
            // 
            this.resetSelectRowsButton.Location = new System.Drawing.Point(867, 154);
            this.resetSelectRowsButton.Name = "resetSelectRowsButton";
            this.resetSelectRowsButton.Size = new System.Drawing.Size(243, 55);
            this.resetSelectRowsButton.TabIndex = 8;
            this.resetSelectRowsButton.Text = "Отменить выбор строк";
            this.resetSelectRowsButton.UseVisualStyleBackColor = true;
            this.resetSelectRowsButton.Click += new System.EventHandler(this.resetSelectRowsButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Enabled = false;
            this.changeButton.Location = new System.Drawing.Point(580, 154);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(243, 55);
            this.changeButton.TabIndex = 7;
            this.changeButton.Text = "Изменить печатную продукцию";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // resetAddOrChangeButton
            // 
            this.resetAddOrChangeButton.Location = new System.Drawing.Point(293, 154);
            this.resetAddOrChangeButton.Name = "resetAddOrChangeButton";
            this.resetAddOrChangeButton.Size = new System.Drawing.Size(243, 55);
            this.resetAddOrChangeButton.TabIndex = 6;
            this.resetAddOrChangeButton.Text = "Отменить добавление/ изменение";
            this.resetAddOrChangeButton.UseVisualStyleBackColor = true;
            this.resetAddOrChangeButton.Click += new System.EventHandler(this.resetAddOrChangeButton_Click);
            // 
            // selectAllRowsButton
            // 
            this.selectAllRowsButton.Location = new System.Drawing.Point(867, 63);
            this.selectAllRowsButton.Name = "selectAllRowsButton";
            this.selectAllRowsButton.Size = new System.Drawing.Size(243, 55);
            this.selectAllRowsButton.TabIndex = 5;
            this.selectAllRowsButton.Text = "Выбрать всё";
            this.selectAllRowsButton.UseVisualStyleBackColor = true;
            this.selectAllRowsButton.Click += new System.EventHandler(this.selectAllRowsButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(580, 63);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(243, 55);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить печатную продукцию";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // selectForChangeButton
            // 
            this.selectForChangeButton.Location = new System.Drawing.Point(293, 63);
            this.selectForChangeButton.Name = "selectForChangeButton";
            this.selectForChangeButton.Size = new System.Drawing.Size(243, 55);
            this.selectForChangeButton.TabIndex = 3;
            this.selectForChangeButton.Text = "Выбрать для изменения";
            this.selectForChangeButton.UseVisualStyleBackColor = true;
            this.selectForChangeButton.Click += new System.EventHandler(this.selectForChangeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 154);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(243, 55);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Добавить печатную продукцию";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // inputDataButton
            // 
            this.inputDataButton.Location = new System.Drawing.Point(6, 63);
            this.inputDataButton.Name = "inputDataButton";
            this.inputDataButton.Size = new System.Drawing.Size(243, 55);
            this.inputDataButton.TabIndex = 1;
            this.inputDataButton.Text = "Ввести данные";
            this.inputDataButton.UseVisualStyleBackColor = true;
            this.inputDataButton.Click += new System.EventHandler(this.inputDataButton_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processingTab,
            this.searchTab});
            this.menuStrip2.Location = new System.Drawing.Point(3, 23);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1173, 28);
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
            // ProductMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 654);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.productPictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.typesProductButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ProductMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Печатная продукция";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductMenu_FormClosing);
            this.Load += new System.EventHandler(this.ProductMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.Button typesProductButton;
        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox productPictureBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem processingTab;
        private System.Windows.Forms.ToolStripMenuItem searchTab;
        private System.Windows.Forms.Button inputDataButton;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.Button resetSelectRowsButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button resetAddOrChangeButton;
        private System.Windows.Forms.Button selectAllRowsButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button selectForChangeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label changeLabel;
        private System.Windows.Forms.TreeView ordersTreeView;
        private System.Windows.Forms.Button outputAllDataButton;
        private System.Windows.Forms.Button searchOrdersButton;
        private System.Windows.Forms.Label firstColumnsLabel;
        private System.Windows.Forms.ComboBox numbersComboBox;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Button resetSearchButton;
        private System.Windows.Forms.Button getNumbersDataButton;
        private System.Windows.Forms.Label stringLabel;
        private System.Windows.Forms.ComboBox stringComboBox;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.TextBox searchStringTextBox;
    }
}