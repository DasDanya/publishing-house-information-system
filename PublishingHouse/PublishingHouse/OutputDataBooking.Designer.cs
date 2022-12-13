
namespace PublishingHouse
{
    partial class OutputDataBooking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputDataBooking));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.reportRichTextBox = new System.Windows.Forms.RichTextBox();
            this.reportRTFButton = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(968, 28);
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
            // reportRichTextBox
            // 
            this.reportRichTextBox.Location = new System.Drawing.Point(12, 42);
            this.reportRichTextBox.Name = "reportRichTextBox";
            this.reportRichTextBox.ReadOnly = true;
            this.reportRichTextBox.Size = new System.Drawing.Size(688, 421);
            this.reportRichTextBox.TabIndex = 1;
            this.reportRichTextBox.Text = "";
            // 
            // reportRTFButton
            // 
            this.reportRTFButton.Location = new System.Drawing.Point(706, 42);
            this.reportRTFButton.Name = "reportRTFButton";
            this.reportRTFButton.Size = new System.Drawing.Size(250, 80);
            this.reportRTFButton.TabIndex = 2;
            this.reportRTFButton.Text = "Загрузить в RTF";
            this.reportRTFButton.UseVisualStyleBackColor = true;
            this.reportRTFButton.Click += new System.EventHandler(this.reportRTFButton_Click);
            // 
            // OutputDataBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 496);
            this.Controls.Add(this.reportRTFButton);
            this.Controls.Add(this.reportRichTextBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "OutputDataBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт о заказе";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OutputDataBooking_FormClosing);
            this.Load += new System.EventHandler(this.OutputDataBooking_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.RichTextBox reportRichTextBox;
        private System.Windows.Forms.Button reportRTFButton;
    }
}