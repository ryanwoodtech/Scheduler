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
using System.Runtime.InteropServices;


namespace Scheduler
{
    public partial class SchedulerAddAppointment : Form
    {
        IList customerRowIList;
        IList appointmentRowCollection;
        int[] customerIds;
        string[] customerNames;

        public SchedulerAddAppointment()
        {
            InitializeComponent();
        }

        public SchedulerAddAppointment(DataGridViewRowCollection customerRowCollection, DataGridViewRowCollection appointmentRowCollection)
        {
            InitializeComponent();
            this.customerRowIList = customerRowCollection;
            this.appointmentRowCollection = appointmentRowCollection;

            // Returns 
            List<string[]> customerComboboxInfo = ExtractCustomerComboboxInfo();

            string[][] customersData = customerComboboxInfo.ToArray();
            customerIds = new int[customersData.Length];
            customerNames = new string[customersData.Length];

            for (int i = 0; i < customersData.Length; i++)
            {
                string[] customer = customersData[i];
                customerIds[i] = int.Parse(customer[0]);
                customerNames[i] = customer[1];
            }

            AddAppointmentCustomerComboBox.Items.AddRange(customerNames);
        }

        private void AddAppointmentCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddAppointmentSaveButton_Click(object sender, EventArgs e)
        {
            int customerId = getCustomerId();
            int userId = getUserId();
            string title = AddAppointmentTitleInput.Text;
            string description = AddAppointmentDescriptionInput.Text;
            string location = AddAppointmentLocationInput.Text;
            string contact = AddAppointmentContactInput.Text;
            string type = AddAppointmentTypeInput.Text;
            string url = AddAppointmentURLInput.Text;
            DateTime start = getAppointmentDateTime("start").ToUniversalTime();
            DateTime end = getAppointmentDateTime("end").ToUniversalTime();

            Appointment newAppointment = new Appointment( customerId, userId, title, description, location, contact, type, url, start, end);

            if (CheckAppointmentConstraints())
            {
                SaveNewAppointment(newAppointment);
            }

            // Uncomment these two lines to test that the new appointment was saved successfully
            Appointment appointmentFromDatabase = GetAppointment(customerId, userId, title);
            TestSuccessfulAppointment(newAppointment, appointmentFromDatabase);
        }

        private Appointment GetAppointment(int customerId, int userId, string title)
        {
            int appointmentId = DataAccess.GetAppointmentId(customerId, userId, title);
            return DataAccess.GetAppointment(appointmentId);
        }

        private void TestSuccessfulAppointment(Appointment newAppointment, Appointment appointmentFromDatabase)
        {
            Console.WriteLine("-----BEGIN TEST-----");
            Console.WriteLine("User entered appointment");
            Console.WriteLine();
            Console.WriteLine("UserId: " + newAppointment.UserId);
            Console.WriteLine("Title: " + newAppointment.Title);
            Console.WriteLine("Description: " + newAppointment.Description);
            Console.WriteLine("Location: " + newAppointment.Location);
            Console.WriteLine("Contact: " + newAppointment.Contact);
            Console.WriteLine("Type: " + newAppointment.Type);
            Console.WriteLine("URL: " + newAppointment.Url);
            Console.WriteLine("Start: " + newAppointment.Start.ToLocalTime());
            Console.WriteLine("End: " + newAppointment.End.ToLocalTime());
            Console.WriteLine();

            Console.WriteLine("Appointment from database");
            Console.WriteLine();
            Console.WriteLine("UserId: " + appointmentFromDatabase.UserId);
            Console.WriteLine("Title: " + appointmentFromDatabase.Title);
            Console.WriteLine("Description: " + appointmentFromDatabase.Description);
            Console.WriteLine("Location: " + appointmentFromDatabase.Location);
            Console.WriteLine("Contact: " + appointmentFromDatabase.Contact);
            Console.WriteLine("Type: " + appointmentFromDatabase.Type);
            Console.WriteLine("URL: " + appointmentFromDatabase.Url);
            Console.WriteLine("Start: " + appointmentFromDatabase.Start.ToLocalTime());
            Console.WriteLine("End: " + appointmentFromDatabase.End.ToLocalTime());
            Console.WriteLine();
            Console.WriteLine("RESULTS");

            if (
                newAppointment.UserId == appointmentFromDatabase.UserId &&
                newAppointment.Title == appointmentFromDatabase.Title &&
                newAppointment.Description == appointmentFromDatabase.Description &&
                newAppointment.Location == appointmentFromDatabase.Location &&
                newAppointment.Contact == appointmentFromDatabase.Contact &&
                newAppointment.Type == appointmentFromDatabase.Type &&
                newAppointment.Url == appointmentFromDatabase.Url &&
                newAppointment.Start == appointmentFromDatabase.Start &&
                newAppointment.End == appointmentFromDatabase.End 
                )
            {
                Console.WriteLine("Every value is saved correctly in the database!");
                Console.WriteLine("Check to ensure each field has an appropriate value.");
            } else
            {
                Console.WriteLine("Test failed.");
            }
            Console.WriteLine("-----END TEST-----");
        }

        private bool CheckAppointmentConstraints()
        {
            bool isAppointmentDuringBusinessHours = CheckAppointmentDuringBusinessHours();
            bool isAppointmentConflictingWithAnotherAppointment = CheckAppointmentConflictingWithAnotherAppointment();
            bool isCustomer = CheckCustomerExists();


            if(!isAppointmentDuringBusinessHours && !isAppointmentConflictingWithAnotherAppointment && isCustomer)
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
            for(int i = 0; i < existingAppointmentStartDates.Length; i++)
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

        private List<string[]> ExtractCustomerComboboxInfo()
        {
            return DataAccess.GetCustomersInfo();

        }


        private void SaveNewAppointment(Appointment newAppointment)
        {
            Appointments.AddAppointment(newAppointment);

            MessageBox.Show("Appointment Added!");
            Close();
        }

        private DateTime getAppointmentDateTime(string startOrEnd)
        {
            if (startOrEnd == "start")
            {
                string startDate = AddAppointmentStartDatePicker.Value.ToString("yyyy/MM/dd");
                string startTime = AddAppointmentStartTimePicker.Value.ToString("HH:mm:ss");
                string appointmentDateTime = startDate + " " + startTime;

                return DateTime.Parse(appointmentDateTime);
            }
            else if (startOrEnd == "end")
            {
                string endDate = AddAppointmentEndDatePicker.Value.ToString("yyyy/MM/dd");
                string endTime = AddAppointmentEndTimePicker.Value.ToString("HH:mm:ss");
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
            string customerName = (string)AddAppointmentCustomerComboBox.SelectedItem;

            for (int i = 0; i < customerNames.Length; i++)
            {
                if (customerNames[i] == customerName)
                {
                    int customerId = customerIds[i];
                    return customerId;
                }
            }
            return -1;
        }
    }
}
