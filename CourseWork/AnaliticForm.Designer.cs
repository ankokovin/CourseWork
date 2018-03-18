namespace CourseWork
{
    partial class AnaliticForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.FastQueryButton = new System.Windows.Forms.Button();
            this.CustomQueryButton = new System.Windows.Forms.Button();
            this.XmlButton = new System.Windows.Forms.Button();
            this.ExcelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(248, 288);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // FastQueryButton
            // 
            this.FastQueryButton.Location = new System.Drawing.Point(266, 22);
            this.FastQueryButton.Name = "FastQueryButton";
            this.FastQueryButton.Size = new System.Drawing.Size(165, 23);
            this.FastQueryButton.TabIndex = 1;
            this.FastQueryButton.Text = "Быстрая диаграмма заказы";
            this.FastQueryButton.UseVisualStyleBackColor = true;
            // 
            // CustomQueryButton
            // 
            this.CustomQueryButton.Location = new System.Drawing.Point(266, 51);
            this.CustomQueryButton.Name = "CustomQueryButton";
            this.CustomQueryButton.Size = new System.Drawing.Size(165, 23);
            this.CustomQueryButton.TabIndex = 2;
            this.CustomQueryButton.Text = "Добавить запрос";
            this.CustomQueryButton.UseVisualStyleBackColor = true;
            this.CustomQueryButton.Click += new System.EventHandler(this.CustomQueryButton_Click);
            // 
            // XmlButton
            // 
            this.XmlButton.Location = new System.Drawing.Point(266, 259);
            this.XmlButton.Name = "XmlButton";
            this.XmlButton.Size = new System.Drawing.Size(165, 23);
            this.XmlButton.TabIndex = 3;
            this.XmlButton.Text = "Экспорт в XML";
            this.XmlButton.UseVisualStyleBackColor = true;
            // 
            // ExcelButton
            // 
            this.ExcelButton.Location = new System.Drawing.Point(266, 287);
            this.ExcelButton.Name = "ExcelButton";
            this.ExcelButton.Size = new System.Drawing.Size(165, 23);
            this.ExcelButton.TabIndex = 4;
            this.ExcelButton.Text = "Экспорт в Excel";
            this.ExcelButton.UseVisualStyleBackColor = true;
            // 
            // AnaliticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 352);
            this.Controls.Add(this.ExcelButton);
            this.Controls.Add(this.XmlButton);
            this.Controls.Add(this.CustomQueryButton);
            this.Controls.Add(this.FastQueryButton);
            this.Controls.Add(this.listView1);
            this.Name = "AnaliticForm";
            this.Text = "AnaliticForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button FastQueryButton;
        private System.Windows.Forms.Button CustomQueryButton;
        private System.Windows.Forms.Button XmlButton;
        private System.Windows.Forms.Button ExcelButton;
    }
}