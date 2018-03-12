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
            this.AddCityButton = new System.Windows.Forms.Button();
            this.AddStreetButton = new System.Windows.Forms.Button();
            this.AddAddressButton = new System.Windows.Forms.Button();
            this.AddressGroupBox = new System.Windows.Forms.GroupBox();
            this.AddressButton = new System.Windows.Forms.Button();
            this.UsersButton = new System.Windows.Forms.Button();
            this.MeterGroupBox = new System.Windows.Forms.GroupBox();
            this.MeterTypeButton = new System.Windows.Forms.Button();
            this.MeterButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OrderButton = new System.Windows.Forms.Button();
            this.OrderEntryButton = new System.Windows.Forms.Button();
            this.StatusButton = new System.Windows.Forms.Button();
            this.CustomerGroupBox = new System.Windows.Forms.GroupBox();
            this.CustomerButton = new System.Windows.Forms.Button();
            this.WorkerGroupBox = new System.Windows.Forms.GroupBox();
            this.StavkaButton = new System.Windows.Forms.Button();
            this.PersonButton = new System.Windows.Forms.Button();
            this.AddressGroupBox.SuspendLayout();
            this.MeterGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.CustomerGroupBox.SuspendLayout();
            this.WorkerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddCityButton
            // 
            this.AddCityButton.Location = new System.Drawing.Point(6, 11);
            this.AddCityButton.Name = "AddCityButton";
            this.AddCityButton.Size = new System.Drawing.Size(122, 23);
            this.AddCityButton.TabIndex = 0;
            this.AddCityButton.Text = "Города";
            this.AddCityButton.UseVisualStyleBackColor = true;
            this.AddCityButton.Click += new System.EventHandler(this.AddCityButton_Click);
            // 
            // AddStreetButton
            // 
            this.AddStreetButton.Location = new System.Drawing.Point(6, 40);
            this.AddStreetButton.Name = "AddStreetButton";
            this.AddStreetButton.Size = new System.Drawing.Size(122, 23);
            this.AddStreetButton.TabIndex = 1;
            this.AddStreetButton.Text = "Улицы";
            this.AddStreetButton.UseVisualStyleBackColor = true;
            this.AddStreetButton.Click += new System.EventHandler(this.AddStreetButton_Click);
            // 
            // AddAddressButton
            // 
            this.AddAddressButton.Location = new System.Drawing.Point(6, 69);
            this.AddAddressButton.Name = "AddAddressButton";
            this.AddAddressButton.Size = new System.Drawing.Size(122, 23);
            this.AddAddressButton.TabIndex = 2;
            this.AddAddressButton.Text = "Дома";
            this.AddAddressButton.UseVisualStyleBackColor = true;
            this.AddAddressButton.Click += new System.EventHandler(this.AddAddressButton_Click);
            // 
            // AddressGroupBox
            // 
            this.AddressGroupBox.Controls.Add(this.AddressButton);
            this.AddressGroupBox.Controls.Add(this.AddStreetButton);
            this.AddressGroupBox.Controls.Add(this.AddAddressButton);
            this.AddressGroupBox.Controls.Add(this.AddCityButton);
            this.AddressGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AddressGroupBox.Name = "AddressGroupBox";
            this.AddressGroupBox.Size = new System.Drawing.Size(136, 128);
            this.AddressGroupBox.TabIndex = 3;
            this.AddressGroupBox.TabStop = false;
            this.AddressGroupBox.Text = "Адрес";
            // 
            // AddressButton
            // 
            this.AddressButton.Location = new System.Drawing.Point(6, 98);
            this.AddressButton.Name = "AddressButton";
            this.AddressButton.Size = new System.Drawing.Size(122, 23);
            this.AddressButton.TabIndex = 3;
            this.AddressButton.Text = "Адреса";
            this.AddressButton.UseVisualStyleBackColor = true;
            this.AddressButton.Click += new System.EventHandler(this.AddressButton_Click);
            // 
            // UsersButton
            // 
            this.UsersButton.Location = new System.Drawing.Point(18, 226);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(122, 23);
            this.UsersButton.TabIndex = 4;
            this.UsersButton.Text = "Пользователи";
            this.UsersButton.UseVisualStyleBackColor = true;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // MeterGroupBox
            // 
            this.MeterGroupBox.Controls.Add(this.MeterTypeButton);
            this.MeterGroupBox.Controls.Add(this.MeterButton);
            this.MeterGroupBox.Location = new System.Drawing.Point(12, 146);
            this.MeterGroupBox.Name = "MeterGroupBox";
            this.MeterGroupBox.Size = new System.Drawing.Size(136, 74);
            this.MeterGroupBox.TabIndex = 5;
            this.MeterGroupBox.TabStop = false;
            this.MeterGroupBox.Text = "Счётчики";
            // 
            // MeterTypeButton
            // 
            this.MeterTypeButton.Location = new System.Drawing.Point(7, 18);
            this.MeterTypeButton.Name = "MeterTypeButton";
            this.MeterTypeButton.Size = new System.Drawing.Size(122, 23);
            this.MeterTypeButton.TabIndex = 4;
            this.MeterTypeButton.Text = "Типы счётчиков";
            this.MeterTypeButton.UseVisualStyleBackColor = true;
            this.MeterTypeButton.Click += new System.EventHandler(this.MeterTypeButton_Click);
            // 
            // MeterButton
            // 
            this.MeterButton.Location = new System.Drawing.Point(7, 45);
            this.MeterButton.Name = "MeterButton";
            this.MeterButton.Size = new System.Drawing.Size(122, 23);
            this.MeterButton.TabIndex = 5;
            this.MeterButton.Text = "Счётчики";
            this.MeterButton.UseVisualStyleBackColor = true;
            this.MeterButton.Click += new System.EventHandler(this.MeterButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StatusButton);
            this.groupBox2.Controls.Add(this.OrderEntryButton);
            this.groupBox2.Controls.Add(this.OrderButton);
            this.groupBox2.Location = new System.Drawing.Point(154, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 92);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Заказы";
            // 
            // OrderButton
            // 
            this.OrderButton.Location = new System.Drawing.Point(6, 11);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(122, 23);
            this.OrderButton.TabIndex = 1;
            this.OrderButton.Text = "Заказы";
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click);
            // 
            // OrderEntryButton
            // 
            this.OrderEntryButton.Location = new System.Drawing.Point(7, 39);
            this.OrderEntryButton.Name = "OrderEntryButton";
            this.OrderEntryButton.Size = new System.Drawing.Size(122, 23);
            this.OrderEntryButton.TabIndex = 2;
            this.OrderEntryButton.Text = "Заказные позиции";
            this.OrderEntryButton.UseCompatibleTextRendering = true;
            this.OrderEntryButton.UseVisualStyleBackColor = true;
            this.OrderEntryButton.Click += new System.EventHandler(this.OrderEntryButton_Click);
            // 
            // StatusButton
            // 
            this.StatusButton.Location = new System.Drawing.Point(6, 68);
            this.StatusButton.Name = "StatusButton";
            this.StatusButton.Size = new System.Drawing.Size(122, 23);
            this.StatusButton.TabIndex = 3;
            this.StatusButton.Text = "Статусы заказа";
            this.StatusButton.UseVisualStyleBackColor = true;
            this.StatusButton.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // CustomerGroupBox
            // 
            this.CustomerGroupBox.Controls.Add(this.CustomerButton);
            this.CustomerGroupBox.Location = new System.Drawing.Point(155, 113);
            this.CustomerGroupBox.Name = "CustomerGroupBox";
            this.CustomerGroupBox.Size = new System.Drawing.Size(136, 74);
            this.CustomerGroupBox.TabIndex = 7;
            this.CustomerGroupBox.TabStop = false;
            this.CustomerGroupBox.Text = "Заказчики";
            // 
            // CustomerButton
            // 
            this.CustomerButton.Location = new System.Drawing.Point(7, 18);
            this.CustomerButton.Name = "CustomerButton";
            this.CustomerButton.Size = new System.Drawing.Size(122, 23);
            this.CustomerButton.TabIndex = 4;
            this.CustomerButton.Text = "Заказчики";
            this.CustomerButton.UseVisualStyleBackColor = true;
            this.CustomerButton.Click += new System.EventHandler(this.CustomerButton_Click);
            // 
            // WorkerGroupBox
            // 
            this.WorkerGroupBox.Controls.Add(this.StavkaButton);
            this.WorkerGroupBox.Controls.Add(this.PersonButton);
            this.WorkerGroupBox.Location = new System.Drawing.Point(155, 187);
            this.WorkerGroupBox.Name = "WorkerGroupBox";
            this.WorkerGroupBox.Size = new System.Drawing.Size(136, 74);
            this.WorkerGroupBox.TabIndex = 8;
            this.WorkerGroupBox.TabStop = false;
            this.WorkerGroupBox.Text = "Работники";
            // 
            // StavkaButton
            // 
            this.StavkaButton.Location = new System.Drawing.Point(8, 45);
            this.StavkaButton.Name = "StavkaButton";
            this.StavkaButton.Size = new System.Drawing.Size(122, 23);
            this.StavkaButton.TabIndex = 6;
            this.StavkaButton.Text = "Ставки";
            this.StavkaButton.UseVisualStyleBackColor = true;
            this.StavkaButton.Click += new System.EventHandler(this.StavkaButton_Click);
            // 
            // PersonButton
            // 
            this.PersonButton.Location = new System.Drawing.Point(7, 18);
            this.PersonButton.Name = "PersonButton";
            this.PersonButton.Size = new System.Drawing.Size(122, 23);
            this.PersonButton.TabIndex = 4;
            this.PersonButton.Text = "Люди";
            this.PersonButton.UseVisualStyleBackColor = true;
            this.PersonButton.Click += new System.EventHandler(this.PersonButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 261);
            this.Controls.Add(this.WorkerGroupBox);
            this.Controls.Add(this.CustomerGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MeterGroupBox);
            this.Controls.Add(this.UsersButton);
            this.Controls.Add(this.AddressGroupBox);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.AddressGroupBox.ResumeLayout(false);
            this.MeterGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.CustomerGroupBox.ResumeLayout(false);
            this.WorkerGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddCityButton;
        private System.Windows.Forms.Button AddStreetButton;
        private System.Windows.Forms.Button AddAddressButton;
        private System.Windows.Forms.GroupBox AddressGroupBox;
        private System.Windows.Forms.Button UsersButton;
        private System.Windows.Forms.Button AddressButton;
        private System.Windows.Forms.GroupBox MeterGroupBox;
        private System.Windows.Forms.Button MeterTypeButton;
        private System.Windows.Forms.Button MeterButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button StatusButton;
        private System.Windows.Forms.Button OrderEntryButton;
        private System.Windows.Forms.Button OrderButton;
        private System.Windows.Forms.GroupBox CustomerGroupBox;
        private System.Windows.Forms.Button CustomerButton;
        private System.Windows.Forms.GroupBox WorkerGroupBox;
        private System.Windows.Forms.Button StavkaButton;
        private System.Windows.Forms.Button PersonButton;
    }
}