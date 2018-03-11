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
            this.UsersButton = new System.Windows.Forms.Button();
            this.AddressGroupBox.SuspendLayout();
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
            this.AddressGroupBox.Controls.Add(this.AddStreetButton);
            this.AddressGroupBox.Controls.Add(this.AddAddressButton);
            this.AddressGroupBox.Controls.Add(this.AddCityButton);
            this.AddressGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AddressGroupBox.Name = "AddressGroupBox";
            this.AddressGroupBox.Size = new System.Drawing.Size(145, 100);
            this.AddressGroupBox.TabIndex = 3;
            this.AddressGroupBox.TabStop = false;
            this.AddressGroupBox.Text = "Адрес";
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
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.UsersButton);
            this.Controls.Add(this.AddressGroupBox);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.AddressGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddCityButton;
        private System.Windows.Forms.Button AddStreetButton;
        private System.Windows.Forms.Button AddAddressButton;
        private System.Windows.Forms.GroupBox AddressGroupBox;
        private System.Windows.Forms.Button UsersButton;
    }
}