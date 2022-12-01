
namespace PublishingHouse
{
    partial class AuthorizationMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.authorizationButton = new System.Windows.Forms.Button();
            this.hidePasswordButton = new System.Windows.Forms.Button();
            this.openPasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль:";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(108, 40);
            this.loginTextBox.MaxLength = 13;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(259, 27);
            this.loginTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(108, 101);
            this.passwordTextBox.MaxLength = 13;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(259, 27);
            this.passwordTextBox.TabIndex = 3;
            // 
            // authorizationButton
            // 
            this.authorizationButton.Location = new System.Drawing.Point(37, 156);
            this.authorizationButton.Name = "authorizationButton";
            this.authorizationButton.Size = new System.Drawing.Size(330, 44);
            this.authorizationButton.TabIndex = 4;
            this.authorizationButton.Text = "Авторизоваться";
            this.authorizationButton.UseVisualStyleBackColor = true;
            this.authorizationButton.Click += new System.EventHandler(this.authorizationButton_Click);
            // 
            // hidePasswordButton
            // 
            this.hidePasswordButton.BackColor = System.Drawing.Color.White;
            this.hidePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hidePasswordButton.ForeColor = System.Drawing.Color.Black;
            this.hidePasswordButton.Image = ((System.Drawing.Image)(resources.GetObject("hidePasswordButton.Image")));
            this.hidePasswordButton.Location = new System.Drawing.Point(321, 101);
            this.hidePasswordButton.Name = "hidePasswordButton";
            this.hidePasswordButton.Size = new System.Drawing.Size(46, 27);
            this.hidePasswordButton.TabIndex = 5;
            this.hidePasswordButton.UseVisualStyleBackColor = false;
            this.hidePasswordButton.Click += new System.EventHandler(this.hidePasswordButton_Click);
            // 
            // openPasswordButton
            // 
            this.openPasswordButton.BackColor = System.Drawing.Color.White;
            this.openPasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openPasswordButton.ForeColor = System.Drawing.Color.Black;
            this.openPasswordButton.Image = ((System.Drawing.Image)(resources.GetObject("openPasswordButton.Image")));
            this.openPasswordButton.Location = new System.Drawing.Point(321, 101);
            this.openPasswordButton.Name = "openPasswordButton";
            this.openPasswordButton.Size = new System.Drawing.Size(46, 27);
            this.openPasswordButton.TabIndex = 6;
            this.openPasswordButton.UseVisualStyleBackColor = false;
            this.openPasswordButton.Click += new System.EventHandler(this.openPasswordButton_Click);
            // 
            // AuthorizationMenu
            // 
            this.AcceptButton = this.authorizationButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 241);
            this.Controls.Add(this.openPasswordButton);
            this.Controls.Add(this.hidePasswordButton);
            this.Controls.Add(this.authorizationButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AuthorizationMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthorizationMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button authorizationButton;
        private System.Windows.Forms.Button hidePasswordButton;
        private System.Windows.Forms.Button openPasswordButton;
    }
}