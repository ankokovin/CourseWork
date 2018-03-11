namespace CourseWork
{
    partial class OPCity1
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
            this.AddCityButton = new System.Windows.Forms.Button();
            this.CityNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddCityButton
            // 
            this.AddCityButton.Location = new System.Drawing.Point(161, 12);
            this.AddCityButton.Name = "AddCityButton";
            this.AddCityButton.Size = new System.Drawing.Size(111, 23);
            this.AddCityButton.TabIndex = 3;
            this.AddCityButton.Text = "Добавить город";
            this.AddCityButton.UseVisualStyleBackColor = true;
            this.AddCityButton.Click += new System.EventHandler(this.AddCityButton_Click);
            // 
            // CityNameTextBox
            // 
            this.CityNameTextBox.Location = new System.Drawing.Point(12, 12);
            this.CityNameTextBox.Name = "CityNameTextBox";
            this.CityNameTextBox.Size = new System.Drawing.Size(143, 20);
            this.CityNameTextBox.TabIndex = 2;
            // 
            // OPCity1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 66);
            this.Controls.Add(this.AddCityButton);
            this.Controls.Add(this.CityNameTextBox);
            this.Name = "OPCity1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddCityButton;
        private System.Windows.Forms.TextBox CityNameTextBox;
    }
}
