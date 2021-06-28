
namespace C969
{
    partial class SchedulerAddCustomer
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
            this.AddCustomerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddCustomerLabel
            // 
            this.AddCustomerLabel.AutoSize = true;
            this.AddCustomerLabel.Font = new System.Drawing.Font("Adobe Devanagari", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCustomerLabel.Location = new System.Drawing.Point(114, 33);
            this.AddCustomerLabel.Name = "AddCustomerLabel";
            this.AddCustomerLabel.Size = new System.Drawing.Size(196, 43);
            this.AddCustomerLabel.TabIndex = 1;
            this.AddCustomerLabel.Text = "Add Customer";
            // 
            // SchedulerAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 450);
            this.Controls.Add(this.AddCustomerLabel);
            this.Name = "SchedulerAddCustomer";
            this.Text = "SchedulerAddCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddCustomerLabel;
    }
}