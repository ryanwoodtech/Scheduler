
namespace C969
{
    partial class AppointmentByTypeReport
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
            this.TypeReportTextBox = new System.Windows.Forms.TextBox();
            this.TypeReportLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TypeReportTextBox
            // 
            this.TypeReportTextBox.Location = new System.Drawing.Point(72, 43);
            this.TypeReportTextBox.Multiline = true;
            this.TypeReportTextBox.Name = "TypeReportTextBox";
            this.TypeReportTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TypeReportTextBox.Size = new System.Drawing.Size(617, 374);
            this.TypeReportTextBox.TabIndex = 1;
            // 
            // TypeReportLabel
            // 
            this.TypeReportLabel.AutoSize = true;
            this.TypeReportLabel.Location = new System.Drawing.Point(69, 27);
            this.TypeReportLabel.Name = "TypeReportLabel";
            this.TypeReportLabel.Size = new System.Drawing.Size(186, 13);
            this.TypeReportLabel.TabIndex = 4;
            this.TypeReportLabel.Text = "Appointments of Each Type By Month";
            // 
            // AppointmentByTypeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.TypeReportLabel);
            this.Controls.Add(this.TypeReportTextBox);
            this.Name = "AppointmentByTypeReport";
            this.Text = "AppointmentByTypeReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TypeReportTextBox;
        private System.Windows.Forms.Label TypeReportLabel;
    }
}