
namespace Scheduler
{
    partial class AppointmentByCustomerReport
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
            this.CustomerAppointmentTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CustomerAppointmentTextBox
            // 
            this.CustomerAppointmentTextBox.Location = new System.Drawing.Point(58, 38);
            this.CustomerAppointmentTextBox.Multiline = true;
            this.CustomerAppointmentTextBox.Name = "CustomerAppointmentTextBox";
            this.CustomerAppointmentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CustomerAppointmentTextBox.Size = new System.Drawing.Size(684, 374);
            this.CustomerAppointmentTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Appointments by Customer";
            // 
            // AppointmentByCustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomerAppointmentTextBox);
            this.Name = "AppointmentByCustomerReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentByCustomerReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CustomerAppointmentTextBox;
        private System.Windows.Forms.Label label1;
    }
}