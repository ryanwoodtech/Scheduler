using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class AppointmentByCustomerReport : Report
    {
        public override void AppendDateTime(TextBox textBox)
        {
            textBox.AppendText("Appointment by Customer Report");
            textBox.AppendText(Environment.NewLine);

            base.AppendDateTime(textBox);
        }
        public AppointmentByCustomerReport(List<List<string[]>> allCustomerAppointmentData)
        {
            InitializeComponent();

            AppendDateTime(CustomerAppointmentTextBox);

            // Iterate through each customer
            for (int i = 0; i < allCustomerAppointmentData.Count; i++)
            {
                if (allCustomerAppointmentData[i].Count != 0)
                {
                    CustomerAppointmentTextBox.AppendText("Appointments with " + DataAccess.GetCustomerName(int.Parse(allCustomerAppointmentData[i][0][0])));
                    CustomerAppointmentTextBox.AppendText(Environment.NewLine);

                    // Iterate thorugh each customer's appointments
                    for (int j = 0; j < allCustomerAppointmentData[i].Count; j++)
                    {
                        // Add info about appointment to CustomerAppointmentTextBox
                        CustomerAppointmentTextBox.AppendText("\tTitle: " + allCustomerAppointmentData[i][j][1]);
                        CustomerAppointmentTextBox.AppendText(Environment.NewLine);

                        CustomerAppointmentTextBox.AppendText("\tStart: " + allCustomerAppointmentData[i][j][2]);
                        CustomerAppointmentTextBox.AppendText(Environment.NewLine);

                        CustomerAppointmentTextBox.AppendText("\tEnd: " + allCustomerAppointmentData[i][j][3]);
                        CustomerAppointmentTextBox.AppendText(Environment.NewLine);
                        CustomerAppointmentTextBox.AppendText(Environment.NewLine);
                    }
                }
            }
        }
    }
}
