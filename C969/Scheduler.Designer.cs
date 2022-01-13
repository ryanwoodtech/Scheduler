
namespace Scheduler
{
    partial class Scheduler
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
            this.SchedulerAppointmentsDGV = new System.Windows.Forms.DataGridView();
            this.AppointmentsLabel = new System.Windows.Forms.Label();
            this.CustomersLabel = new System.Windows.Forms.Label();
            this.SchedulerCustomersDGV = new System.Windows.Forms.DataGridView();
            this.AppointmentsAddButton = new System.Windows.Forms.Button();
            this.AppointmentsUpdateButton = new System.Windows.Forms.Button();
            this.AppointmentsDeleteButton = new System.Windows.Forms.Button();
            this.CustomersDeleteButton = new System.Windows.Forms.Button();
            this.CustomersAddButton = new System.Windows.Forms.Button();
            this.AppointmentsAllRadioButton = new System.Windows.Forms.RadioButton();
            this.AppointmentsMonthRadioButton = new System.Windows.Forms.RadioButton();
            this.AppointmentsWeekRadioButton = new System.Windows.Forms.RadioButton();
            this.CustomersUpdateButton = new System.Windows.Forms.Button();
            this.SchedulerGenerateReportLabel = new System.Windows.Forms.Label();
            this.SchedulerGenerateReportComboBox = new System.Windows.Forms.ComboBox();
            this.SchedulerGenerateReportButton = new System.Windows.Forms.Button();
            this.AppointmentsTextBox = new System.Windows.Forms.TextBox();
            this.CustomersTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerAppointmentsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerCustomersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // SchedulerAppointmentsDGV
            // 
            this.SchedulerAppointmentsDGV.AllowUserToAddRows = false;
            this.SchedulerAppointmentsDGV.AllowUserToDeleteRows = false;
            this.SchedulerAppointmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SchedulerAppointmentsDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.SchedulerAppointmentsDGV.Location = new System.Drawing.Point(259, 118);
            this.SchedulerAppointmentsDGV.MultiSelect = false;
            this.SchedulerAppointmentsDGV.Name = "SchedulerAppointmentsDGV";
            this.SchedulerAppointmentsDGV.RowHeadersVisible = false;
            this.SchedulerAppointmentsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SchedulerAppointmentsDGV.Size = new System.Drawing.Size(601, 257);
            this.SchedulerAppointmentsDGV.TabIndex = 0;
            this.SchedulerAppointmentsDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.SchedulerAppointmentsDGV_DataBindingComplete);
            // 
            // AppointmentsLabel
            // 
            this.AppointmentsLabel.AutoSize = true;
            this.AppointmentsLabel.Location = new System.Drawing.Point(259, 100);
            this.AppointmentsLabel.Name = "AppointmentsLabel";
            this.AppointmentsLabel.Size = new System.Drawing.Size(71, 13);
            this.AppointmentsLabel.TabIndex = 1;
            this.AppointmentsLabel.Text = "Appointments";
            // 
            // CustomersLabel
            // 
            this.CustomersLabel.AutoSize = true;
            this.CustomersLabel.Location = new System.Drawing.Point(259, 449);
            this.CustomersLabel.Name = "CustomersLabel";
            this.CustomersLabel.Size = new System.Drawing.Size(56, 13);
            this.CustomersLabel.TabIndex = 3;
            this.CustomersLabel.Text = "Customers";
            // 
            // SchedulerCustomersDGV
            // 
            this.SchedulerCustomersDGV.AllowUserToAddRows = false;
            this.SchedulerCustomersDGV.AllowUserToDeleteRows = false;
            this.SchedulerCustomersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SchedulerCustomersDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.SchedulerCustomersDGV.Location = new System.Drawing.Point(259, 468);
            this.SchedulerCustomersDGV.MultiSelect = false;
            this.SchedulerCustomersDGV.Name = "SchedulerCustomersDGV";
            this.SchedulerCustomersDGV.RowHeadersVisible = false;
            this.SchedulerCustomersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SchedulerCustomersDGV.Size = new System.Drawing.Size(601, 257);
            this.SchedulerCustomersDGV.TabIndex = 2;
            this.SchedulerCustomersDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.SchedulerCustomersDGV_DataBindingComplete);
            // 
            // AppointmentsAddButton
            // 
            this.AppointmentsAddButton.BackColor = System.Drawing.SystemColors.Control;
            this.AppointmentsAddButton.Location = new System.Drawing.Point(785, 382);
            this.AppointmentsAddButton.Name = "AppointmentsAddButton";
            this.AppointmentsAddButton.Size = new System.Drawing.Size(75, 31);
            this.AppointmentsAddButton.TabIndex = 4;
            this.AppointmentsAddButton.Text = "Add";
            this.AppointmentsAddButton.UseVisualStyleBackColor = false;
            this.AppointmentsAddButton.Click += new System.EventHandler(this.AppointmentsAddButton_Click);
            // 
            // AppointmentsUpdateButton
            // 
            this.AppointmentsUpdateButton.BackColor = System.Drawing.SystemColors.Control;
            this.AppointmentsUpdateButton.Location = new System.Drawing.Point(667, 382);
            this.AppointmentsUpdateButton.Name = "AppointmentsUpdateButton";
            this.AppointmentsUpdateButton.Size = new System.Drawing.Size(112, 31);
            this.AppointmentsUpdateButton.TabIndex = 5;
            this.AppointmentsUpdateButton.Text = "Update Database";
            this.AppointmentsUpdateButton.UseVisualStyleBackColor = false;
            this.AppointmentsUpdateButton.Click += new System.EventHandler(this.AppointmentsUpdateButton_Click);
            // 
            // AppointmentsDeleteButton
            // 
            this.AppointmentsDeleteButton.BackColor = System.Drawing.SystemColors.Control;
            this.AppointmentsDeleteButton.Location = new System.Drawing.Point(255, 382);
            this.AppointmentsDeleteButton.Name = "AppointmentsDeleteButton";
            this.AppointmentsDeleteButton.Size = new System.Drawing.Size(75, 31);
            this.AppointmentsDeleteButton.TabIndex = 6;
            this.AppointmentsDeleteButton.Text = "Delete";
            this.AppointmentsDeleteButton.UseVisualStyleBackColor = false;
            this.AppointmentsDeleteButton.Click += new System.EventHandler(this.AppointmentsDeleteButton_Click);
            // 
            // CustomersDeleteButton
            // 
            this.CustomersDeleteButton.BackColor = System.Drawing.SystemColors.Control;
            this.CustomersDeleteButton.Location = new System.Drawing.Point(259, 731);
            this.CustomersDeleteButton.Name = "CustomersDeleteButton";
            this.CustomersDeleteButton.Size = new System.Drawing.Size(75, 31);
            this.CustomersDeleteButton.TabIndex = 9;
            this.CustomersDeleteButton.Text = "Delete";
            this.CustomersDeleteButton.UseVisualStyleBackColor = false;
            this.CustomersDeleteButton.Click += new System.EventHandler(this.CustomersDeleteButton_Click);
            // 
            // CustomersAddButton
            // 
            this.CustomersAddButton.BackColor = System.Drawing.SystemColors.Control;
            this.CustomersAddButton.Location = new System.Drawing.Point(785, 731);
            this.CustomersAddButton.Name = "CustomersAddButton";
            this.CustomersAddButton.Size = new System.Drawing.Size(75, 31);
            this.CustomersAddButton.TabIndex = 7;
            this.CustomersAddButton.Text = "Add";
            this.CustomersAddButton.UseVisualStyleBackColor = false;
            this.CustomersAddButton.Click += new System.EventHandler(this.CustomersAddButton_Click);
            // 
            // AppointmentsAllRadioButton
            // 
            this.AppointmentsAllRadioButton.AutoSize = true;
            this.AppointmentsAllRadioButton.Checked = true;
            this.AppointmentsAllRadioButton.Location = new System.Drawing.Point(94, 186);
            this.AppointmentsAllRadioButton.Name = "AppointmentsAllRadioButton";
            this.AppointmentsAllRadioButton.Size = new System.Drawing.Size(103, 17);
            this.AppointmentsAllRadioButton.TabIndex = 10;
            this.AppointmentsAllRadioButton.TabStop = true;
            this.AppointmentsAllRadioButton.Text = "All Appointments";
            this.AppointmentsAllRadioButton.UseVisualStyleBackColor = true;
            this.AppointmentsAllRadioButton.CheckedChanged += new System.EventHandler(this.AppointmentsAllRadioButton_CheckedChanged);
            // 
            // AppointmentsMonthRadioButton
            // 
            this.AppointmentsMonthRadioButton.AutoSize = true;
            this.AppointmentsMonthRadioButton.Location = new System.Drawing.Point(94, 226);
            this.AppointmentsMonthRadioButton.Name = "AppointmentsMonthRadioButton";
            this.AppointmentsMonthRadioButton.Size = new System.Drawing.Size(141, 17);
            this.AppointmentsMonthRadioButton.TabIndex = 11;
            this.AppointmentsMonthRadioButton.Text = "Appointments this Month";
            this.AppointmentsMonthRadioButton.UseVisualStyleBackColor = true;
            this.AppointmentsMonthRadioButton.Click += new System.EventHandler(this.AppointmentsMonthRadioButton_Click);
            // 
            // AppointmentsWeekRadioButton
            // 
            this.AppointmentsWeekRadioButton.AutoSize = true;
            this.AppointmentsWeekRadioButton.Location = new System.Drawing.Point(94, 266);
            this.AppointmentsWeekRadioButton.Name = "AppointmentsWeekRadioButton";
            this.AppointmentsWeekRadioButton.Size = new System.Drawing.Size(140, 17);
            this.AppointmentsWeekRadioButton.TabIndex = 12;
            this.AppointmentsWeekRadioButton.Text = "Appointments this Week";
            this.AppointmentsWeekRadioButton.UseVisualStyleBackColor = true;
            this.AppointmentsWeekRadioButton.Click += new System.EventHandler(this.AppointmentsWeekRadioButton_Click);
            // 
            // CustomersUpdateButton
            // 
            this.CustomersUpdateButton.BackColor = System.Drawing.SystemColors.Control;
            this.CustomersUpdateButton.Location = new System.Drawing.Point(667, 731);
            this.CustomersUpdateButton.Name = "CustomersUpdateButton";
            this.CustomersUpdateButton.Size = new System.Drawing.Size(112, 31);
            this.CustomersUpdateButton.TabIndex = 13;
            this.CustomersUpdateButton.Text = "Update Database";
            this.CustomersUpdateButton.UseVisualStyleBackColor = false;
            this.CustomersUpdateButton.Click += new System.EventHandler(this.CustomersUpdateButton_Click);
            // 
            // SchedulerGenerateReportLabel
            // 
            this.SchedulerGenerateReportLabel.AutoSize = true;
            this.SchedulerGenerateReportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchedulerGenerateReportLabel.Location = new System.Drawing.Point(26, 547);
            this.SchedulerGenerateReportLabel.Name = "SchedulerGenerateReportLabel";
            this.SchedulerGenerateReportLabel.Size = new System.Drawing.Size(171, 25);
            this.SchedulerGenerateReportLabel.TabIndex = 14;
            this.SchedulerGenerateReportLabel.Text = "Generate Report";
            // 
            // SchedulerGenerateReportComboBox
            // 
            this.SchedulerGenerateReportComboBox.FormattingEnabled = true;
            this.SchedulerGenerateReportComboBox.Items.AddRange(new object[] {
            "Appointments by type",
            "Appointments by consultant",
            "Appointments by customer"});
            this.SchedulerGenerateReportComboBox.Location = new System.Drawing.Point(31, 585);
            this.SchedulerGenerateReportComboBox.Name = "SchedulerGenerateReportComboBox";
            this.SchedulerGenerateReportComboBox.Size = new System.Drawing.Size(166, 21);
            this.SchedulerGenerateReportComboBox.TabIndex = 15;
            // 
            // SchedulerGenerateReportButton
            // 
            this.SchedulerGenerateReportButton.Location = new System.Drawing.Point(122, 620);
            this.SchedulerGenerateReportButton.Name = "SchedulerGenerateReportButton";
            this.SchedulerGenerateReportButton.Size = new System.Drawing.Size(75, 30);
            this.SchedulerGenerateReportButton.TabIndex = 16;
            this.SchedulerGenerateReportButton.Text = "Generate";
            this.SchedulerGenerateReportButton.UseVisualStyleBackColor = true;
            this.SchedulerGenerateReportButton.Click += new System.EventHandler(this.SchedulerGenerateReportButton_Click);
            // 
            // AppointmentsTextBox
            // 
            this.AppointmentsTextBox.Location = new System.Drawing.Point(760, 92);
            this.AppointmentsTextBox.Name = "AppointmentsTextBox";
            this.AppointmentsTextBox.Size = new System.Drawing.Size(100, 20);
            this.AppointmentsTextBox.TabIndex = 17;
            this.AppointmentsTextBox.TextChanged += new System.EventHandler(this.AppointmentsTextBox_TextChanged);
            // 
            // CustomersTextBox
            // 
            this.CustomersTextBox.Location = new System.Drawing.Point(760, 442);
            this.CustomersTextBox.Name = "CustomersTextBox";
            this.CustomersTextBox.Size = new System.Drawing.Size(100, 20);
            this.CustomersTextBox.TabIndex = 18;
            this.CustomersTextBox.TextChanged += new System.EventHandler(this.CustomersTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filter by Appointment Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Filter by Customer Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Fira Code", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(365, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 51);
            this.label3.TabIndex = 21;
            this.label3.Text = "Scheduler";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 796);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomersTextBox);
            this.Controls.Add(this.AppointmentsTextBox);
            this.Controls.Add(this.SchedulerGenerateReportButton);
            this.Controls.Add(this.SchedulerGenerateReportComboBox);
            this.Controls.Add(this.SchedulerGenerateReportLabel);
            this.Controls.Add(this.CustomersUpdateButton);
            this.Controls.Add(this.AppointmentsWeekRadioButton);
            this.Controls.Add(this.AppointmentsMonthRadioButton);
            this.Controls.Add(this.AppointmentsAllRadioButton);
            this.Controls.Add(this.CustomersDeleteButton);
            this.Controls.Add(this.CustomersAddButton);
            this.Controls.Add(this.AppointmentsDeleteButton);
            this.Controls.Add(this.AppointmentsUpdateButton);
            this.Controls.Add(this.AppointmentsAddButton);
            this.Controls.Add(this.CustomersLabel);
            this.Controls.Add(this.SchedulerCustomersDGV);
            this.Controls.Add(this.AppointmentsLabel);
            this.Controls.Add(this.SchedulerAppointmentsDGV);
            this.Name = "Scheduler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduler";
            this.Activated += new System.EventHandler(this.Scheduler_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerAppointmentsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerCustomersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label AppointmentsLabel;
        private System.Windows.Forms.Label CustomersLabel;
        private System.Windows.Forms.Button AppointmentsAddButton;
        private System.Windows.Forms.Button AppointmentsUpdateButton;
        private System.Windows.Forms.Button AppointmentsDeleteButton;
        private System.Windows.Forms.Button CustomersDeleteButton;
        private System.Windows.Forms.Button CustomersAddButton;
        private System.Windows.Forms.RadioButton AppointmentsAllRadioButton;
        private System.Windows.Forms.RadioButton AppointmentsMonthRadioButton;
        private System.Windows.Forms.RadioButton AppointmentsWeekRadioButton;
        private System.Windows.Forms.Button CustomersUpdateButton;
        public System.Windows.Forms.DataGridView SchedulerAppointmentsDGV;
        public System.Windows.Forms.DataGridView SchedulerCustomersDGV;
        private System.Windows.Forms.Label SchedulerGenerateReportLabel;
        private System.Windows.Forms.ComboBox SchedulerGenerateReportComboBox;
        private System.Windows.Forms.Button SchedulerGenerateReportButton;
        private System.Windows.Forms.TextBox AppointmentsTextBox;
        private System.Windows.Forms.TextBox CustomersTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}