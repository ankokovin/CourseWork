namespace CourseWork
{
    partial class AdminForm
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
            this.UsersButton = new System.Windows.Forms.Button();
            this.MeterTypeButton = new System.Windows.Forms.Button();
            this.MeterButton = new System.Windows.Forms.Button();
            this.StatusButton = new System.Windows.Forms.Button();
            this.OrderEntryButton = new System.Windows.Forms.Button();
            this.OrderButton = new System.Windows.Forms.Button();
            this.CustomerButton = new System.Windows.Forms.Button();
            this.StavkaButton = new System.Windows.Forms.Button();
            this.PersonButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.AddCityButton = new System.Windows.Forms.Button();
            this.HouseButton = new System.Windows.Forms.Button();
            this.AddStreetButton = new System.Windows.Forms.Button();
            this.AddressButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsersButton
            // 
            this.UsersButton.Location = new System.Drawing.Point(184, 291);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(122, 23);
            this.UsersButton.TabIndex = 4;
            this.UsersButton.Text = "Пользователи";
            this.UsersButton.UseVisualStyleBackColor = true;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // MeterTypeButton
            // 
            this.MeterTypeButton.Location = new System.Drawing.Point(41, 210);
            this.MeterTypeButton.Name = "MeterTypeButton";
            this.MeterTypeButton.Size = new System.Drawing.Size(171, 23);
            this.MeterTypeButton.TabIndex = 4;
            this.MeterTypeButton.Text = "Типы счётчиков";
            this.MeterTypeButton.UseVisualStyleBackColor = true;
            this.MeterTypeButton.Click += new System.EventHandler(this.MeterTypeButton_Click);
            // 
            // MeterButton
            // 
            this.MeterButton.Location = new System.Drawing.Point(41, 253);
            this.MeterButton.Name = "MeterButton";
            this.MeterButton.Size = new System.Drawing.Size(171, 23);
            this.MeterButton.TabIndex = 5;
            this.MeterButton.Text = "Счётчики";
            this.MeterButton.UseVisualStyleBackColor = true;
            this.MeterButton.Click += new System.EventHandler(this.MeterButton_Click);
            // 
            // StatusButton
            // 
            this.StatusButton.Location = new System.Drawing.Point(297, 152);
            this.StatusButton.Name = "StatusButton";
            this.StatusButton.Size = new System.Drawing.Size(184, 23);
            this.StatusButton.TabIndex = 3;
            this.StatusButton.Text = "Статусы заказа";
            this.StatusButton.UseVisualStyleBackColor = true;
            this.StatusButton.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // OrderEntryButton
            // 
            this.OrderEntryButton.Location = new System.Drawing.Point(297, 113);
            this.OrderEntryButton.Name = "OrderEntryButton";
            this.OrderEntryButton.Size = new System.Drawing.Size(183, 23);
            this.OrderEntryButton.TabIndex = 2;
            this.OrderEntryButton.Text = "Заказные позиции";
            this.OrderEntryButton.UseCompatibleTextRendering = true;
            this.OrderEntryButton.UseVisualStyleBackColor = true;
            this.OrderEntryButton.Click += new System.EventHandler(this.OrderEntryButton_Click);
            // 
            // OrderButton
            // 
            this.OrderButton.Location = new System.Drawing.Point(296, 77);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(184, 23);
            this.OrderButton.TabIndex = 1;
            this.OrderButton.Text = "Заказы";
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click);
            // 
            // CustomerButton
            // 
            this.CustomerButton.Location = new System.Drawing.Point(296, 34);
            this.CustomerButton.Name = "CustomerButton";
            this.CustomerButton.Size = new System.Drawing.Size(184, 23);
            this.CustomerButton.TabIndex = 4;
            this.CustomerButton.Text = "Заказчики";
            this.CustomerButton.UseVisualStyleBackColor = true;
            this.CustomerButton.Click += new System.EventHandler(this.CustomerButton_Click);
            // 
            // StavkaButton
            // 
            this.StavkaButton.Location = new System.Drawing.Point(296, 253);
            this.StavkaButton.Name = "StavkaButton";
            this.StavkaButton.Size = new System.Drawing.Size(184, 23);
            this.StavkaButton.TabIndex = 6;
            this.StavkaButton.Text = "Ставки";
            this.StavkaButton.UseVisualStyleBackColor = true;
            this.StavkaButton.Click += new System.EventHandler(this.StavkaButton_Click);
            // 
            // PersonButton
            // 
            this.PersonButton.Location = new System.Drawing.Point(296, 210);
            this.PersonButton.Name = "PersonButton";
            this.PersonButton.Size = new System.Drawing.Size(184, 23);
            this.PersonButton.TabIndex = 4;
            this.PersonButton.Text = "Люди";
            this.PersonButton.UseVisualStyleBackColor = true;
            this.PersonButton.Click += new System.EventHandler(this.PersonButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(29, 34);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(124, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Сохранить в XML";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(29, 60);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(124, 23);
            this.LoadButton.TabIndex = 10;
            this.LoadButton.Text = "Загрузить из XML";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML|*.xml";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML|*.xml";
            // 
            // AddCityButton
            // 
            this.AddCityButton.Location = new System.Drawing.Point(41, 34);
            this.AddCityButton.Name = "AddCityButton";
            this.AddCityButton.Size = new System.Drawing.Size(171, 23);
            this.AddCityButton.TabIndex = 0;
            this.AddCityButton.Text = "Города";
            this.AddCityButton.UseVisualStyleBackColor = true;
            this.AddCityButton.Click += new System.EventHandler(this.AddCityButton_Click);
            // 
            // HouseButton
            // 
            this.HouseButton.Location = new System.Drawing.Point(41, 113);
            this.HouseButton.Name = "HouseButton";
            this.HouseButton.Size = new System.Drawing.Size(171, 23);
            this.HouseButton.TabIndex = 2;
            this.HouseButton.Text = "Дома";
            this.HouseButton.UseVisualStyleBackColor = true;
            this.HouseButton.Click += new System.EventHandler(this.HouseButton_Click);
            // 
            // AddStreetButton
            // 
            this.AddStreetButton.Location = new System.Drawing.Point(41, 77);
            this.AddStreetButton.Name = "AddStreetButton";
            this.AddStreetButton.Size = new System.Drawing.Size(171, 23);
            this.AddStreetButton.TabIndex = 1;
            this.AddStreetButton.Text = "Улицы";
            this.AddStreetButton.UseVisualStyleBackColor = true;
            this.AddStreetButton.Click += new System.EventHandler(this.AddStreetButton_Click);
            // 
            // AddressButton
            // 
            this.AddressButton.Location = new System.Drawing.Point(41, 153);
            this.AddressButton.Name = "AddressButton";
            this.AddressButton.Size = new System.Drawing.Size(171, 23);
            this.AddressButton.TabIndex = 3;
            this.AddressButton.Text = "Адреса";
            this.AddressButton.UseVisualStyleBackColor = true;
            this.AddressButton.Click += new System.EventHandler(this.AddressButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddCityButton);
            this.groupBox1.Controls.Add(this.UsersButton);
            this.groupBox1.Controls.Add(this.MeterTypeButton);
            this.groupBox1.Controls.Add(this.HouseButton);
            this.groupBox1.Controls.Add(this.StavkaButton);
            this.groupBox1.Controls.Add(this.AddStreetButton);
            this.groupBox1.Controls.Add(this.MeterButton);
            this.groupBox1.Controls.Add(this.AddressButton);
            this.groupBox1.Controls.Add(this.PersonButton);
            this.groupBox1.Controls.Add(this.OrderButton);
            this.groupBox1.Controls.Add(this.CustomerButton);
            this.groupBox1.Controls.Add(this.StatusButton);
            this.groupBox1.Controls.Add(this.OrderEntryButton);
            this.groupBox1.Location = new System.Drawing.Point(28, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 332);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с сущностями";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SaveButton);
            this.groupBox2.Controls.Add(this.LoadButton);
            this.groupBox2.Location = new System.Drawing.Point(604, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа с БД";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 374);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button UsersButton;
        private System.Windows.Forms.Button MeterTypeButton;
        private System.Windows.Forms.Button MeterButton;
        private System.Windows.Forms.Button StatusButton;
        private System.Windows.Forms.Button OrderEntryButton;
        private System.Windows.Forms.Button OrderButton;
        private System.Windows.Forms.Button CustomerButton;
        private System.Windows.Forms.Button StavkaButton;
        private System.Windows.Forms.Button PersonButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button AddCityButton;
        private System.Windows.Forms.Button HouseButton;
        private System.Windows.Forms.Button AddStreetButton;
        private System.Windows.Forms.Button AddressButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}