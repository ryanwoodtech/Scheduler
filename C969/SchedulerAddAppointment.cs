using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace C969
{
    public partial class SchedulerAddAppointment : Form
    {
        public SchedulerAddAppointment()
        {
            InitializeComponent();
        }

        public SchedulerAddAppointment(DataGridViewRowCollection customerNameCollection)
        {
            InitializeComponent();
            AddAppointmentCustomerComboBox.Items.AddRange(ExtractCustomerNames(customerNameCollection)); 
        }

        private object[] ExtractCustomerNames(DataGridViewRowCollection customerNameCollection)
        {
            IList list = customerNameCollection;
            object[] customerNames = new object[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)list[i];
                // Extract customer name
                customerNames[i] = row.Cells[1].Value;
            }

            return customerNames;
        }
    }
}
