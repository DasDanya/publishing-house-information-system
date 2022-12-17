
namespace PublishingHouse
{
    partial class OccurrenceMaterialData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OccurrenceMaterialData));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.getTypesButton = new System.Windows.Forms.Button();
            this.countTypeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.ascTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.getColorsButton = new System.Windows.Forms.Button();
            this.countColorTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descColorRadioButton = new System.Windows.Forms.RadioButton();
            this.ascColorRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.getSizesButton = new System.Windows.Forms.Button();
            this.countSizeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.descSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.ascSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.sizeDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.getCostsButton = new System.Windows.Forms.Button();
            this.countCostTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.descCostRadioButton = new System.Windows.Forms.RadioButton();
            this.ascCostRadioButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.costDataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1268, 28);
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
            // typeDataGridView
            // 
            this.typeDataGridView.AllowUserToAddRows = false;
            this.typeDataGridView.AllowUserToDeleteRows = false;
            this.typeDataGridView.AllowUserToResizeColumns = false;
            this.typeDataGridView.AllowUserToResizeRows = false;
            this.typeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.typeDataGridView.Location = new System.Drawing.Point(12, 69);
            this.typeDataGridView.Name = "typeDataGridView";
            this.typeDataGridView.ReadOnly = true;
            this.typeDataGridView.RowHeadersVisible = false;
            this.typeDataGridView.RowHeadersWidth = 51;
            this.typeDataGridView.RowTemplate.Height = 50;
            this.typeDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.typeDataGridView.Size = new System.Drawing.Size(312, 312);
            this.typeDataGridView.TabIndex = 1;
            this.typeDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.DataGridView_ColumnStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Типы";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getTypesButton);
            this.groupBox1.Controls.Add(this.countTypeTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.descTypeRadioButton);
            this.groupBox1.Controls.Add(this.ascTypeRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(351, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 320);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с типами";
            // 
            // getTypesButton
            // 
            this.getTypesButton.Location = new System.Drawing.Point(6, 201);
            this.getTypesButton.Name = "getTypesButton";
            this.getTypesButton.Size = new System.Drawing.Size(237, 113);
            this.getTypesButton.TabIndex = 4;
            this.getTypesButton.Text = "Получить типы";
            this.getTypesButton.UseVisualStyleBackColor = true;
            this.getTypesButton.Click += new System.EventHandler(this.getTypesButton_Click);
            // 
            // countTypeTextBox
            // 
            this.countTypeTextBox.Location = new System.Drawing.Point(6, 157);
            this.countTypeTextBox.MaxLength = 11;
            this.countTypeTextBox.Name = "countTypeTextBox";
            this.countTypeTextBox.Size = new System.Drawing.Size(238, 27);
            this.countTypeTextBox.TabIndex = 3;
            this.countTypeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество выводимых строк:";
            // 
            // descTypeRadioButton
            // 
            this.descTypeRadioButton.AutoSize = true;
            this.descTypeRadioButton.Location = new System.Drawing.Point(7, 85);
            this.descTypeRadioButton.Name = "descTypeRadioButton";
            this.descTypeRadioButton.Size = new System.Drawing.Size(127, 24);
            this.descTypeRadioButton.TabIndex = 1;
            this.descTypeRadioButton.TabStop = true;
            this.descTypeRadioButton.Text = "По убыванию";
            this.descTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ascTypeRadioButton
            // 
            this.ascTypeRadioButton.AutoSize = true;
            this.ascTypeRadioButton.Location = new System.Drawing.Point(6, 43);
            this.ascTypeRadioButton.Name = "ascTypeRadioButton";
            this.ascTypeRadioButton.Size = new System.Drawing.Size(146, 24);
            this.ascTypeRadioButton.TabIndex = 0;
            this.ascTypeRadioButton.TabStop = true;
            this.ascTypeRadioButton.Text = "По возрастанию";
            this.ascTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.getColorsButton);
            this.groupBox2.Controls.Add(this.countColorTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.descColorRadioButton);
            this.groupBox2.Controls.Add(this.ascColorRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(976, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 320);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа с цветами";
            // 
            // getColorsButton
            // 
            this.getColorsButton.Location = new System.Drawing.Point(7, 201);
            this.getColorsButton.Name = "getColorsButton";
            this.getColorsButton.Size = new System.Drawing.Size(237, 113);
            this.getColorsButton.TabIndex = 4;
            this.getColorsButton.Text = "Получить цвета";
            this.getColorsButton.UseVisualStyleBackColor = true;
            this.getColorsButton.Click += new System.EventHandler(this.getColorsButton_Click);
            // 
            // countColorTextBox
            // 
            this.countColorTextBox.Location = new System.Drawing.Point(6, 157);
            this.countColorTextBox.MaxLength = 11;
            this.countColorTextBox.Name = "countColorTextBox";
            this.countColorTextBox.Size = new System.Drawing.Size(238, 27);
            this.countColorTextBox.TabIndex = 3;
            this.countColorTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество выводимых строк:";
            // 
            // descColorRadioButton
            // 
            this.descColorRadioButton.AutoSize = true;
            this.descColorRadioButton.Location = new System.Drawing.Point(7, 85);
            this.descColorRadioButton.Name = "descColorRadioButton";
            this.descColorRadioButton.Size = new System.Drawing.Size(127, 24);
            this.descColorRadioButton.TabIndex = 1;
            this.descColorRadioButton.TabStop = true;
            this.descColorRadioButton.Text = "По убыванию";
            this.descColorRadioButton.UseVisualStyleBackColor = true;
            // 
            // ascColorRadioButton
            // 
            this.ascColorRadioButton.AutoSize = true;
            this.ascColorRadioButton.Location = new System.Drawing.Point(6, 43);
            this.ascColorRadioButton.Name = "ascColorRadioButton";
            this.ascColorRadioButton.Size = new System.Drawing.Size(146, 24);
            this.ascColorRadioButton.TabIndex = 0;
            this.ascColorRadioButton.TabStop = true;
            this.ascColorRadioButton.Text = "По возрастанию";
            this.ascColorRadioButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(769, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Цвета";
            // 
            // colorDataGridView
            // 
            this.colorDataGridView.AllowUserToAddRows = false;
            this.colorDataGridView.AllowUserToDeleteRows = false;
            this.colorDataGridView.AllowUserToResizeColumns = false;
            this.colorDataGridView.AllowUserToResizeRows = false;
            this.colorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.colorDataGridView.Location = new System.Drawing.Point(637, 69);
            this.colorDataGridView.Name = "colorDataGridView";
            this.colorDataGridView.ReadOnly = true;
            this.colorDataGridView.RowHeadersVisible = false;
            this.colorDataGridView.RowHeadersWidth = 51;
            this.colorDataGridView.RowTemplate.Height = 50;
            this.colorDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colorDataGridView.Size = new System.Drawing.Size(312, 312);
            this.colorDataGridView.TabIndex = 4;
            this.colorDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.DataGridView_ColumnStateChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.getSizesButton);
            this.groupBox4.Controls.Add(this.countSizeTextBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.descSizeRadioButton);
            this.groupBox4.Controls.Add(this.ascSizeRadioButton);
            this.groupBox4.Location = new System.Drawing.Point(351, 429);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 320);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Работа с размерами";
            // 
            // getSizesButton
            // 
            this.getSizesButton.Location = new System.Drawing.Point(6, 201);
            this.getSizesButton.Name = "getSizesButton";
            this.getSizesButton.Size = new System.Drawing.Size(237, 113);
            this.getSizesButton.TabIndex = 4;
            this.getSizesButton.Text = "Получить размеры";
            this.getSizesButton.UseVisualStyleBackColor = true;
            this.getSizesButton.Click += new System.EventHandler(this.getSizesButton_Click);
            // 
            // countSizeTextBox
            // 
            this.countSizeTextBox.Location = new System.Drawing.Point(6, 157);
            this.countSizeTextBox.MaxLength = 11;
            this.countSizeTextBox.Name = "countSizeTextBox";
            this.countSizeTextBox.Size = new System.Drawing.Size(238, 27);
            this.countSizeTextBox.TabIndex = 3;
            this.countSizeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Количество выводимых строк:";
            // 
            // descSizeRadioButton
            // 
            this.descSizeRadioButton.AutoSize = true;
            this.descSizeRadioButton.Location = new System.Drawing.Point(7, 85);
            this.descSizeRadioButton.Name = "descSizeRadioButton";
            this.descSizeRadioButton.Size = new System.Drawing.Size(127, 24);
            this.descSizeRadioButton.TabIndex = 1;
            this.descSizeRadioButton.TabStop = true;
            this.descSizeRadioButton.Text = "По убыванию";
            this.descSizeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ascSizeRadioButton
            // 
            this.ascSizeRadioButton.AutoSize = true;
            this.ascSizeRadioButton.Location = new System.Drawing.Point(6, 43);
            this.ascSizeRadioButton.Name = "ascSizeRadioButton";
            this.ascSizeRadioButton.Size = new System.Drawing.Size(146, 24);
            this.ascSizeRadioButton.TabIndex = 0;
            this.ascSizeRadioButton.TabStop = true;
            this.ascSizeRadioButton.Text = "По возрастанию";
            this.ascSizeRadioButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Размеры";
            // 
            // sizeDataGridView
            // 
            this.sizeDataGridView.AllowUserToAddRows = false;
            this.sizeDataGridView.AllowUserToDeleteRows = false;
            this.sizeDataGridView.AllowUserToResizeColumns = false;
            this.sizeDataGridView.AllowUserToResizeRows = false;
            this.sizeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sizeDataGridView.Location = new System.Drawing.Point(12, 437);
            this.sizeDataGridView.Name = "sizeDataGridView";
            this.sizeDataGridView.ReadOnly = true;
            this.sizeDataGridView.RowHeadersVisible = false;
            this.sizeDataGridView.RowHeadersWidth = 51;
            this.sizeDataGridView.RowTemplate.Height = 50;
            this.sizeDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sizeDataGridView.Size = new System.Drawing.Size(312, 312);
            this.sizeDataGridView.TabIndex = 10;
            this.sizeDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.DataGridView_ColumnStateChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.getCostsButton);
            this.groupBox3.Controls.Add(this.countCostTextBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.descCostRadioButton);
            this.groupBox3.Controls.Add(this.ascCostRadioButton);
            this.groupBox3.Location = new System.Drawing.Point(976, 429);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 320);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Работа со стоимостями";
            // 
            // getCostsButton
            // 
            this.getCostsButton.Location = new System.Drawing.Point(6, 201);
            this.getCostsButton.Name = "getCostsButton";
            this.getCostsButton.Size = new System.Drawing.Size(237, 113);
            this.getCostsButton.TabIndex = 4;
            this.getCostsButton.Text = "Получить стоимости";
            this.getCostsButton.UseVisualStyleBackColor = true;
            this.getCostsButton.Click += new System.EventHandler(this.getCostsButton_Click);
            // 
            // countCostTextBox
            // 
            this.countCostTextBox.Location = new System.Drawing.Point(6, 157);
            this.countCostTextBox.MaxLength = 11;
            this.countCostTextBox.Name = "countCostTextBox";
            this.countCostTextBox.Size = new System.Drawing.Size(238, 27);
            this.countCostTextBox.TabIndex = 3;
            this.countCostTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Количество выводимых строк:";
            // 
            // descCostRadioButton
            // 
            this.descCostRadioButton.AutoSize = true;
            this.descCostRadioButton.Location = new System.Drawing.Point(7, 85);
            this.descCostRadioButton.Name = "descCostRadioButton";
            this.descCostRadioButton.Size = new System.Drawing.Size(127, 24);
            this.descCostRadioButton.TabIndex = 1;
            this.descCostRadioButton.TabStop = true;
            this.descCostRadioButton.Text = "По убыванию";
            this.descCostRadioButton.UseVisualStyleBackColor = true;
            // 
            // ascCostRadioButton
            // 
            this.ascCostRadioButton.AutoSize = true;
            this.ascCostRadioButton.Location = new System.Drawing.Point(6, 43);
            this.ascCostRadioButton.Name = "ascCostRadioButton";
            this.ascCostRadioButton.Size = new System.Drawing.Size(146, 24);
            this.ascCostRadioButton.TabIndex = 0;
            this.ascCostRadioButton.TabStop = true;
            this.ascCostRadioButton.Text = "По возрастанию";
            this.ascCostRadioButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(756, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Стоимости";
            // 
            // costDataGridView
            // 
            this.costDataGridView.AllowUserToAddRows = false;
            this.costDataGridView.AllowUserToDeleteRows = false;
            this.costDataGridView.AllowUserToResizeColumns = false;
            this.costDataGridView.AllowUserToResizeRows = false;
            this.costDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.costDataGridView.Location = new System.Drawing.Point(637, 437);
            this.costDataGridView.Name = "costDataGridView";
            this.costDataGridView.ReadOnly = true;
            this.costDataGridView.RowHeadersVisible = false;
            this.costDataGridView.RowHeadersWidth = 51;
            this.costDataGridView.RowTemplate.Height = 50;
            this.costDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costDataGridView.Size = new System.Drawing.Size(312, 312);
            this.costDataGridView.TabIndex = 13;
            this.costDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.DataGridView_ColumnStateChanged);
            // 
            // OccurrenceMaterialData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 779);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.costDataGridView);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.sizeDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.colorDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "OccurrenceMaterialData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Встречаемость данных о материалах";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopularMaterialData_FormClosing);
            this.Load += new System.EventHandler(this.PopularMaterialData_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.DataGridView typeDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button getTypesButton;
        private System.Windows.Forms.TextBox countTypeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton descTypeRadioButton;
        private System.Windows.Forms.RadioButton ascTypeRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button getColorsButton;
        private System.Windows.Forms.TextBox countColorTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton descColorRadioButton;
        private System.Windows.Forms.RadioButton ascColorRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView colorDataGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button getSizesButton;
        private System.Windows.Forms.TextBox countSizeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton descSizeRadioButton;
        private System.Windows.Forms.RadioButton ascSizeRadioButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView sizeDataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button getCostsButton;
        private System.Windows.Forms.TextBox countCostTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton descCostRadioButton;
        private System.Windows.Forms.RadioButton ascCostRadioButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView costDataGridView;
    }
}