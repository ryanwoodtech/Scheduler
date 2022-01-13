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
    public partial class AppointmentByTypeReport : Report
    {
        public AppointmentByTypeReport(List<string> uniqueAppointmentMonths)
        {
            InitializeComponent();

            AppendDateTime(TypeReportTextBox);

            // Iterate through each unique month that an appointment exists
            foreach (string uniqueMonth in uniqueAppointmentMonths)
            {
                List<string> allTypes = new List<string>();
                List<string> uniqueTypes = new List<string>();

                TypeReportTextBox.AppendText(uniqueMonth);
                TypeReportTextBox.AppendText(Environment.NewLine);

                // Iterate through every appointment
                for (int i = 0; i < Appointments.appointments.Rows.Count; i++)
                {
                    // Check if the appointment is during the current unique month
                    if ( Appointments.appointments.Rows[i].RowState != DataRowState.Deleted && Appointments.appointments.Rows[i].Field<DateTime>("start").ToString("MMMM") == uniqueMonth)
                    {
                        allTypes.Add(Appointments.appointments.Rows[i].Field<string>("type"));
                    }
                }

                // Grab each unique type
                uniqueTypes = allTypes.Distinct().ToList();

                // Count the number of times each unique type exists in all types

                int index = 0;
                uniqueTypes.ForEach(type => // A lambda expression is used here to simplify preforming an action on each type in unique types
                {
                    int numberOfAppointmentsByType = allTypes.FindAll(i => i == uniqueTypes[index]).Count; // A lambda expression is used here to simplify using type.Key as the value for counting
                    // Display data on the screen
                    TypeReportTextBox.AppendText("\tThere are " + numberOfAppointmentsByType + " appointment(s) of type " + uniqueTypes[index] + " during the month of " + uniqueMonth + ".");
                    TypeReportTextBox.AppendText(Environment.NewLine);
                    
                    index++;
                });

            }
        }
    }
}
