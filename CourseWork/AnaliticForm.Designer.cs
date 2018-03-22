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
            this.CustomQueryButton = new System.Windows.Forms.Button();
            this.XmlButton = new System.Windows.Forms.Button();
            this.ExcelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // CustomQueryButton
            // 
            this.CustomQueryButton.Location = new System.Drawing.Point(266, 22);
            this.CustomQueryButton.Name = "CustomQueryButton";
            this.CustomQueryButton.Size = new System.Drawing.Size(165, 23);
            this.CustomQueryButton.TabIndex = 2;
            this.CustomQueryButton.Text = "Добавить запрос";
            this.CustomQueryButton.UseVisualStyleBackColor = true;
            this.CustomQueryButton.Click += new System.EventHandler(this.CustomQueryButton_Click);
            // 
            // XmlButton
            // 
            this.XmlButton.Enabled = false;
            this.XmlButton.Location = new System.Drawing.Point(266, 259);
            this.XmlButton.Name = "XmlButton";
            this.XmlButton.Size = new System.Drawing.Size(165, 23);
            this.XmlButton.TabIndex = 3;
            this.XmlButton.Text = "Экспорт в XML";
            this.XmlButton.UseVisualStyleBackColor = true;
            this.XmlButton.Click += new System.EventHandler(this.XmlButton_Click);
            // 
            // ExcelButton
            // 
            this.ExcelButton.Enabled = false;
            this.ExcelButton.Location = new System.Drawing.Point(266, 287);
            this.ExcelButton.Name = "ExcelButton";
            this.ExcelButton.Size = new System.Drawing.Size(165, 23);
            this.ExcelButton.TabIndex = 4;
            this.ExcelButton.Text = "Экспорт в Excel";
            this.ExcelButton.UseVisualStyleBackColor = true;
            this.ExcelButton.Click += new System.EventHandler(this.ExcelButton_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(266, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Прогрузить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(248, 288);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(437, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(595, 288);
            this.tabControl1.TabIndex = 7;
            // 
            // AnaliticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 352);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExcelButton);
            this.Controls.Add(this.XmlButton);
            this.Controls.Add(this.CustomQueryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AnaliticForm";
            this.Text = "AnaliticForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CustomQueryButton;
        private System.Windows.Forms.Button XmlButton;
        private System.Windows.Forms.Button ExcelButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}