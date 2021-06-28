
namespace C969
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
            SchedulerAppointmentsDGV = new System.Windows.Forms.DataGridView();
            this.AppointmentsLabel = new System.Windows.Forms.Label();
            this.CustomersLabel = new System.Windows.Forms.Label();
            SchedulerCustomersDGV = new System.Windows.Forms.DataGridView();
            this.AppointmentsAddButton = new System.Windows.Forms.Button();
            this.AppointmentsUpdateButton = new System.Windows.Forms.Button();
            this.AppointmentsDeleteButton = new System.Windows.Forms.Button();
            this.CustomersDeleteButton = new System.Windows.Forms.Button();
            this.CustomersAddButton = new System.Windows.Forms.Button();
            this.AppointmentsAllRadioButton = new System.Windows.Forms.RadioButton();
            this.AppointmentsMonthRadioButton = new System.Windows.Forms.RadioButton();
            this.AppointmentsWeekRadioButton = new System.Windows.Forms.RadioButton();
            this.CustomersUpdateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(SchedulerAppointmentsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SchedulerCustomersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // SchedulerAppointmentsDGV
            // 
            SchedulerAppointmentsDGV.AllowUserToAddRows = false;
            SchedulerAppointmentsDGV.AllowUserToDeleteRows = false;
            SchedulerAppointmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SchedulerAppointmentsDGV.Location = new System.Drawing.Point(280, 40);
            SchedulerAppointmentsDGV.Name = "SchedulerAppointmentsDGV";
            SchedulerAppointmentsDGV.Size = new System.Drawing.Size(601, 257);
            SchedulerAppointmentsDGV.TabIndex = 0;
            // 
            // AppointmentsLabel
            // 
            this.AppointmentsLabel.AutoSize = true;
            this.AppointmentsLabel.Location = new System.Drawing.Point(280, 22);
            this.AppointmentsLabel.Name = "AppointmentsLabel";
            this.AppointmentsLabel.Size = new System.Drawing.Size(71, 13);
            this.AppointmentsLabel.TabIndex = 1;
            this.AppointmentsLabel.Text = "Appointments";
            // 
            // CustomersLabel
            // 
            this.CustomersLabel.AutoSize = true;
            this.CustomersLabel.Location = new System.Drawing.Point(280, 354);
            this.CustomersLabel.Name = "CustomersLabel";
            this.CustomersLabel.Size = new System.Drawing.Size(56, 13);
            this.CustomersLabel.TabIndex = 3;
            this.CustomersLabel.Text = "Customers";
            // 
            // SchedulerCustomersDGV
            // 
            SchedulerCustomersDGV.AllowUserToAddRows = false;
            SchedulerCustomersDGV.AllowUserToDeleteRows = false;
            SchedulerCustomersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SchedulerCustomersDGV.Location = new System.Drawing.Point(280, 373);
            SchedulerCustomersDGV.Name = "SchedulerCustomersDGV";
            SchedulerCustomersDGV.Size = new System.Drawing.Size(601, 257);
            SchedulerCustomersDGV.TabIndex = 2;
            // 
            // AppointmentsAddButton
            // 
            this.AppointmentsAddButton.BackColor = System.Drawing.SystemColors.Control;
            this.AppointmentsAddButton.Location = new System.Drawing.Point(806, 304);
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
            this.AppointmentsUpdateButton.Location = new System.Drawing.Point(688, 304);
            this.AppointmentsUpdateButton.Name = "AppointmentsUpdateButton";
            this.AppointmentsUpdateButton.Size = new System.Drawing.Size(112, 31);
            this.AppointmentsUpdateButton.TabIndex = 5;
            this.AppointmentsUpdateButton.Text = "Update Database";
            this.AppointmentsUpdateButton.UseVisualStyleBackColor = false;
            // 
            // AppointmentsDeleteButton
            // 
            this.AppointmentsDeleteButton.BackColor = System.Drawing.SystemColors.Control;
            this.AppointmentsDeleteButton.Location = new System.Drawing.Point(276, 304);
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
            this.CustomersDeleteButton.Location = new System.Drawing.Point(280, 636);
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
            this.CustomersAddButton.Location = new System.Drawing.Point(806, 636);
            this.CustomersAddButton.Name = "CustomersAddButton";
            this.CustomersAddButton.Size = new System.Drawing.Size(75, 31);
            this.CustomersAddButton.TabIndex = 7;
            this.CustomersAddButton.Text = "Add";
            this.CustomersAddButton.UseVisualStyleBackColor = false;
            // 
            // AppointmentsAllRadioButton
            // 
            this.AppointmentsAllRadioButton.AutoSize = true;
            this.AppointmentsAllRadioButton.Location = new System.Drawing.Point(191, 123);
            this.AppointmentsAllRadioButton.Name = "AppointmentsAllRadioButton";
            this.AppointmentsAllRadioButton.Size = new System.Drawing.Size(36, 17);
            this.AppointmentsAllRadioButton.TabIndex = 10;
            this.AppointmentsAllRadioButton.TabStop = true;
            this.AppointmentsAllRadioButton.Text = "All";
            this.AppointmentsAllRadioButton.UseVisualStyleBackColor = true;
            // 
            // AppointmentsMonthRadioButton
            // 
            this.AppointmentsMonthRadioButton.AutoSize = true;
            this.AppointmentsMonthRadioButton.Location = new System.Drawing.Point(191, 163);
            this.AppointmentsMonthRadioButton.Name = "AppointmentsMonthRadioButton";
            this.AppointmentsMonthRadioButton.Size = new System.Drawing.Size(55, 17);
            this.AppointmentsMonthRadioButton.TabIndex = 11;
            this.AppointmentsMonthRadioButton.TabStop = true;
            this.AppointmentsMonthRadioButton.Text = "Month";
            this.AppointmentsMonthRadioButton.UseVisualStyleBackColor = true;
            // 
            // AppointmentsWeekRadioButton
            // 
            this.AppointmentsWeekRadioButton.AutoSize = true;
            this.AppointmentsWeekRadioButton.Location = new System.Drawing.Point(191, 203);
            this.AppointmentsWeekRadioButton.Name = "AppointmentsWeekRadioButton";
            this.AppointmentsWeekRadioButton.Size = new System.Drawing.Size(54, 17);
            this.AppointmentsWeekRadioButton.TabIndex = 12;
            this.AppointmentsWeekRadioButton.TabStop = true;
            this.AppointmentsWeekRadioButton.Text = "Week";
            this.AppointmentsWeekRadioButton.UseVisualStyleBackColor = true;
            // 
            // CustomersUpdateButton
            // 
            this.CustomersUpdateButton.BackColor = System.Drawing.SystemColors.Control;
            this.CustomersUpdateButton.Location = new System.Drawing.Point(688, 636);
            this.CustomersUpdateButton.Name = "CustomersUpdateButton";
            this.CustomersUpdateButton.Size = new System.Drawing.Size(112, 31);
            this.CustomersUpdateButton.TabIndex = 13;
            this.CustomersUpdateButton.Text = "Update Database";
            this.CustomersUpdateButton.UseVisualStyleBackColor = false;
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 689);
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
            this.Controls.Add(SchedulerCustomersDGV);
            this.Controls.Add(this.AppointmentsLabel);
            this.Controls.Add(SchedulerAppointmentsDGV);
            this.Name = "Scheduler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduler";
            ((System.ComponentModel.ISupportInitialize)(SchedulerAppointmentsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SchedulerCustomersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        static public System.Windows.Forms.DataGridView SchedulerAppointmentsDGV;
        private System.Windows.Forms.Label AppointmentsLabel;
        private System.Windows.Forms.Label CustomersLabel;
        static public System.Windows.Forms.DataGridView SchedulerCustomersDGV;
        private System.Windows.Forms.Button AppointmentsAddButton;
        private System.Windows.Forms.Button AppointmentsUpdateButton;
        private System.Windows.Forms.Button AppointmentsDeleteButton;
        private System.Windows.Forms.Button CustomersDeleteButton;
        private System.Windows.Forms.Button CustomersAddButton;
        private System.Windows.Forms.RadioButton AppointmentsAllRadioButton;
        private System.Windows.Forms.RadioButton AppointmentsMonthRadioButton;
        private System.Windows.Forms.RadioButton AppointmentsWeekRadioButton;
        private System.Windows.Forms.Button CustomersUpdateButton;
    }
}