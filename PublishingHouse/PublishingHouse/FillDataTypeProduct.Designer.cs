
namespace PublishingHouse
{
    partial class FillDataTypeProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FillDataTypeProduct));
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backTab = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.marginTextBox = new System.Windows.Forms.TextBox();
            this.saveInputDataButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название типа:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(134, 41);
            this.nameTextBox.MaxLength = 30;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(364, 27);
            this.nameTextBox.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(510, 28);
            this.menuStrip1.TabIndex = 2;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Наценка в %:";
            // 
            // marginTextBox
            // 
            this.marginTextBox.Location = new System.Drawing.Point(134, 94);
            this.marginTextBox.MaxLength = 5;
            this.marginTextBox.Name = "marginTextBox";
            this.marginTextBox.Size = new System.Drawing.Size(364, 27);
            this.marginTextBox.TabIndex = 4;
            this.marginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.marginTextBox_KeyPress);
            // 
            // saveInputDataButton
            // 
            this.saveInputDataButton.Location = new System.Drawing.Point(12, 142);
            this.saveInputDataButton.Name = "saveInputDataButton";
            this.saveInputDataButton.Size = new System.Drawing.Size(486, 64);
            this.saveInputDataButton.TabIndex = 5;
            this.saveInputDataButton.Text = "Сохранить введённые данные";
            this.saveInputDataButton.UseVisualStyleBackColor = true;
            this.saveInputDataButton.Click += new System.EventHandler(this.saveInputDataButton_Click);
            // 
            // FillDataTypeProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 229);
            this.Controls.Add(this.saveInputDataButton);
            this.Controls.Add(this.marginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FillDataTypeProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод данных о типе печатной продукции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FillDataTypeProduct_FormClosing);
            this.Load += new System.EventHandler(this.FillDataTypeProduct_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox marginTextBox;
        private System.Windows.Forms.Button saveInputDataButton;
    }
}