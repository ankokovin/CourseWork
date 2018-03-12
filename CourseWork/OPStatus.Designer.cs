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
            this.SuspendLayout();
            // 
            // AddStatusButton
            // 
            this.AddStatusButton.Location = new System.Drawing.Point(161, 12);
            this.AddStatusButton.Name = "AddStatusButton";
            this.AddStatusButton.Size = new System.Drawing.Size(111, 23);
            this.AddStatusButton.TabIndex = 5;
            this.AddStatusButton.Text = "Добавить статус";
            this.AddStatusButton.UseVisualStyleBackColor = true;
            this.AddStatusButton.Click += new System.EventHandler(this.AddStatusButton_Click);
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Location = new System.Drawing.Point(12, 12);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(143, 20);
            this.StatusTextBox.TabIndex = 4;
            // 
            // OPStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 47);
            this.Controls.Add(this.AddStatusButton);
            this.Controls.Add(this.StatusTextBox);
            this.Name = "OPStatus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddStatusButton;
        private System.Windows.Forms.TextBox StatusTextBox;
    }
}
