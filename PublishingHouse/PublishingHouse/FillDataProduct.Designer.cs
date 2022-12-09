
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
            this.selectMaterialButton = new System.Windows.Forms.Button();
            this.resetSelectMateralButton = new System.Windows.Forms.Button();
            this.backSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDataGridView)).BeginInit();
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
            this.toDataGridView.AllowUserToResizeColumns = false;
            this.toDataGridView.AllowUserToResizeRows = false;
            this.toDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.backSelect,
            this.type,
            this.color,
            this.size,
            this.cost});
            this.toDataGridView.Location = new System.Drawing.Point(723, 31);
            this.toDataGridView.Name = "toDataGridView";
            this.toDataGridView.RowHeadersVisible = false;
            this.toDataGridView.RowHeadersWidth = 51;
            this.toDataGridView.RowTemplate.Height = 100;
            this.toDataGridView.Size = new System.Drawing.Size(623, 323);
            this.toDataGridView.TabIndex = 2;
            this.toDataGridView.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.fromDataGridView_ColumnStateChanged);
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
            // FillDataProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 650);
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn backSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
    }
}