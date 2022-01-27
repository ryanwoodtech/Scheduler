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

namespace Scheduler
{
    public partial class SchedulerUpdateAppointment : Form
    {
        IList customerRowIList;
        IList appointmentRowCollection;
        object[] customerNames;
        object[] customerIds;

        DataGridViewRow rowToUpdate;
        public SchedulerUpdateAppointment(DataGridViewRow rowToUpdate, DataGridViewRowCollection customerRowCollection, DataGridViewRowCollection appointmentRowCollection)
        {
            InitializeComponent();

            this.customerRowIList = customerRowCollection;
            this.rowToUpdate = rowToUpdate;
            this.appointmentRowCollection = appointmentRowCollection;


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
            bool isValid = CheckAppointmentConstraints();

            if (isValid)
            {
                SaveUpdatedAppointment();
            }
        }

        private bool CheckAppointmentConstraints()
        {
            bool isAppointmentDuringBusinessHours = CheckAppointmentDuringBusinessHours();
            bool isAppointmentConflictingWithAnotherAppointment = CheckAppointmentConflictingWithAnotherAppointment();
            bool isCustomer = CheckCustomerExists();

            if (!isAppointmentDuringBusinessHours && !isAppointmentConflictingWithAnotherAppointment && isCustomer)
            {
                return true;
            }

            if (isAppointmentDuringBusinessHours)
            {
                MessageBox.Show("Appointment cannot be during business hours (8AM - 5PM).");
            }
            if (isAppointmentConflictingWithAnotherAppointment)
            {
                MessageBox.Show("Appointment cannot be during another appointment.");
            }
            if (!isCustomer)
            {
                MessageBox.Show("Appointment needs to be with a customer.");
            }

            return false;
        }

        private bool CheckCustomerExists()
        {
            int customerId = getCustomerId();

            if (customerId == -1)
            {
                return false;
            }
            return true;
        }

        private bool CheckAppointmentConflictingWithAnotherAppointment()
        {
            DateTime[] existingAppointmentStartDates = new DateTime[appointmentRowCollection.Count];
            DateTime[] existingAppointmentEndDates = new DateTime[appointmentRowCollection.Count];

            DateTime newAppointmentStartDate = getAppointmentDateTime("start");
            DateTime newAppointmentEndDate = getAppointmentDateTime("end");

            // Get appointments for the signed in user
            for (int i = 0; i < appointmentRowCollection.Count; i++)
            {
                DataGridViewRow currentRow = (DataGridViewRow)appointmentRowCollection[i];

                if ((string)currentRow.Cells["createdBy"].Value == Scheduler.userName)
                {
                    existingAppointmentStartDates[i] = (DateTime)currentRow.Cells["start"].Value;
                    existingAppointmentEndDates[i] = (DateTime)currentRow.Cells["end"].Value;
                }
            }
            // If the start of the appointment we are trying to create is GREATER THAN the current appointment we are comparing against && LESS THAN the end of the appointment we are comparing against = bad

            // Check if the new appointment overlaps an existing appointment
            // Loop through existing appointments
            for (int i = 0; i < existingAppointmentStartDates.Length; i++)
            {
                // Check if the new appointment starts in the middle of another appointment
                if (newAppointmentStartDate > existingAppointmentStartDates[i] && newAppointmentStartDate < existingAppointmentEndDates[i])
                {
                    return true;
                }

                // Will get here if appointment does NOT start in the middle of another appointment
                if (newAppointmentStartDate < existingAppointmentStartDates[i] && newAppointmentEndDate > existingAppointmentStartDates[i])
                {
                    return true;
                }

            }

            // Code will reach here if appointments do not overlap
            return false; ;
        }

        private bool CheckAppointmentDuringBusinessHours()
        {
            TimeSpan businessStart = new TimeSpan(8, 0, 0);
            TimeSpan businessEnd = new TimeSpan(17, 0, 0);

            TimeSpan appointmentStart = getAppointmentDateTime("start").TimeOfDay;
            TimeSpan appointmentEnd = getAppointmentDateTime("end").TimeOfDay;

            if (appointmentStart < businessStart || appointmentStart > businessEnd)
            {
                return true;
            }
            else if (appointmentEnd < businessStart || appointmentEnd > businessEnd)
            {
                return true;
            }

            return false;
        }


        public void SaveUpdatedAppointment()
        {
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

            Appointment updatedAppointment = new Appointment(customerId, userId, title, description, location, contact, type, url, start, end);
            int updatedAppointmentId = (int)rowToUpdate.Cells[0].Value;

            Appointments.UpdateAppointment(updatedAppointment, updatedAppointmentId);

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
