
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
            this.label1 = new System.Windows.Forms.Label();
            this.productPictureBox = new System.Windows.Forms.PictureBox();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.processingTab = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTab = new System.Windows.Forms.ToolStripMenuItem();
            this.inputDataButton = new System.Windows.Forms.Button();
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
            this.productPictureBox.TabIndex = 4;
            this.productPictureBox.TabStop = false;
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
            this.groupBox1.Controls.Add(this.inputDataButton);
            this.groupBox1.Controls.Add(this.menuStrip2);
            this.groupBox1.Location = new System.Drawing.Point(13, 427);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1179, 215);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными";
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
            // 
            // searchTab
            // 
            this.searchTab.Image = ((System.Drawing.Image)(resources.GetObject("searchTab.Image")));
            this.searchTab.Name = "searchTab";
            this.searchTab.Size = new System.Drawing.Size(86, 24);
            this.searchTab.Text = "Поиск";
            // 
            // inputDataButton
            // 
            this.inputDataButton.Location = new System.Drawing.Point(6, 63);
            this.inputDataButton.Name = "inputDataButton";
            this.inputDataButton.Size = new System.Drawing.Size(290, 55);
            this.inputDataButton.TabIndex = 1;
            this.inputDataButton.Text = "Ввести данные";
            this.inputDataButton.UseVisualStyleBackColor = true;
            this.inputDataButton.Click += new System.EventHandler(this.inputDataButton_Click);
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
    }
}