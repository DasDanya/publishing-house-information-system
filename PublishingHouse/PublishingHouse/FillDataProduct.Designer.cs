
namespace PublishingHouse
{
    partial class FillDataProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FillDataProduct));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.fromDataGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toDataGridView = new System.Windows.Forms.DataGridView();
            this.backSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectMaterialButton = new System.Windows.Forms.Button();
            this.resetSelectMateralButton = new System.Windows.Forms.Button();
            this.label1212 = new System.Windows.Forms.Label();
            this.productPictureBox = new System.Windows.Forms.PictureBox();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.typeProductDataGridView = new System.Windows.Forms.DataGridView();
            this.selectType = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.numEditionTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeProductDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1358, 28);
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
            // fromDataGridView
            // 
            this.fromDataGridView.AllowUserToAddRows = false;
            this.fromDataGridView.AllowUserToDeleteRows = false;
            this.fromDataGridView.AllowUserToResizeColumns = false;
            this.fromDataGridView.AllowUserToResizeRows = false;
            this.fromDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fromDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.fromDataGridView.Location = new System.Drawing.Point(12, 31);
            this.fromDataGridView.Name = "fromDataGridView";
            this.fromDataGridView.RowHeadersVisible = false;
            this.fromDataGridView.RowHeadersWidth = 51;
            this.fromDataGridView.RowTemplate.Height = 50;
            this.fromDataGridView.Size = new System.Drawing.Size(623, 323);
            this.fromDataGridView.TabIndex = 1;
            this.fromDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.fromDataGridView_ColumnStateChanged);
            // 
            // Select
            // 
            this.Select.HeaderText = "Выбрать";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.Width = 125;
            // 
            // toDataGridView
            // 
            this.toDataGridView.AllowUserToAddRows = false;
            this.toDataGridView.AllowUserToDeleteRows = false;
            this.toDataGridView.AllowUserToResizeColumns = false;
            this.toDataGridView.AllowUserToResizeRows = false;
            this.toDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.backSelect,
            this.type,
            this.color,
            this.size,
            this.cost,
            this.Count});
            this.toDataGridView.Location = new System.Drawing.Point(723, 31);
            this.toDataGridView.Name = "toDataGridView";
            this.toDataGridView.RowHeadersVisible = false;
            this.toDataGridView.RowHeadersWidth = 51;
            this.toDataGridView.RowTemplate.Height = 100;
            this.toDataGridView.Size = new System.Drawing.Size(623, 323);
            this.toDataGridView.TabIndex = 2;
            this.toDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.fromDataGridView_ColumnStateChanged);
            this.toDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.toDataGridView_EditingControlShowing);
            // 
            // backSelect
            // 
            this.backSelect.HeaderText = "Выбрать";
            this.backSelect.MinimumWidth = 6;
            this.backSelect.Name = "backSelect";
            this.backSelect.Width = 125;
            // 
            // type
            // 
            this.type.HeaderText = "Тип";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            this.type.Width = 125;
            // 
            // color
            // 
            this.color.HeaderText = "Цвет";
            this.color.MinimumWidth = 6;
            this.color.Name = "color";
            this.color.Width = 125;
            // 
            // size
            // 
            this.size.HeaderText = "Размер";
            this.size.MinimumWidth = 6;
            this.size.Name = "size";
            this.size.Width = 125;
            // 
            // cost
            // 
            this.cost.HeaderText = "Стоимость";
            this.cost.MinimumWidth = 6;
            this.cost.Name = "cost";
            this.cost.Width = 125;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.MaxInputLength = 5;
            this.Count.MinimumWidth = 6;
            this.Count.Name = "Count";
            this.Count.Width = 125;
            // 
            // selectMaterialButton
            // 
            this.selectMaterialButton.Location = new System.Drawing.Point(641, 31);
            this.selectMaterialButton.Name = "selectMaterialButton";
            this.selectMaterialButton.Size = new System.Drawing.Size(76, 71);
            this.selectMaterialButton.TabIndex = 3;
            this.selectMaterialButton.Text = ">>";
            this.selectMaterialButton.UseVisualStyleBackColor = true;
            this.selectMaterialButton.Click += new System.EventHandler(this.selectMaterialButton_Click);
            // 
            // resetSelectMateralButton
            // 
            this.resetSelectMateralButton.Location = new System.Drawing.Point(641, 283);
            this.resetSelectMateralButton.Name = "resetSelectMateralButton";
            this.resetSelectMateralButton.Size = new System.Drawing.Size(76, 71);
            this.resetSelectMateralButton.TabIndex = 4;
            this.resetSelectMateralButton.Text = "<<";
            this.resetSelectMateralButton.UseVisualStyleBackColor = true;
            this.resetSelectMateralButton.Click += new System.EventHandler(this.resetSelectMateralButton_Click);
            // 
            // label1212
            // 
            this.label1212.AutoSize = true;
            this.label1212.Location = new System.Drawing.Point(45, 369);
            this.label1212.Name = "label1212";
            this.label1212.Size = new System.Drawing.Size(201, 20);
            this.label1212.TabIndex = 5;
            this.label1212.Text = "Макет печатной продукции";
            // 
            // productPictureBox
            // 
            this.productPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("productPictureBox.Image")));
            this.productPictureBox.Location = new System.Drawing.Point(12, 392);
            this.productPictureBox.Name = "productPictureBox";
            this.productPictureBox.Size = new System.Drawing.Size(272, 240);
            this.productPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productPictureBox.TabIndex = 6;
            this.productPictureBox.TabStop = false;
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(12, 641);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(272, 51);
            this.loadImageButton.TabIndex = 7;
            this.loadImageButton.Text = "Загрузить макет";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // typeProductDataGridView
            // 
            this.typeProductDataGridView.AllowUserToAddRows = false;
            this.typeProductDataGridView.AllowUserToDeleteRows = false;
            this.typeProductDataGridView.AllowUserToResizeColumns = false;
            this.typeProductDataGridView.AllowUserToResizeRows = false;
            this.typeProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.typeProductDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectType});
            this.typeProductDataGridView.Location = new System.Drawing.Point(307, 392);
            this.typeProductDataGridView.Name = "typeProductDataGridView";
            this.typeProductDataGridView.RowHeadersVisible = false;
            this.typeProductDataGridView.RowHeadersWidth = 51;
            this.typeProductDataGridView.RowTemplate.Height = 50;
            this.typeProductDataGridView.Size = new System.Drawing.Size(592, 300);
            this.typeProductDataGridView.TabIndex = 8;
            this.typeProductDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.fromDataGridView_ColumnStateChanged);
            // 
            // selectType
            // 
            this.selectType.HeaderText = "Выбрать";
            this.selectType.MinimumWidth = 6;
            this.selectType.Name = "selectType";
            this.selectType.Width = 125;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.countTextBox);
            this.groupBox1.Controls.Add(this.numEditionTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(924, 392);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 240);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод текстовых данных";
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(7, 203);
            this.countTextBox.MaxLength = 4;
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(409, 27);
            this.countTextBox.TabIndex = 5;
            this.countTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numEducationTextBox_KeyPress);
            // 
            // numEditionTextBox
            // 
            this.numEditionTextBox.Location = new System.Drawing.Point(7, 134);
            this.numEditionTextBox.MaxLength = 6;
            this.numEditionTextBox.Name = "numEditionTextBox";
            this.numEditionTextBox.Size = new System.Drawing.Size(409, 27);
            this.numEditionTextBox.TabIndex = 4;
            this.numEditionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numEducationTextBox_KeyPress);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(7, 65);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(409, 27);
            this.nameTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тираж";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Номер тиража";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(931, 639);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(415, 53);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Сохранить введённые данные";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FillDataProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 704);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.typeProductDataGridView);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.productPictureBox);
            this.Controls.Add(this.label1212);
            this.Controls.Add(this.resetSelectMateralButton);
            this.Controls.Add(this.selectMaterialButton);
            this.Controls.Add(this.toDataGridView);
            this.Controls.Add(this.fromDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FillDataProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод данных о печатной продукции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FillDataProduct_FormClosing);
            this.Load += new System.EventHandler(this.FillDataProduct_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeProductDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.DataGridView fromDataGridView;
        private System.Windows.Forms.DataGridView toDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.Button selectMaterialButton;
        private System.Windows.Forms.Button resetSelectMateralButton;
        private System.Windows.Forms.Label label1212;
        private System.Windows.Forms.PictureBox productPictureBox;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.DataGridView typeProductDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox numEditionTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn backSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}