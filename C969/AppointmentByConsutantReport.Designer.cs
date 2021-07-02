
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
            this.AppointmentByConsultantDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentByConsultantDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // AppointmentByConsultantDGV
            // 
            this.AppointmentByConsultantDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentByConsultantDGV.Location = new System.Drawing.Point(92, 94);
            this.AppointmentByConsultantDGV.Name = "AppointmentByConsultantDGV";
            this.AppointmentByConsultantDGV.Size = new System.Drawing.Size(604, 294);
            this.AppointmentByConsultantDGV.TabIndex = 0;
            // 
            // AppointmentByConsutantReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AppointmentByConsultantDGV);
            this.Name = "AppointmentByConsutantReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentByConsutantReport";
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentByConsultantDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AppointmentByConsultantDGV;
    }
}