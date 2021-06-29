using System;
using System.Collections;
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
    public partial class SchedulerUpdateAppointment : Form
    {
        IList customerRowIList;
        object[] customerNames;
        object[] customerIds;
        public SchedulerUpdateAppointment(DataGridViewRow rowToUpdate, DataGridViewRowCollection customerRowCollection)
        {
            InitializeComponent();

            this.customerRowIList = customerRowCollection;

            this.customerIds = new object[customerRowIList.Count];
            customerIds = ExtractCustomerInfo(0);

            this.customerNames = new object[customerRowIList.Count];
            customerNames = ExtractCustomerInfo(1);
            UpdateAppointmentCustomerComboBox.Items.AddRange(customerNames);

            for(int i = 0; i < customerRowIList.Count; i++)
            {
                if((int)rowToUpdate.Cells[1].Value == (int)customerRowCollection[i].Cells[0].Value)
                {
                    UpdateAppointmentCustomerComboBox.Text = customerRowCollection[i].Cells[1].Value.ToString();
                }
            }

            /*
            if(UpdateAppointmentCustomerComboBox.Text == null)
            {
                UpdateAppointmentCustomerComboBox.Text = "";
            }
            */
            //UpdateAppointmentCustomerComboBox.Text = rowData.Cells[1].Value.ToString();
            UpdateAppointmentTitleInput.Text = rowToUpdate.Cells[3].Value.ToString();
            UpdateAppointmentDescriptionInput.Text = rowToUpdate.Cells[4].Value.ToString();
            UpdateAppointmentLocationInput.Text = rowToUpdate.Cells[5].Value.ToString();
            UpdateAppointmentContactInput.Text = rowToUpdate.Cells[6].Value.ToString();
            UpdateAppointmentTypeInput.Text = rowToUpdate.Cells[7].Value.ToString();
            UpdateAppointmentURLInput.Text = rowToUpdate.Cells[8].Value.ToString();

            UpdateAppointmentStartDatePicker.Value = DateTime.Parse(rowToUpdate.Cells[9].Value.ToString());
            UpdateAppointmentStartTimePicker.Value = DateTime.Parse(rowToUpdate.Cells[9].Value.ToString());
            UpdateAppointmentEndDatePicker.Value = DateTime.Parse(rowToUpdate.Cells[10].Value.ToString());
            UpdateAppointmentEndTimePicker.Value = DateTime.Parse(rowToUpdate.Cells[10].Value.ToString());
        }
        private object[] ExtractCustomerInfo(int index)
        {
            object[] customerInfo = new object[customerRowIList.Count];

            for (int i = 0; i < customerRowIList.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)customerRowIList[i];
                // Extract customer name
                customerInfo[i] = row.Cells[index].Value;
            }

            return customerInfo;
        }
    }
}
