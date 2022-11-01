
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
            this.Select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingHouseDataGridView)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1274, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backTab
            // 
            this.backTab.Name = "backTab";
            this.backTab.Size = new System.Drawing.Size(65, 24);
            this.backTab.Text = "Назад";
            this.backTab.Click += new System.EventHandler(this.backTab_Click);
            // 
            // printingHouseDataGridView
            // 
            this.printingHouseDataGridView.AllowUserToAddRows = false;
            this.printingHouseDataGridView.AllowUserToResizeColumns = false;
            this.printingHouseDataGridView.AllowUserToResizeRows = false;
            this.printingHouseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.printingHouseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.printingHouseDataGridView.Location = new System.Drawing.Point(12, 31);
            this.printingHouseDataGridView.Name = "printingHouseDataGridView";
            this.printingHouseDataGridView.RowHeadersVisible = false;
            this.printingHouseDataGridView.RowHeadersWidth = 51;
            this.printingHouseDataGridView.RowTemplate.Height = 29;
            this.printingHouseDataGridView.Size = new System.Drawing.Size(581, 348);
            this.printingHouseDataGridView.TabIndex = 1;
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
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(632, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 338);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите название типографии";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(93, 73);
            this.nameTextBox.MaxLength = 60;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(248, 27);
            this.nameTextBox.TabIndex = 2;
            // 
            // PrintingHouseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.printingHouseDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PrintingHouseMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Типографии";
            this.Load += new System.EventHandler(this.PrintingHouseMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingHouseDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.DataGridView printingHouseDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Select;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}