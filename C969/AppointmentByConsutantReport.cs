using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    public partial class AppointmentByConsutantReport : Form
    {
        DataTable[] allConsultantData;
        public AppointmentByConsutantReport(DataTable[] allConsultantData)
        {
            InitializeComponent();
            this.allConsultantData = allConsultantData;
            
            //List<string> uniqueConsultants = DataAccess.GetUniqueConsultants();

            // The size of allConsultantData should match uniqueConsultants

            // Iterate through each consultants DataTable
            for(int i = 0; i < allConsultantData.Length; i++)
            {
                // Add the consultants name to the multiline textbox
                // Rows[0]
                ConsultantAppointmentTextBox.AppendText("Appointments for " + allConsultantData[i].Rows[0].Field<string>("createdBy"));
                ConsultantAppointmentTextBox.AppendText(Environment.NewLine);
                // Iterate through each row (appointment) in that consultants DataTable
                for (int j = 0; j < allConsultantData[i].Rows.Count; j++)
                {
                    // Add appointment data to the multiline textbox
                    // Title
                    ConsultantAppointmentTextBox.AppendText("\tTitle: " + allConsultantData[i].Rows[j].Field<string>("title"));
                    ConsultantAppointmentTextBox.AppendText(Environment.NewLine);
                    
                    // Start - end date
                    ConsultantAppointmentTextBox.AppendText("\tStart: " + allConsultantData[i].Rows[j].Field<DateTime>("start"));
                    ConsultantAppointmentTextBox.AppendText(Environment.NewLine);
                    ConsultantAppointmentTextBox.AppendText("\tEnd: " + allConsultantData[i].Rows[j].Field<DateTime>("end"));
                    ConsultantAppointmentTextBox.AppendText(Environment.NewLine);
                    ConsultantAppointmentTextBox.AppendText(Environment.NewLine);
                }
            }
            
        }
    }
}
