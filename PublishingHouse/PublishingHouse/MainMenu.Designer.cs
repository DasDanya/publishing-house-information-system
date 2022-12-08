
namespace PublishingHouse
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.Tabs = new System.Windows.Forms.MenuStrip();
            this.employeeTab = new System.Windows.Forms.ToolStripMenuItem();
            this.materialTab = new System.Windows.Forms.ToolStripMenuItem();
            this.printingHouseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.customersTab = new System.Windows.Forms.ToolStripMenuItem();
            this.productTab = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Tabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeTab,
            this.materialTab,
            this.printingHouseTab,
            this.customersTab,
            this.productTab});
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.Size = new System.Drawing.Size(800, 28);
            this.Tabs.TabIndex = 0;
            this.Tabs.Text = "menuStrip1";
            // 
            // employeeTab
            // 
            this.employeeTab.Image = ((System.Drawing.Image)(resources.GetObject("employeeTab.Image")));
            this.employeeTab.Name = "employeeTab";
            this.employeeTab.Size = new System.Drawing.Size(125, 24);
            this.employeeTab.Text = "Сотрудники";
            this.employeeTab.Click += new System.EventHandler(this.employeeTab_Click);
            // 
            // materialTab
            // 
            this.materialTab.Image = ((System.Drawing.Image)(resources.GetObject("materialTab.Image")));
            this.materialTab.Name = "materialTab";
            this.materialTab.Size = new System.Drawing.Size(123, 24);
            this.materialTab.Text = "Материалы";
            this.materialTab.Click += new System.EventHandler(this.materialTab_Click);
            // 
            // printingHouseTab
            // 
            this.printingHouseTab.Image = ((System.Drawing.Image)(resources.GetObject("printingHouseTab.Image")));
            this.printingHouseTab.Name = "printingHouseTab";
            this.printingHouseTab.Size = new System.Drawing.Size(129, 24);
            this.printingHouseTab.Text = "Типографии";
            this.printingHouseTab.Click += new System.EventHandler(this.printingHouseTab_Click);
            // 
            // customersTab
            // 
            this.customersTab.Image = ((System.Drawing.Image)(resources.GetObject("customersTab.Image")));
            this.customersTab.Name = "customersTab";
            this.customersTab.Size = new System.Drawing.Size(114, 24);
            this.customersTab.Text = "Заказчики";
            this.customersTab.Click += new System.EventHandler(this.customersTab_Click);
            // 
            // productTab
            // 
            this.productTab.Image = ((System.Drawing.Image)(resources.GetObject("productTab.Image")));
            this.productTab.Name = "productTab";
            this.productTab.Size = new System.Drawing.Size(188, 24);
            this.productTab.Text = "Печатная продукция";
            this.productTab.Click += new System.EventHandler(this.productTab_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Tabs;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информационная система издательства";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Tabs.ResumeLayout(false);
            this.Tabs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Tabs;
        private System.Windows.Forms.ToolStripMenuItem employeeTab;
        private System.Windows.Forms.ToolStripMenuItem materialTab;
        private System.Windows.Forms.ToolStripMenuItem printingHouseTab;
        private System.Windows.Forms.ToolStripMenuItem customersTab;
        private System.Windows.Forms.ToolStripMenuItem productTab;
    }
}

