
namespace C969
{
    partial class SchedulerAddAppointment
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
            this.AddAppointmentLabel = new System.Windows.Forms.Label();
            this.AddAppointmentCustomerId = new System.Windows.Forms.Label();
            this.AddAppointmentCustomerComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AddAppointmentLabel
            // 
            this.AddAppointmentLabel.AutoSize = true;
            this.AddAppointmentLabel.Font = new System.Drawing.Font("Adobe Devanagari", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAppointmentLabel.Location = new System.Drawing.Point(106, 34);
            this.AddAppointmentLabel.Name = "AddAppointmentLabel";
            this.AddAppointmentLabel.Size = new System.Drawing.Size(237, 43);
            this.AddAppointmentLabel.TabIndex = 0;
            this.AddAppointmentLabel.Text = "Add Appointment";
            // 
            // AddAppointmentCustomerId
            // 
            this.AddAppointmentCustomerId.AutoSize = true;
            this.AddAppointmentCustomerId.Font = new System.Drawing.Font("Adobe Devanagari", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAppointmentCustomerId.Location = new System.Drawing.Point(50, 106);
            this.AddAppointmentCustomerId.Name = "AddAppointmentCustomerId";
            this.AddAppointmentCustomerId.Size = new System.Drawing.Size(104, 33);
            this.AddAppointmentCustomerId.TabIndex = 1;
            this.AddAppointmentCustomerId.Text = "Customer";
            // 
            // AddAppointmentCustomerComboBox
            // 
            this.AddAppointmentCustomerComboBox.FormattingEnabled = true;
            this.AddAppointmentCustomerComboBox.Location = new System.Drawing.Point(210, 113);
            this.AddAppointmentCustomerComboBox.Name = "AddAppointmentCustomerComboBox";
            this.AddAppointmentCustomerComboBox.Size = new System.Drawing.Size(167, 21);
            this.AddAppointmentCustomerComboBox.TabIndex = 2;
            // 
            // SchedulerAddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 611);
            this.Controls.Add(this.AddAppointmentCustomerComboBox);
            this.Controls.Add(this.AddAppointmentCustomerId);
            this.Controls.Add(this.AddAppointmentLabel);
            this.Name = "SchedulerAddAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SchedulerAddAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddAppointmentLabel;
        private System.Windows.Forms.Label AddAppointmentCustomerId;
        private System.Windows.Forms.ComboBox AddAppointmentCustomerComboBox;
    }
}