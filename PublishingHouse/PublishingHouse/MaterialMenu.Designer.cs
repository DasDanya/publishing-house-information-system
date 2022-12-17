
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
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.materialGroupBox = new System.Windows.Forms.GroupBox();
            this.cancelSelectRowsButton = new System.Windows.Forms.Button();
            this.selectAllRowsButton = new System.Windows.Forms.Button();
            this.cComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectColorButton = new System.Windows.Forms.Button();
            this.popDataAbMaterialButton = new System.Windows.Forms.Button();
            this.searchCostButton = new System.Windows.Forms.Button();
            this.resetChangeButton = new System.Windows.Forms.Button();
            this.resetCostButton = new System.Windows.Forms.Button();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.columnComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.changeButton = new System.Windows.Forms.Button();
            this.selectForChangeButton = new System.Windows.Forms.Button();
            this.aComboBox = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorInfoLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataGridView)).BeginInit();
            this.materialGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialDataGridView
            // 
            this.materialDataGridView.AllowUserToAddRows = false;
            this.materialDataGridView.AllowUserToDeleteRows = false;
            this.materialDataGridView.AllowUserToResizeColumns = false;
            this.materialDataGridView.AllowUserToResizeRows = false;
            this.materialDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.materialDataGridView.Location = new System.Drawing.Point(12, 30);
            this.materialDataGridView.Name = "materialDataGridView";
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
            this.materialDataGridView.RowTemplate.Height = 50;
            this.materialDataGridView.Size = new System.Drawing.Size(768, 504);
            this.materialDataGridView.TabIndex = 0;
            this.materialDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.materialDataGridView_ColumnStateChanged);
            // 
            // Select
            // 
            this.Select.HeaderText = "Выбрать";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select.Width = 125;
            // 
            // materialGroupBox
            // 
            this.materialGroupBox.Controls.Add(this.cancelSelectRowsButton);
            this.materialGroupBox.Controls.Add(this.selectAllRowsButton);
            this.materialGroupBox.Controls.Add(this.cComboBox);
            this.materialGroupBox.Controls.Add(this.label7);
            this.materialGroupBox.Controls.Add(this.bComboBox);
            this.materialGroupBox.Controls.Add(this.label4);
            this.materialGroupBox.Controls.Add(this.selectColorButton);
            this.materialGroupBox.Controls.Add(this.popDataAbMaterialButton);
            this.materialGroupBox.Controls.Add(this.searchCostButton);
            this.materialGroupBox.Controls.Add(this.resetChangeButton);
            this.materialGroupBox.Controls.Add(this.resetCostButton);
            this.materialGroupBox.Controls.Add(this.toTextBox);
            this.materialGroupBox.Controls.Add(this.label16);
            this.materialGroupBox.Controls.Add(this.fromTextBox);
            this.materialGroupBox.Controls.Add(this.label15);
            this.materialGroupBox.Controls.Add(this.label14);
            this.materialGroupBox.Controls.Add(this.searchTextBox);
            this.materialGroupBox.Controls.Add(this.label13);
            this.materialGroupBox.Controls.Add(this.label12);
            this.materialGroupBox.Controls.Add(this.columnComboBox);
            this.materialGroupBox.Controls.Add(this.label11);
            this.materialGroupBox.Controls.Add(this.label10);
            this.materialGroupBox.Controls.Add(this.changeButton);
            this.materialGroupBox.Controls.Add(this.selectForChangeButton);
            this.materialGroupBox.Controls.Add(this.aComboBox);
            this.materialGroupBox.Controls.Add(this.deleteButton);
            this.materialGroupBox.Controls.Add(this.addButton);
            this.materialGroupBox.Controls.Add(this.costTextBox);
            this.materialGroupBox.Controls.Add(this.label8);
            this.materialGroupBox.Controls.Add(this.label9);
            this.materialGroupBox.Controls.Add(this.label6);
            this.materialGroupBox.Controls.Add(this.label5);
            this.materialGroupBox.Controls.Add(this.label3);
            this.materialGroupBox.Controls.Add(this.colorInfoLabel);
            this.materialGroupBox.Controls.Add(this.label2);
            this.materialGroupBox.Controls.Add(this.typeComboBox);
            this.materialGroupBox.Controls.Add(this.label1);
            this.materialGroupBox.Location = new System.Drawing.Point(800, 30);
            this.materialGroupBox.Name = "materialGroupBox";
            this.materialGroupBox.Size = new System.Drawing.Size(928, 504);
            this.materialGroupBox.TabIndex = 1;
            this.materialGroupBox.TabStop = false;
            this.materialGroupBox.Text = "Работа с данными";
            // 
            // cancelSelectRowsButton
            // 
            this.cancelSelectRowsButton.Location = new System.Drawing.Point(694, 387);
            this.cancelSelectRowsButton.Name = "cancelSelectRowsButton";
            this.cancelSelectRowsButton.Size = new System.Drawing.Size(166, 43);
            this.cancelSelectRowsButton.TabIndex = 41;
            this.cancelSelectRowsButton.Text = "Отменить выбор";
            this.cancelSelectRowsButton.UseVisualStyleBackColor = true;
            this.cancelSelectRowsButton.Click += new System.EventHandler(this.cancelSelectRowsButton_Click);
            // 
            // selectAllRowsButton
            // 
            this.selectAllRowsButton.Location = new System.Drawing.Point(501, 387);
            this.selectAllRowsButton.Name = "selectAllRowsButton";
            this.selectAllRowsButton.Size = new System.Drawing.Size(166, 43);
            this.selectAllRowsButton.TabIndex = 40;
            this.selectAllRowsButton.Text = "Выбрать всё";
            this.selectAllRowsButton.UseVisualStyleBackColor = true;
            this.selectAllRowsButton.Click += new System.EventHandler(this.selectAllRowsButton_Click);
            // 
            // cComboBox
            // 
            this.cComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cComboBox.FormattingEnabled = true;
            this.cComboBox.Items.AddRange(new object[] {
            "917x1297",
            "648x917",
            "458x648",
            "324x458",
            "229x324",
            "162x229",
            "114x162",
            "81x114",
            ""});
            this.cComboBox.Location = new System.Drawing.Point(307, 247);
            this.cComboBox.Name = "cComboBox";
            this.cComboBox.Size = new System.Drawing.Size(105, 28);
            this.cComboBox.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(279, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "С:";
            // 
            // bComboBox
            // 
            this.bComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bComboBox.FormattingEnabled = true;
            this.bComboBox.Items.AddRange(new object[] {
            "1000x1414",
            "707x1000",
            "500x707",
            "353x500",
            "250x353",
            "176x250",
            "125x176",
            "88x125",
            ""});
            this.bComboBox.Location = new System.Drawing.Point(168, 248);
            this.bComboBox.Name = "bComboBox";
            this.bComboBox.Size = new System.Drawing.Size(105, 28);
            this.bComboBox.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "В:";
            // 
            // selectColorButton
            // 
            this.selectColorButton.Location = new System.Drawing.Point(144, 156);
            this.selectColorButton.Name = "selectColorButton";
            this.selectColorButton.Size = new System.Drawing.Size(268, 29);
            this.selectColorButton.TabIndex = 35;
            this.selectColorButton.Text = "Выбрать цвет";
            this.selectColorButton.UseVisualStyleBackColor = true;
            this.selectColorButton.Click += new System.EventHandler(this.selectColorButton_Click);
            // 
            // popDataAbMaterialButton
            // 
            this.popDataAbMaterialButton.Location = new System.Drawing.Point(694, 455);
            this.popDataAbMaterialButton.Name = "popDataAbMaterialButton";
            this.popDataAbMaterialButton.Size = new System.Drawing.Size(166, 43);
            this.popDataAbMaterialButton.TabIndex = 34;
            this.popDataAbMaterialButton.Text = "Мода данных";
            this.popDataAbMaterialButton.UseVisualStyleBackColor = true;
            this.popDataAbMaterialButton.Click += new System.EventHandler(this.popDataAbMaterialButton_Click);
            // 
            // searchCostButton
            // 
            this.searchCostButton.Location = new System.Drawing.Point(501, 318);
            this.searchCostButton.Name = "searchCostButton";
            this.searchCostButton.Size = new System.Drawing.Size(166, 43);
            this.searchCostButton.TabIndex = 33;
            this.searchCostButton.Text = "Поиск по стоимости";
            this.searchCostButton.UseVisualStyleBackColor = true;
            this.searchCostButton.Click += new System.EventHandler(this.searchCostButton_Click);
            // 
            // resetChangeButton
            // 
            this.resetChangeButton.Enabled = false;
            this.resetChangeButton.Location = new System.Drawing.Point(501, 455);
            this.resetChangeButton.Name = "resetChangeButton";
            this.resetChangeButton.Size = new System.Drawing.Size(166, 43);
            this.resetChangeButton.TabIndex = 32;
            this.resetChangeButton.Text = "Сбросить изменение";
            this.resetChangeButton.UseVisualStyleBackColor = true;
            this.resetChangeButton.Click += new System.EventHandler(this.resetChangeButton_Click);
            // 
            // resetCostButton
            // 
            this.resetCostButton.Location = new System.Drawing.Point(694, 318);
            this.resetCostButton.Name = "resetCostButton";
            this.resetCostButton.Size = new System.Drawing.Size(166, 43);
            this.resetCostButton.TabIndex = 31;
            this.resetCostButton.Text = "Сбросить поиск";
            this.resetCostButton.UseVisualStyleBackColor = true;
            this.resetCostButton.Click += new System.EventHandler(this.resetCostButton_Click);
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(740, 247);
            this.toTextBox.MaxLength = 8;
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(120, 27);
            this.toTextBox.TabIndex = 30;
            this.toTextBox.Text = "100";
            this.toTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.costTextBox_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(706, 250);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 20);
            this.label16.TabIndex = 29;
            this.label16.Text = "До";
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(539, 247);
            this.fromTextBox.MaxLength = 8;
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(120, 27);
            this.fromTextBox.TabIndex = 28;
            this.fromTextBox.Text = "1";
            this.fromTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.costTextBox_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(504, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 20);
            this.label15.TabIndex = 27;
            this.label15.Text = "От";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(539, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(298, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "Введите диапазон стоимости для поиска ";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(592, 158);
            this.searchTextBox.MaxLength = 30;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(268, 27);
            this.searchTextBox.TabIndex = 25;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(504, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "Данные:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(539, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(295, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "Введите данные о материале для поиска";
            // 
            // columnComboBox
            // 
            this.columnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnComboBox.FormattingEnabled = true;
            this.columnComboBox.Location = new System.Drawing.Point(592, 70);
            this.columnComboBox.Name = "columnComboBox";
            this.columnComboBox.Size = new System.Drawing.Size(268, 28);
            this.columnComboBox.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(501, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "Столбец:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(536, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(298, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Выберите столбец для поиска материала";
            // 
            // changeButton
            // 
            this.changeButton.Enabled = false;
            this.changeButton.Location = new System.Drawing.Point(225, 455);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(187, 43);
            this.changeButton.TabIndex = 19;
            this.changeButton.Text = "Изменить материал";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // selectForChangeButton
            // 
            this.selectForChangeButton.Location = new System.Drawing.Point(6, 455);
            this.selectForChangeButton.Name = "selectForChangeButton";
            this.selectForChangeButton.Size = new System.Drawing.Size(187, 43);
            this.selectForChangeButton.TabIndex = 0;
            this.selectForChangeButton.Text = "Выбрать для изменения";
            this.selectForChangeButton.Click += new System.EventHandler(this.selectForChangeButton_Click);
            // 
            // aComboBox
            // 
            this.aComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aComboBox.FormattingEnabled = true;
            this.aComboBox.Items.AddRange(new object[] {
            "841x1189",
            "594x841",
            "420x594",
            "297x420",
            "210x297",
            "148x210",
            "105x148",
            "74x105",
            ""});
            this.aComboBox.Location = new System.Drawing.Point(34, 248);
            this.aComboBox.Name = "aComboBox";
            this.aComboBox.Size = new System.Drawing.Size(105, 28);
            this.aComboBox.TabIndex = 18;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(225, 387);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(187, 43);
            this.deleteButton.TabIndex = 16;
            this.deleteButton.Text = "Удалить материал";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 387);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(187, 43);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Добавить материал";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(98, 334);
            this.costTextBox.MaxLength = 8;
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(314, 27);
            this.costTextBox.TabIndex = 14;
            this.costTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.costTextBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(324, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Введите стоимость материала в рублях (1шт)";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "А:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Выберите размер из преложенных списков (мм)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выберите цвет материала";
            // 
            // colorInfoLabel
            // 
            this.colorInfoLabel.AutoSize = true;
            this.colorInfoLabel.Location = new System.Drawing.Point(6, 158);
            this.colorInfoLabel.Name = "colorInfoLabel";
            this.colorInfoLabel.Size = new System.Drawing.Size(125, 20);
            this.colorInfoLabel.TabIndex = 3;
            this.colorInfoLabel.Text = "Цвет не выбран!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите тип материала из списка";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Бумага для глубокой печати",
            "Газетная бумага",
            "Глянцевая бумага",
            "Дизайнерская бумага",
            "Картон",
            "Крафт-бумага",
            "Матовая бумага",
            "Мелованная бумага",
            "Обложечная бумага",
            "Офсетная бумага",
            "Самокопирующаяся бумага",
            "Типографская бумага",
            "Форзацная бумага"});
            this.typeComboBox.Location = new System.Drawing.Point(144, 70);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(268, 28);
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
            this.menuStrip1.Size = new System.Drawing.Size(1740, 28);
            this.menuStrip1.TabIndex = 2;
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
            // MaterialMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1740, 544);
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ComboBox aComboBox;
        private System.Windows.Forms.Button selectForChangeButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.ComboBox columnComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button resetChangeButton;
        private System.Windows.Forms.Button resetCostButton;
        private System.Windows.Forms.Button searchCostButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button popDataAbMaterialButton;
        private System.Windows.Forms.Button selectColorButton;
        private System.Windows.Forms.Label colorInfoLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox cComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox bComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectAllRowsButton;
        private System.Windows.Forms.Button cancelSelectRowsButton;
    }
}