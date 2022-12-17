
namespace PublishingHouse
{
    partial class TypesProductMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypesProductMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.typesProductDataGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resetSearchButton = new System.Windows.Forms.Button();
            this.searchMarginButton = new System.Windows.Forms.Button();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchTypeLabel = new System.Windows.Forms.Label();
            this.columnsComboBox = new System.Windows.Forms.ComboBox();
            this.columnsLabel = new System.Windows.Forms.Label();
            this.fashionTypesButton = new System.Windows.Forms.Button();
            this.getProductsButton = new System.Windows.Forms.Button();
            this.productsTreeView = new System.Windows.Forms.TreeView();
            this.resetSelectRowsButton = new System.Windows.Forms.Button();
            this.selectAllRowsButton = new System.Windows.Forms.Button();
            this.changeTypeLabel = new System.Windows.Forms.Label();
            this.addTypeLabel = new System.Windows.Forms.Label();
            this.changeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.restAddOrChangeButton = new System.Windows.Forms.Button();
            this.selectForChangeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.inputDataButton = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.processingTab = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typesProductDataGridView)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1073, 28);
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
            // typesProductDataGridView
            // 
            this.typesProductDataGridView.AllowUserToAddRows = false;
            this.typesProductDataGridView.AllowUserToDeleteRows = false;
            this.typesProductDataGridView.AllowUserToResizeColumns = false;
            this.typesProductDataGridView.AllowUserToResizeRows = false;
            this.typesProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.typesProductDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.typesProductDataGridView.Location = new System.Drawing.Point(12, 41);
            this.typesProductDataGridView.Name = "typesProductDataGridView";
            this.typesProductDataGridView.RowHeadersVisible = false;
            this.typesProductDataGridView.RowHeadersWidth = 51;
            this.typesProductDataGridView.RowTemplate.Height = 50;
            this.typesProductDataGridView.Size = new System.Drawing.Size(950, 271);
            this.typesProductDataGridView.TabIndex = 1;
            this.typesProductDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.typesProductDataGridView_ColumnStateChanged);
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
            this.groupBox1.Controls.Add(this.resetSearchButton);
            this.groupBox1.Controls.Add(this.searchMarginButton);
            this.groupBox1.Controls.Add(this.toLabel);
            this.groupBox1.Controls.Add(this.fromLabel);
            this.groupBox1.Controls.Add(this.toTextBox);
            this.groupBox1.Controls.Add(this.fromTextBox);
            this.groupBox1.Controls.Add(this.rangeLabel);
            this.groupBox1.Controls.Add(this.searchTextBox);
            this.groupBox1.Controls.Add(this.searchTypeLabel);
            this.groupBox1.Controls.Add(this.columnsComboBox);
            this.groupBox1.Controls.Add(this.columnsLabel);
            this.groupBox1.Controls.Add(this.fashionTypesButton);
            this.groupBox1.Controls.Add(this.getProductsButton);
            this.groupBox1.Controls.Add(this.productsTreeView);
            this.groupBox1.Controls.Add(this.resetSelectRowsButton);
            this.groupBox1.Controls.Add(this.selectAllRowsButton);
            this.groupBox1.Controls.Add(this.changeTypeLabel);
            this.groupBox1.Controls.Add(this.addTypeLabel);
            this.groupBox1.Controls.Add(this.changeButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.restAddOrChangeButton);
            this.groupBox1.Controls.Add(this.selectForChangeButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.inputDataButton);
            this.groupBox1.Controls.Add(this.menuStrip2);
            this.groupBox1.Location = new System.Drawing.Point(12, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1049, 208);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
            // 
            // resetSearchButton
            // 
            this.resetSearchButton.Location = new System.Drawing.Point(805, 156);
            this.resetSearchButton.Name = "resetSearchButton";
            this.resetSearchButton.Size = new System.Drawing.Size(218, 36);
            this.resetSearchButton.TabIndex = 24;
            this.resetSearchButton.Text = "Сброс поиска";
            this.resetSearchButton.UseVisualStyleBackColor = true;
            this.resetSearchButton.Visible = false;
            this.resetSearchButton.Click += new System.EventHandler(this.resetSearchButton_Click);
            // 
            // searchMarginButton
            // 
            this.searchMarginButton.Location = new System.Drawing.Point(805, 119);
            this.searchMarginButton.Name = "searchMarginButton";
            this.searchMarginButton.Size = new System.Drawing.Size(218, 31);
            this.searchMarginButton.TabIndex = 23;
            this.searchMarginButton.Text = "Поиск по наценке";
            this.searchMarginButton.UseVisualStyleBackColor = true;
            this.searchMarginButton.Visible = false;
            this.searchMarginButton.Click += new System.EventHandler(this.searchMarginButton_Click);
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(918, 86);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(31, 20);
            this.toLabel.TabIndex = 22;
            this.toLabel.Text = "До:";
            this.toLabel.Visible = false;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(805, 86);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(29, 20);
            this.fromLabel.TabIndex = 21;
            this.fromLabel.Text = "От:";
            this.fromLabel.Visible = false;
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(953, 86);
            this.toTextBox.MaxLength = 5;
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(70, 27);
            this.toTextBox.TabIndex = 20;
            this.toTextBox.Text = "100";
            this.toTextBox.Visible = false;
            this.toTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fromTextBox_KeyPress);
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(840, 86);
            this.fromTextBox.MaxLength = 5;
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(70, 27);
            this.fromTextBox.TabIndex = 19;
            this.fromTextBox.Text = "0";
            this.fromTextBox.Visible = false;
            this.fromTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fromTextBox_KeyPress);
            // 
            // rangeLabel
            // 
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Location = new System.Drawing.Point(845, 63);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(144, 20);
            this.rangeLabel.TabIndex = 18;
            this.rangeLabel.Text = "Диапазон наценок:";
            this.rangeLabel.Visible = false;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(524, 165);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(246, 27);
            this.searchTextBox.TabIndex = 17;
            this.searchTextBox.Visible = false;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // searchTypeLabel
            // 
            this.searchTypeLabel.AutoSize = true;
            this.searchTypeLabel.Location = new System.Drawing.Point(558, 142);
            this.searchTypeLabel.Name = "searchTypeLabel";
            this.searchTypeLabel.Size = new System.Drawing.Size(181, 20);
            this.searchTypeLabel.TabIndex = 16;
            this.searchTypeLabel.Text = "Данные для поиска типа";
            this.searchTypeLabel.Visible = false;
            // 
            // columnsComboBox
            // 
            this.columnsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnsComboBox.FormattingEnabled = true;
            this.columnsComboBox.Location = new System.Drawing.Point(524, 86);
            this.columnsComboBox.Name = "columnsComboBox";
            this.columnsComboBox.Size = new System.Drawing.Size(246, 28);
            this.columnsComboBox.TabIndex = 15;
            this.columnsComboBox.Visible = false;
            // 
            // columnsLabel
            // 
            this.columnsLabel.AutoSize = true;
            this.columnsLabel.Location = new System.Drawing.Point(558, 63);
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(184, 20);
            this.columnsLabel.TabIndex = 14;
            this.columnsLabel.Text = "Столбец для поиска типа";
            this.columnsLabel.Visible = false;
            // 
            // fashionTypesButton
            // 
            this.fashionTypesButton.Location = new System.Drawing.Point(265, 143);
            this.fashionTypesButton.Name = "fashionTypesButton";
            this.fashionTypesButton.Size = new System.Drawing.Size(203, 49);
            this.fashionTypesButton.TabIndex = 13;
            this.fashionTypesButton.Text = "Мода типов печатной продукции";
            this.fashionTypesButton.UseVisualStyleBackColor = true;
            this.fashionTypesButton.Visible = false;
            this.fashionTypesButton.Click += new System.EventHandler(this.fashionTypesButton_Click);
            // 
            // getProductsButton
            // 
            this.getProductsButton.Location = new System.Drawing.Point(265, 65);
            this.getProductsButton.Name = "getProductsButton";
            this.getProductsButton.Size = new System.Drawing.Size(203, 49);
            this.getProductsButton.TabIndex = 12;
            this.getProductsButton.Text = "Получить печатные продукции";
            this.getProductsButton.UseVisualStyleBackColor = true;
            this.getProductsButton.Visible = false;
            this.getProductsButton.Click += new System.EventHandler(this.getProductsButton_Click);
            // 
            // productsTreeView
            // 
            this.productsTreeView.Location = new System.Drawing.Point(7, 65);
            this.productsTreeView.Name = "productsTreeView";
            this.productsTreeView.Size = new System.Drawing.Size(252, 127);
            this.productsTreeView.TabIndex = 11;
            this.productsTreeView.Visible = false;
            // 
            // resetSelectRowsButton
            // 
            this.resetSelectRowsButton.Location = new System.Drawing.Point(783, 143);
            this.resetSelectRowsButton.Name = "resetSelectRowsButton";
            this.resetSelectRowsButton.Size = new System.Drawing.Size(203, 49);
            this.resetSelectRowsButton.TabIndex = 10;
            this.resetSelectRowsButton.Text = "Отменить выбор строк";
            this.resetSelectRowsButton.UseVisualStyleBackColor = true;
            this.resetSelectRowsButton.Click += new System.EventHandler(this.resetSelectRowsButton_Click);
            // 
            // selectAllRowsButton
            // 
            this.selectAllRowsButton.Location = new System.Drawing.Point(783, 65);
            this.selectAllRowsButton.Name = "selectAllRowsButton";
            this.selectAllRowsButton.Size = new System.Drawing.Size(203, 49);
            this.selectAllRowsButton.TabIndex = 9;
            this.selectAllRowsButton.Text = "Выбрать всё";
            this.selectAllRowsButton.UseVisualStyleBackColor = true;
            this.selectAllRowsButton.Click += new System.EventHandler(this.selectAllRowsButton_Click);
            // 
            // changeTypeLabel
            // 
            this.changeTypeLabel.AutoSize = true;
            this.changeTypeLabel.Location = new System.Drawing.Point(521, 121);
            this.changeTypeLabel.Name = "changeTypeLabel";
            this.changeTypeLabel.Size = new System.Drawing.Size(0, 20);
            this.changeTypeLabel.TabIndex = 8;
            // 
            // addTypeLabel
            // 
            this.addTypeLabel.AutoSize = true;
            this.addTypeLabel.Location = new System.Drawing.Point(4, 121);
            this.addTypeLabel.Name = "addTypeLabel";
            this.addTypeLabel.Size = new System.Drawing.Size(0, 20);
            this.addTypeLabel.TabIndex = 7;
            // 
            // changeButton
            // 
            this.changeButton.Enabled = false;
            this.changeButton.Location = new System.Drawing.Point(524, 143);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(203, 49);
            this.changeButton.TabIndex = 6;
            this.changeButton.Text = "Изменить данные о типе";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(524, 65);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(203, 49);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить тип";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // restAddOrChangeButton
            // 
            this.restAddOrChangeButton.Location = new System.Drawing.Point(265, 143);
            this.restAddOrChangeButton.Name = "restAddOrChangeButton";
            this.restAddOrChangeButton.Size = new System.Drawing.Size(203, 49);
            this.restAddOrChangeButton.TabIndex = 4;
            this.restAddOrChangeButton.Text = "Отменить добавление/ изменение";
            this.restAddOrChangeButton.UseVisualStyleBackColor = true;
            this.restAddOrChangeButton.Click += new System.EventHandler(this.restAddOrChangeButton_Click);
            // 
            // selectForChangeButton
            // 
            this.selectForChangeButton.Location = new System.Drawing.Point(265, 65);
            this.selectForChangeButton.Name = "selectForChangeButton";
            this.selectForChangeButton.Size = new System.Drawing.Size(203, 49);
            this.selectForChangeButton.TabIndex = 3;
            this.selectForChangeButton.Text = "Выбрать для изменения";
            this.selectForChangeButton.UseVisualStyleBackColor = true;
            this.selectForChangeButton.Click += new System.EventHandler(this.selectForChangeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 143);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(203, 49);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Добавить тип";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // inputDataButton
            // 
            this.inputDataButton.Location = new System.Drawing.Point(6, 65);
            this.inputDataButton.Name = "inputDataButton";
            this.inputDataButton.Size = new System.Drawing.Size(203, 49);
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
            this.menuStrip2.Size = new System.Drawing.Size(1043, 28);
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
            // TypesProductMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 555);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.typesProductDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TypesProductMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Типы печатной продукции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TypesProductMenu_FormClosing);
            this.Load += new System.EventHandler(this.TypesProductMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typesProductDataGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView typesProductDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem processingTab;
        private System.Windows.Forms.ToolStripMenuItem searchTab;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button restAddOrChangeButton;
        private System.Windows.Forms.Button selectForChangeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button inputDataButton;
        private System.Windows.Forms.Button resetSelectRowsButton;
        private System.Windows.Forms.Button selectAllRowsButton;
        private System.Windows.Forms.Label changeTypeLabel;
        private System.Windows.Forms.Label addTypeLabel;
        private System.Windows.Forms.Button fashionTypesButton;
        private System.Windows.Forms.Button getProductsButton;
        private System.Windows.Forms.TreeView productsTreeView;
        private System.Windows.Forms.Label columnsLabel;
        private System.Windows.Forms.Label searchTypeLabel;
        private System.Windows.Forms.ComboBox columnsComboBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label rangeLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Button resetSearchButton;
        private System.Windows.Forms.Button searchMarginButton;
    }
}