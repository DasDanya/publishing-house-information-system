
namespace PublishingHouse
{
    partial class FashionTypeProductMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FashionTypeProductMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.fashionTypeProductDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ascRadioButton = new System.Windows.Forms.RadioButton();
            this.descRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.getTypeProductButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fashionTypeProductDataGridView)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1004, 28);
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
            // fashionTypeProductDataGridView
            // 
            this.fashionTypeProductDataGridView.AllowUserToAddRows = false;
            this.fashionTypeProductDataGridView.AllowUserToDeleteRows = false;
            this.fashionTypeProductDataGridView.AllowUserToResizeColumns = false;
            this.fashionTypeProductDataGridView.AllowUserToResizeRows = false;
            this.fashionTypeProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fashionTypeProductDataGridView.Location = new System.Drawing.Point(12, 44);
            this.fashionTypeProductDataGridView.Name = "fashionTypeProductDataGridView";
            this.fashionTypeProductDataGridView.ReadOnly = true;
            this.fashionTypeProductDataGridView.RowHeadersVisible = false;
            this.fashionTypeProductDataGridView.RowHeadersWidth = 51;
            this.fashionTypeProductDataGridView.RowTemplate.Height = 50;
            this.fashionTypeProductDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fashionTypeProductDataGridView.Size = new System.Drawing.Size(589, 365);
            this.fashionTypeProductDataGridView.TabIndex = 1;
            this.fashionTypeProductDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.fashionTypeProductDataGridView_ColumnStateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getTypeProductButton);
            this.groupBox1.Controls.Add(this.countTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.descRadioButton);
            this.groupBox1.Controls.Add(this.ascRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(630, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 315);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
            // 
            // ascRadioButton
            // 
            this.ascRadioButton.AutoSize = true;
            this.ascRadioButton.Location = new System.Drawing.Point(6, 38);
            this.ascRadioButton.Name = "ascRadioButton";
            this.ascRadioButton.Size = new System.Drawing.Size(146, 24);
            this.ascRadioButton.TabIndex = 0;
            this.ascRadioButton.TabStop = true;
            this.ascRadioButton.Text = "По возрастанию";
            this.ascRadioButton.UseVisualStyleBackColor = true;
            // 
            // descRadioButton
            // 
            this.descRadioButton.AutoSize = true;
            this.descRadioButton.Location = new System.Drawing.Point(6, 80);
            this.descRadioButton.Name = "descRadioButton";
            this.descRadioButton.Size = new System.Drawing.Size(127, 24);
            this.descRadioButton.TabIndex = 1;
            this.descRadioButton.TabStop = true;
            this.descRadioButton.Text = "По убыванию";
            this.descRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество вводимых строк:";
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(6, 145);
            this.countTextBox.MaxLength = 5;
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(341, 27);
            this.countTextBox.TabIndex = 3;
            this.countTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.countTextBox_KeyPress);
            // 
            // getTypeProductButton
            // 
            this.getTypeProductButton.Location = new System.Drawing.Point(6, 195);
            this.getTypeProductButton.Name = "getTypeProductButton";
            this.getTypeProductButton.Size = new System.Drawing.Size(341, 114);
            this.getTypeProductButton.TabIndex = 4;
            this.getTypeProductButton.Text = "Получить типы печатной продукции";
            this.getTypeProductButton.UseVisualStyleBackColor = true;
            this.getTypeProductButton.Click += new System.EventHandler(this.getTypeProductButton_Click);
            // 
            // FashionTypeProductMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fashionTypeProductDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FashionTypeProductMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мода данных о типах печатной продукции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FashionTypeProductMenu_FormClosing);
            this.Load += new System.EventHandler(this.FashionTypeProductMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fashionTypeProductDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.DataGridView fashionTypeProductDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton descRadioButton;
        private System.Windows.Forms.RadioButton ascRadioButton;
        private System.Windows.Forms.Button getTypeProductButton;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Label label1;
    }
}