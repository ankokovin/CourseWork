namespace CourseWork
{
    partial class OperatorForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CustomerTabPage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.INNTextBox = new System.Windows.Forms.TextBox();
            this.CompanyNameTextBox = new System.Windows.Forms.TextBox();
            this.PassportTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AddressTabPage = new System.Windows.Forms.TabPage();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.HouseTextBox = new System.Windows.Forms.TextBox();
            this.StreetTextBox = new System.Windows.Forms.TextBox();
            this.CityTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OrderEntryTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.MeterDataGridView = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.OrderEntryDataGridView = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.CustomerDataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.CustomerTabPage.SuspendLayout();
            this.AddressTabPage.SuspendLayout();
            this.OrderEntryTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeterDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderEntryDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CustomerTabPage);
            this.tabControl1.Controls.Add(this.AddressTabPage);
            this.tabControl1.Controls.Add(this.OrderEntryTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 413);
            this.tabControl1.TabIndex = 0;
            // 
            // CustomerTabPage
            // 
            this.CustomerTabPage.Controls.Add(this.CompanyCheckBox);
            this.CustomerTabPage.Controls.Add(this.CustomerDataGridView);
            this.CustomerTabPage.Controls.Add(this.radioButton3);
            this.CustomerTabPage.Controls.Add(this.radioButton2);
            this.CustomerTabPage.Controls.Add(this.label4);
            this.CustomerTabPage.Controls.Add(this.label3);
            this.CustomerTabPage.Controls.Add(this.label2);
            this.CustomerTabPage.Controls.Add(this.label1);
            this.CustomerTabPage.Controls.Add(this.INNTextBox);
            this.CustomerTabPage.Controls.Add(this.CompanyNameTextBox);
            this.CustomerTabPage.Controls.Add(this.PassportTextBox);
            this.CustomerTabPage.Controls.Add(this.NameTextBox);
            this.CustomerTabPage.Location = new System.Drawing.Point(4, 22);
            this.CustomerTabPage.Name = "CustomerTabPage";
            this.CustomerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CustomerTabPage.Size = new System.Drawing.Size(726, 387);
            this.CustomerTabPage.TabIndex = 0;
            this.CustomerTabPage.Text = "Заказчик";
            this.CustomerTabPage.UseVisualStyleBackColor = true;
            this.CustomerTabPage.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ИНН";
            this.label4.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Название организации";
            this.label3.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Номер паспорта";
            this.label2.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Фамилия Имя Отчество";
            this.label1.UseWaitCursor = true;
            // 
            // INNTextBox
            // 
            this.INNTextBox.Enabled = false;
            this.INNTextBox.Location = new System.Drawing.Point(27, 348);
            this.INNTextBox.Name = "INNTextBox";
            this.INNTextBox.Size = new System.Drawing.Size(100, 20);
            this.INNTextBox.TabIndex = 3;
            this.INNTextBox.UseWaitCursor = true;
            // 
            // CompanyNameTextBox
            // 
            this.CompanyNameTextBox.Enabled = false;
            this.CompanyNameTextBox.Location = new System.Drawing.Point(27, 309);
            this.CompanyNameTextBox.Name = "CompanyNameTextBox";
            this.CompanyNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.CompanyNameTextBox.TabIndex = 2;
            this.CompanyNameTextBox.UseWaitCursor = true;
            // 
            // PassportTextBox
            // 
            this.PassportTextBox.Location = new System.Drawing.Point(27, 128);
            this.PassportTextBox.Name = "PassportTextBox";
            this.PassportTextBox.Size = new System.Drawing.Size(100, 20);
            this.PassportTextBox.TabIndex = 1;
            this.PassportTextBox.UseWaitCursor = true;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(27, 88);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.UseWaitCursor = true;
            // 
            // AddressTabPage
            // 
            this.AddressTabPage.Controls.Add(this.AddressTextBox);
            this.AddressTabPage.Controls.Add(this.HouseTextBox);
            this.AddressTabPage.Controls.Add(this.StreetTextBox);
            this.AddressTabPage.Controls.Add(this.CityTextBox);
            this.AddressTabPage.Controls.Add(this.label8);
            this.AddressTabPage.Controls.Add(this.label5);
            this.AddressTabPage.Controls.Add(this.label7);
            this.AddressTabPage.Controls.Add(this.label6);
            this.AddressTabPage.Location = new System.Drawing.Point(4, 22);
            this.AddressTabPage.Name = "AddressTabPage";
            this.AddressTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AddressTabPage.Size = new System.Drawing.Size(726, 387);
            this.AddressTabPage.TabIndex = 1;
            this.AddressTabPage.Text = "Адрес";
            this.AddressTabPage.UseVisualStyleBackColor = true;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.AddressTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.AddressTextBox.Location = new System.Drawing.Point(248, 229);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddressTextBox.TabIndex = 13;
            this.AddressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            this.AddressTextBox.Enter += new System.EventHandler(this.AddressTextBox_Enter);
            this.AddressTextBox.Leave += new System.EventHandler(this.AddressTextBox_Leave);
            // 
            // HouseTextBox
            // 
            this.HouseTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.HouseTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.HouseTextBox.Location = new System.Drawing.Point(248, 190);
            this.HouseTextBox.Name = "HouseTextBox";
            this.HouseTextBox.Size = new System.Drawing.Size(100, 20);
            this.HouseTextBox.TabIndex = 12;
            this.HouseTextBox.TextChanged += new System.EventHandler(this.HouseTextBox_TextChanged);
            this.HouseTextBox.Enter += new System.EventHandler(this.HouseTextBox_Enter);
            // 
            // StreetTextBox
            // 
            this.StreetTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.StreetTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.StreetTextBox.Location = new System.Drawing.Point(248, 150);
            this.StreetTextBox.Name = "StreetTextBox";
            this.StreetTextBox.Size = new System.Drawing.Size(100, 20);
            this.StreetTextBox.TabIndex = 11;
            this.StreetTextBox.TextChanged += new System.EventHandler(this.StreetTextBox_TextChanged);
            this.StreetTextBox.Enter += new System.EventHandler(this.StreetTextBox_Enter);
            // 
            // CityTextBox
            // 
            this.CityTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CityTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CityTextBox.Location = new System.Drawing.Point(248, 109);
            this.CityTextBox.Name = "CityTextBox";
            this.CityTextBox.Size = new System.Drawing.Size(100, 20);
            this.CityTextBox.TabIndex = 10;
            this.CityTextBox.TextChanged += new System.EventHandler(this.CityTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Квартира";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Город";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Дом";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Улица";
            // 
            // OrderEntryTabPage
            // 
            this.OrderEntryTabPage.Controls.Add(this.tableLayoutPanel1);
            this.OrderEntryTabPage.Location = new System.Drawing.Point(4, 22);
            this.OrderEntryTabPage.Name = "OrderEntryTabPage";
            this.OrderEntryTabPage.Size = new System.Drawing.Size(726, 387);
            this.OrderEntryTabPage.TabIndex = 2;
            this.OrderEntryTabPage.Text = "Заказные позиции";
            this.OrderEntryTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OrderEntryDataGridView, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(726, 387);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.MeterDataGridView, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(357, 381);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить заказную позицию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MeterDataGridView
            // 
            this.MeterDataGridView.AllowUserToAddRows = false;
            this.MeterDataGridView.AllowUserToDeleteRows = false;
            this.MeterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MeterDataGridView.Location = new System.Drawing.Point(3, 34);
            this.MeterDataGridView.MultiSelect = false;
            this.MeterDataGridView.Name = "MeterDataGridView";
            this.MeterDataGridView.ReadOnly = true;
            this.MeterDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.MeterDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MeterDataGridView.Size = new System.Drawing.Size(351, 309);
            this.MeterDataGridView.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Счётчики";
            // 
            // OrderEntryDataGridView
            // 
            this.OrderEntryDataGridView.AllowUserToAddRows = false;
            this.OrderEntryDataGridView.AllowUserToDeleteRows = false;
            this.OrderEntryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderEntryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderEntryDataGridView.Location = new System.Drawing.Point(366, 3);
            this.OrderEntryDataGridView.Name = "OrderEntryDataGridView";
            this.OrderEntryDataGridView.Size = new System.Drawing.Size(357, 381);
            this.OrderEntryDataGridView.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(236, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Добавить заказ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(23, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Новый";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.UseWaitCursor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(187, 41);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(103, 17);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.Text = "Существующий";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.UseWaitCursor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // CustomerDataGridView
            // 
            this.CustomerDataGridView.AllowUserToAddRows = false;
            this.CustomerDataGridView.AllowUserToDeleteRows = false;
            this.CustomerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDataGridView.Location = new System.Drawing.Point(187, 64);
            this.CustomerDataGridView.Name = "CustomerDataGridView";
            this.CustomerDataGridView.ReadOnly = true;
            this.CustomerDataGridView.RowHeadersVisible = false;
            this.CustomerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerDataGridView.Size = new System.Drawing.Size(533, 212);
            this.CustomerDataGridView.TabIndex = 11;
            // 
            // CompanyCheckBox
            // 
            this.CompanyCheckBox.AutoSize = true;
            this.CompanyCheckBox.Location = new System.Drawing.Point(23, 273);
            this.CompanyCheckBox.Name = "CompanyCheckBox";
            this.CompanyCheckBox.Size = new System.Drawing.Size(93, 17);
            this.CompanyCheckBox.TabIndex = 12;
            this.CompanyCheckBox.Text = "Организация";
            this.CompanyCheckBox.UseVisualStyleBackColor = true;
            this.CompanyCheckBox.CheckedChanged += new System.EventHandler(this.radioButton1_Click);
            // 
            // OperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 440);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Name = "OperatorForm";
            this.Text = "OperatorForm";
            this.Load += new System.EventHandler(this.OperatorForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.CustomerTabPage.ResumeLayout(false);
            this.CustomerTabPage.PerformLayout();
            this.AddressTabPage.ResumeLayout(false);
            this.AddressTabPage.PerformLayout();
            this.OrderEntryTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeterDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderEntryDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CustomerTabPage;
        private System.Windows.Forms.TabPage AddressTabPage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage OrderEntryTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView MeterDataGridView;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.TextBox HouseTextBox;
        private System.Windows.Forms.TextBox StreetTextBox;
        private System.Windows.Forms.TextBox CityTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView OrderEntryDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox INNTextBox;
        private System.Windows.Forms.TextBox CompanyNameTextBox;
        private System.Windows.Forms.TextBox PassportTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DataGridView CustomerDataGridView;
        private System.Windows.Forms.CheckBox CompanyCheckBox;
    }
}