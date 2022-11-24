
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.обработкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.Size = new System.Drawing.Size(1425, 28);
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
            this.printingHouseDataGridView.Location = new System.Drawing.Point(13, 32);
            this.printingHouseDataGridView.Name = "printingHouseDataGridView";
            this.printingHouseDataGridView.RowHeadersVisible = false;
            this.printingHouseDataGridView.RowHeadersWidth = 51;
            this.printingHouseDataGridView.RowTemplate.Height = 50;
            this.printingHouseDataGridView.Size = new System.Drawing.Size(1400, 305);
            this.printingHouseDataGridView.TabIndex = 1;
            this.printingHouseDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.printingHouseDataGridView_ColumnStateChanged);
            // 
            // Select
            // 
            this.Select.HeaderText = "Выбрать";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.Width = 125;
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(987, 416);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(211, 86);
            this.inputButton.TabIndex = 22;
            this.inputButton.Text = "Ввести данные";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(696, 416);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(211, 57);
            this.addButton.TabIndex = 21;
            this.addButton.Text = "Добавить типографию";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // workWithPrHouseGroupBox
            // 
            this.workWithPrHouseGroupBox.Controls.Add(this.menuStrip2);
            this.workWithPrHouseGroupBox.Location = new System.Drawing.Point(35, 360);
            this.workWithPrHouseGroupBox.Name = "workWithPrHouseGroupBox";
            this.workWithPrHouseGroupBox.Size = new System.Drawing.Size(600, 224);
            this.workWithPrHouseGroupBox.TabIndex = 23;
            this.workWithPrHouseGroupBox.TabStop = false;
            this.workWithPrHouseGroupBox.Text = "Работа с данными";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обработкаToolStripMenuItem,
            this.поискToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 23);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(594, 28);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // обработкаToolStripMenuItem
            // 
            this.обработкаToolStripMenuItem.Name = "обработкаToolStripMenuItem";
            this.обработкаToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.обработкаToolStripMenuItem.Text = "Обработка";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.поискToolStripMenuItem.Text = "Поиск";
            // 
            // PrintingHouseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 596);
            this.Controls.Add(this.workWithPrHouseGroupBox);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.addButton);
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.GroupBox workWithPrHouseGroupBox;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem обработкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
    }
}