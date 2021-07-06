
namespace C969
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
            // AppointmentByCustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CustomerAppointmentTextBox);
            this.Name = "AppointmentByCustomerReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentByCustomerReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CustomerAppointmentTextBox;
    }
}