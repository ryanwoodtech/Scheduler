
namespace C969
{
    partial class AppointmentByConsutantReport
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
            this.ConsultantAppointmentTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConsultantAppointmentTextBox
            // 
            this.ConsultantAppointmentTextBox.Location = new System.Drawing.Point(65, 38);
            this.ConsultantAppointmentTextBox.Multiline = true;
            this.ConsultantAppointmentTextBox.Name = "ConsultantAppointmentTextBox";
            this.ConsultantAppointmentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsultantAppointmentTextBox.Size = new System.Drawing.Size(684, 374);
            this.ConsultantAppointmentTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Appointment by Consultant";
            // 
            // AppointmentByConsutantReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConsultantAppointmentTextBox);
            this.Name = "AppointmentByConsutantReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentByConsutantReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ConsultantAppointmentTextBox;
        private System.Windows.Forms.Label label1;
    }
}