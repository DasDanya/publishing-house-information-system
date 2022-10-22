
namespace PublishingHouse
{
    partial class MaterialMenu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialMenu));
            this.materialDataGridView = new System.Windows.Forms.DataGridView();
            this.materialGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataGridView)).BeginInit();
            this.materialGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialDataGridView
            // 
            this.materialDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialDataGridView.Location = new System.Drawing.Point(12, 12);
            this.materialDataGridView.Name = "materialDataGridView";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.materialDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.materialDataGridView.RowHeadersVisible = false;
            this.materialDataGridView.RowHeadersWidth = 51;
            this.materialDataGridView.RowTemplate.Height = 29;
            this.materialDataGridView.Size = new System.Drawing.Size(659, 371);
            this.materialDataGridView.TabIndex = 0;
            // 
            // materialGroupBox
            // 
            this.materialGroupBox.Controls.Add(this.label3);
            this.materialGroupBox.Controls.Add(this.comboBox1);
            this.materialGroupBox.Controls.Add(this.label4);
            this.materialGroupBox.Controls.Add(this.label2);
            this.materialGroupBox.Controls.Add(this.typeComboBox);
            this.materialGroupBox.Controls.Add(this.label1);
            this.materialGroupBox.Location = new System.Drawing.Point(693, 12);
            this.materialGroupBox.Name = "materialGroupBox";
            this.materialGroupBox.Size = new System.Drawing.Size(379, 371);
            this.materialGroupBox.TabIndex = 1;
            this.materialGroupBox.TabStop = false;
            this.materialGroupBox.Text = "Работа с данными";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выберите цвет из списка или введите вручную";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Белый",
            "Голубой",
            "Жёлтый",
            "Зелёный",
            "Красный",
            "Оранжевый",
            "Серый",
            "Синий",
            "Фиолетовый",
            "Чёрный"});
            this.comboBox1.Location = new System.Drawing.Point(144, 158);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 28);
            this.comboBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Цвет материала:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите тип из списка или введите вручную";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Бумага для глубокой печати",
            "Газетная бумага",
            "Глянцевая бумага",
            "Матовая бумага",
            "Мелованная бумага",
            "Обложечная бумага",
            "Офсетная бумага",
            "Типографская бумага",
            "Форзацная бумага"});
            this.typeComboBox.Location = new System.Drawing.Point(144, 73);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(229, 28);
            this.typeComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип материала:";
            // 
            // MaterialMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 450);
            this.Controls.Add(this.materialGroupBox);
            this.Controls.Add(this.materialDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MaterialMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Материалы";
            ((System.ComponentModel.ISupportInitialize)(this.materialDataGridView)).EndInit();
            this.materialGroupBox.ResumeLayout(false);
            this.materialGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView materialDataGridView;
        private System.Windows.Forms.GroupBox materialGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}