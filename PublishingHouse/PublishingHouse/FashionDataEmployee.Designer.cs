
namespace PublishingHouse
{
    partial class FashionDataEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FashionDataEmployee));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.fashionEmployeesDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.getEmployeesButton = new System.Windows.Forms.Button();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descRadioButton = new System.Windows.Forms.RadioButton();
            this.ascRadioButton = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fashionEmployeesDataGridView)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1018, 28);
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
            // fashionEmployeesDataGridView
            // 
            this.fashionEmployeesDataGridView.AllowUserToAddRows = false;
            this.fashionEmployeesDataGridView.AllowUserToDeleteRows = false;
            this.fashionEmployeesDataGridView.AllowUserToResizeColumns = false;
            this.fashionEmployeesDataGridView.AllowUserToResizeRows = false;
            this.fashionEmployeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fashionEmployeesDataGridView.Location = new System.Drawing.Point(12, 38);
            this.fashionEmployeesDataGridView.Name = "fashionEmployeesDataGridView";
            this.fashionEmployeesDataGridView.ReadOnly = true;
            this.fashionEmployeesDataGridView.RowHeadersVisible = false;
            this.fashionEmployeesDataGridView.RowHeadersWidth = 51;
            this.fashionEmployeesDataGridView.RowTemplate.Height = 50;
            this.fashionEmployeesDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fashionEmployeesDataGridView.Size = new System.Drawing.Size(648, 326);
            this.fashionEmployeesDataGridView.TabIndex = 1;
            this.fashionEmployeesDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.fashionEmployeesDataGridView_ColumnStateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getEmployeesButton);
            this.groupBox1.Controls.Add(this.countTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.descRadioButton);
            this.groupBox1.Controls.Add(this.ascRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(698, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 326);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
            // 
            // getEmployeesButton
            // 
            this.getEmployeesButton.Location = new System.Drawing.Point(7, 197);
            this.getEmployeesButton.Name = "getEmployeesButton";
            this.getEmployeesButton.Size = new System.Drawing.Size(286, 123);
            this.getEmployeesButton.TabIndex = 4;
            this.getEmployeesButton.Text = "Получить сотрудников";
            this.getEmployeesButton.UseVisualStyleBackColor = true;
            this.getEmployeesButton.Click += new System.EventHandler(this.getEmployeesButton_Click);
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(7, 148);
            this.countTextBox.MaxLength = 5;
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(286, 27);
            this.countTextBox.TabIndex = 3;
            this.countTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.countTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество выводимых строк:";
            // 
            // descRadioButton
            // 
            this.descRadioButton.AutoSize = true;
            this.descRadioButton.Location = new System.Drawing.Point(7, 84);
            this.descRadioButton.Name = "descRadioButton";
            this.descRadioButton.Size = new System.Drawing.Size(127, 24);
            this.descRadioButton.TabIndex = 1;
            this.descRadioButton.TabStop = true;
            this.descRadioButton.Text = "По убыванию";
            this.descRadioButton.UseVisualStyleBackColor = true;
            // 
            // ascRadioButton
            // 
            this.ascRadioButton.AutoSize = true;
            this.ascRadioButton.Location = new System.Drawing.Point(7, 44);
            this.ascRadioButton.Name = "ascRadioButton";
            this.ascRadioButton.Size = new System.Drawing.Size(146, 24);
            this.ascRadioButton.TabIndex = 0;
            this.ascRadioButton.TabStop = true;
            this.ascRadioButton.Text = "По возрастанию";
            this.ascRadioButton.UseVisualStyleBackColor = true;
            // 
            // FashionDataEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 398);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fashionEmployeesDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FashionDataEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мода сотрудников";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FashionDataEmployee_FormClosing);
            this.Load += new System.EventHandler(this.FashionDataEmployee_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fashionEmployeesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.DataGridView fashionEmployeesDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ascRadioButton;
        private System.Windows.Forms.RadioButton descRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Button getEmployeesButton;
    }
}