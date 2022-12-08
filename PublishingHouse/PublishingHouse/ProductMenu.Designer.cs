
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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
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
            this.typesProductButton.Location = new System.Drawing.Point(119, 130);
            this.typesProductButton.Name = "typesProductButton";
            this.typesProductButton.Size = new System.Drawing.Size(206, 64);
            this.typesProductButton.TabIndex = 1;
            this.typesProductButton.Text = "Типы печатной продукции";
            this.typesProductButton.UseVisualStyleBackColor = true;
            this.typesProductButton.Click += new System.EventHandler(this.typesProductButton_Click);
            // 
            // ProductMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.Button typesProductButton;
    }
}