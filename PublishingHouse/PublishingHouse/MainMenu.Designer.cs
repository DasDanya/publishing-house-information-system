﻿
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
            this.orderTab = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeTab = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Tabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderTab,
            this.employeeTab});
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.Size = new System.Drawing.Size(800, 28);
            this.Tabs.TabIndex = 0;
            this.Tabs.Text = "menuStrip1";
            // 
            // orderTab
            // 
            this.orderTab.Name = "orderTab";
            this.orderTab.Size = new System.Drawing.Size(72, 24);
            this.orderTab.Text = "Заказы";
            // 
            // employeeTab
            // 
            this.employeeTab.Name = "employeeTab";
            this.employeeTab.Size = new System.Drawing.Size(105, 24);
            this.employeeTab.Text = "Сотрудники";
            this.employeeTab.Click += new System.EventHandler(this.employeeTab_Click);
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
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Tabs.ResumeLayout(false);
            this.Tabs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Tabs;
        private System.Windows.Forms.ToolStripMenuItem orderTab;
        private System.Windows.Forms.ToolStripMenuItem employeeTab;
    }
}

