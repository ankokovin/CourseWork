namespace CourseWork
{
    partial class OPStatus
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddStatusButton = new System.Windows.Forms.Button();
            this.StatusTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddStatusButton
            // 
            this.AddStatusButton.Location = new System.Drawing.Point(161, 44);
            this.AddStatusButton.Name = "AddStatusButton";
            this.AddStatusButton.Size = new System.Drawing.Size(111, 23);
            this.AddStatusButton.TabIndex = 5;
            this.AddStatusButton.Text = "Добавить статус";
            this.AddStatusButton.UseVisualStyleBackColor = true;
            this.AddStatusButton.Click += new System.EventHandler(this.AddStatusButton_Click);
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Location = new System.Drawing.Point(12, 44);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(143, 20);
            this.StatusTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название статуса";
            // 
            // OPStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 76);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddStatusButton);
            this.Controls.Add(this.StatusTextBox);
            this.Name = "OPStatus";
            this.Text = "Добавление статуса";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddStatusButton;
        private System.Windows.Forms.TextBox StatusTextBox;
        private System.Windows.Forms.Label label1;
    }
}
