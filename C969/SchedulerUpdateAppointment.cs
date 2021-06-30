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

        DataGridViewRow rowToUpdate;
        public SchedulerUpdateAppointment(DataGridViewRow rowToUpdate, DataGridViewRowCollection customerRowCollection)
        {
            InitializeComponent();

            this.customerRowIList = customerRowCollection;
            this.rowToUpdate = rowToUpdate;

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

        private void UpdateAppointmentCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateAppointmentSaveButton_Click(object sender, EventArgs e)
        {
            SaveUpdatedAppointment();
        }

        public void SaveUpdatedAppointment()
        {
            // Create appointment object

            // Capture selected item
            // Search customerRowCollection for SelectedItem == customerRowCollection[1][i];
            // if true: capture customerRowCollection[0][i]  "customerId"
            // if finish iterating: default none value
            // if null: default none value
            // 

            int customerId = getCustomerId();
            int userId = getUserId();
            string title = UpdateAppointmentTitleInput.Text;
            string description = UpdateAppointmentDescriptionInput.Text;
            string location = UpdateAppointmentLocationInput.Text;
            string contact = UpdateAppointmentContactInput.Text;
            string type = UpdateAppointmentTypeInput.Text;
            string url = UpdateAppointmentURLInput.Text;
            DateTime start = getAppointmentDateTime("start").ToUniversalTime();
            DateTime end = getAppointmentDateTime("end").ToUniversalTime(); ;
            // DateTime createDate = DateTime.Now;
            // string createdBy = Scheduler.userName;
            // DateTime lastUpdate = DateTime.Now;
            // string lastUpdatedBy = Scheduler.userName;

            Appointment updatedAppointment = new Appointment(customerId, userId, title, description, location, contact, type, url, start, end);
            int updatedAppointmentId = (int)rowToUpdate.Cells[0].Value;

            DataAccess.SaveUpdatedAppointment(updatedAppointment, updatedAppointmentId);
            Appointments.appointments = DataAccess.GetAppointments();

            MessageBox.Show("Appointment Updated!");
            Close();
        }

        private DateTime getAppointmentDateTime(string startOrEnd)
        {
            if (startOrEnd == "start")
            {
                string startDate = UpdateAppointmentStartDatePicker.Value.ToString("yyyy/MM/dd");
                string startTime = UpdateAppointmentStartTimePicker.Value.ToString("HH:mm:ss");
                string appointmentDateTime = startDate + " " + startTime;

                return DateTime.Parse(appointmentDateTime);
            }
            else if (startOrEnd == "end")
            {
                string endDate = UpdateAppointmentEndDatePicker.Value.ToString("yyyy/MM/dd");
                string endTime = UpdateAppointmentEndTimePicker.Value.ToString("HH:mm:ss");
                return DateTime.Parse(endDate + " " + endTime);
            }

            throw new Exception();
        }

        private int getUserId()
        {
            return Scheduler.userId;
        }

        private int getCustomerId()
        {
            object test = (string)UpdateAppointmentCustomerComboBox.SelectedItem;

            for (int i = 0; i < customerNames.Length; i++)
            {
                if (customerNames[i] == test)
                {
                    int customerId = (int)customerIds[i];
                    return customerId;
                }
            }
            return -1;
        }
    }
}
