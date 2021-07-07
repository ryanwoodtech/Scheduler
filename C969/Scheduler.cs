using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969
{
    public partial class Scheduler : Form
    {
        static public int userId;
        static public string userName;

        public Scheduler(int userId, string userName)
        {
            InitializeComponent();
            SchedulerAppointmentsDGV.DataSource = Appointments.appointments;
            FilterAppointments();
            SchedulerCustomersDGV.DataSource = Customers.customers;
            Scheduler.userId = userId;
            Scheduler.userName = userName;
            NotifyUserOfCloseAppointments(userId);
        }

        private void NotifyUserOfCloseAppointments(int userId)
        {
            for(int i = 0; i < Appointments.appointments.Rows.Count; i++)
            {
                DateTime appointmentDate = Appointments.appointments.Rows[i].Field<DateTime>("start");
                int appointmentUserId = Appointments.appointments.Rows[i].Field<int>("userId");

                if ( userId == appointmentUserId && DateTime.Now < appointmentDate && DateTime.Now > appointmentDate.AddMinutes(-15))
                {
                    string name = DataAccess.GetCustomerName(Appointments.appointments.Rows[i].Field<int>("customerId"));
                    MessageBox.Show("You have a meeting with " + name + " at " + Appointments.appointments.Rows[i].Field<DateTime>("start").TimeOfDay + " today.");
                }
            }
        }

        private void FilterAppointments()
        {
            if (AppointmentsAllRadioButton.Checked)
            {
                System.Collections.IList rows = SchedulerAppointmentsDGV.Rows;

                for (int i = 0; i < rows.Count; i++)
                {
                    SchedulerAppointmentsDGV.Rows[i].Visible = true;
                }

            }
            else if (AppointmentsMonthRadioButton.Checked)
            {
                System.Collections.IList rows = SchedulerAppointmentsDGV.Rows;
                for (int i = 0; i < rows.Count; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)rows[i];
                    DateTime appointmentDate = (DateTime)row.Cells["start"].Value;

                    if (appointmentDate.Month == DateTime.Now.Month && appointmentDate.Year == DateTime.Now.Year)
                    {
                        // Show appointment
                        SchedulerAppointmentsDGV.Rows[i].Visible = true;
                        continue;
                    }

                    // Without suspending the CurrencyManager, SchedulerAppointmentsDGV.Rows[i].Visible = false; will error
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[SchedulerAppointmentsDGV.DataSource];
                    currencyManager.SuspendBinding();
                    SchedulerAppointmentsDGV.Rows[i].Visible = false;
                    currencyManager.ResumeBinding();

                    SchedulerAppointmentsDGV.Rows[i].Visible = false;
                }

            }
            else if (AppointmentsWeekRadioButton.Checked)
            {
                System.Collections.IList rows = SchedulerAppointmentsDGV.Rows;
                for (int i = 0; i < rows.Count; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)rows[i];
                    DateTime appointmentDate = (DateTime)row.Cells["start"].Value;

                    // DayOfWeek.Sunday = 0, DayOfWeek.Saturday = 6
                    DateTime todaysDay = DateTime.Now;
                    int daysUntilPreviousSunday = -1 * (int)todaysDay.DayOfWeek;
                    int daysUnitlSaturday = 6 - (int)todaysDay.DayOfWeek;

                    DateTime previousSundaysDate = todaysDay.AddDays(daysUntilPreviousSunday);
                    DateTime thisSaturdaysDate = todaysDay.AddDays(daysUnitlSaturday);

                    if (appointmentDate > previousSundaysDate && appointmentDate < thisSaturdaysDate)
                    {
                        SchedulerAppointmentsDGV.Rows[i].Visible = true;
                        continue;
                    }

                    // Without suspending the CurrencyManager, SchedulerAppointmentsDGV.Rows[i].Visible = false; will error
 
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[SchedulerAppointmentsDGV.DataSource];
                    currencyManager.SuspendBinding();
                    SchedulerAppointmentsDGV.Rows[i].Visible = false;
                    currencyManager.ResumeBinding();

                    SchedulerAppointmentsDGV.Rows[i].Visible = false;
                }
            }
        }

        private void AppointmentsDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow rowData = SchedulerAppointmentsDGV.SelectedRows[0];

            if (rowData.Cells.Count == 0)
            {
                MessageBox.Show("You must select an appointment to delete.");
                return;
            }

            int appointmentId = (int)rowData.Cells[0].Value;
            Appointments.DeleteAppointment(appointmentId);

            // This code executes independently of the database query e.g. if the query doesn't execute correctly, the DB won't match the DGV
            // Delete row from SchedulerAppointmentsDGV
            SchedulerAppointmentsDGV.Rows.RemoveAt(rowData.Index);

            // Refresh DGV
            SchedulerAppointmentsDGV.DataSource = null;
            SchedulerAppointmentsDGV.DataSource = Appointments.appointments;

            MessageBox.Show("Appointment deleted!");
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }

        private void CustomersDeleteButton_Click(object sender, EventArgs e)
        {
            try { 
                DataGridViewRow rowData = SchedulerCustomersDGV.SelectedRows[0];

                if (rowData.Cells.Count == 0)
                {
                    MessageBox.Show("You must select a customer to delete.");
                    return;
                }

                int customerId = (int)rowData.Cells[0].Value;
                if (!Customers.DeleteCustomer(customerId))
                {
                    MessageBox.Show("Query failed");
                    return;
                }

                // This code executes independently of the database query e.g. if the query doesn't execute correctly, the DB won't match the DGV
                SchedulerCustomersDGV.Rows.RemoveAt(rowData.Index);

                // Refresh DGV
                SchedulerCustomersDGV.DataSource = null;
                SchedulerCustomersDGV.DataSource = Customers.customers;

                MessageBox.Show("Customer deleted!");
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }

        private void AppointmentsAddButton_Click(object sender, EventArgs e)
        { 
            SchedulerAddAppointment schedulerAddAppointmentForm = new SchedulerAddAppointment(SchedulerCustomersDGV.Rows, SchedulerAppointmentsDGV.Rows);
            schedulerAddAppointmentForm.Show();   
        }

        private void CustomersAddButton_Click(object sender, EventArgs e)
        {
            SchedulerAddCustomer schedulerAddCustomerForm = new SchedulerAddCustomer();
            schedulerAddCustomerForm.Show();
        }

        private void Scheduler_Activated(object sender, EventArgs e)
        {
            // Refresh DataGridViews
            SchedulerAppointmentsDGV.DataSource = null;
            SchedulerAppointmentsDGV.DataSource = Appointments.appointments;

            SchedulerCustomersDGV.DataSource = null;
            SchedulerCustomersDGV.DataSource = Customers.customers;
        }

        private void AppointmentsUpdateButton_Click(object sender, EventArgs e)
        {
            // Grab selected DataGridViewRow and send it to update
            try 
            { 
                DataGridViewRow rowToUpdate = SchedulerAppointmentsDGV.SelectedRows[0];

                if (rowToUpdate.Cells.Count == 0)
                {
                    MessageBox.Show("You must select an appointment to update.");
                    return;
                }

                SchedulerUpdateAppointment schedulerUpdateAppointmentForm= new SchedulerUpdateAppointment(rowToUpdate, SchedulerCustomersDGV.Rows, SchedulerAppointmentsDGV.Rows);
                schedulerUpdateAppointmentForm.Show();
                }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }

        private void CustomersUpdateButton_Click(object sender, EventArgs e)
        {
            // Grab selected DataGridViewRow and send it to update
            try { 
                DataGridViewRow rowToUpdate = SchedulerCustomersDGV.SelectedRows[0];

                if (rowToUpdate.Cells.Count == 0)
                {
                    MessageBox.Show("You must select a customer to update.");
                    return;
                }
                SchedulerUpdateCustomer schedulerUpdateCustomerForm = new SchedulerUpdateCustomer(rowToUpdate);
                schedulerUpdateCustomerForm.Show();
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }

        private void AppointmentsMonthRadioButton_Click(object sender, EventArgs e)
        {
            FilterAppointments();
        }

        private void AppointmentsWeekRadioButton_Click(object sender, EventArgs e)
        {
            FilterAppointments();
        }

        private void AppointmentsAllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterAppointments();
        }

        private void SchedulerGenerateReportButton_Click(object sender, EventArgs e)
        {
            string reportType = (string)SchedulerGenerateReportComboBox.SelectedItem;

            if (reportType == "Appointments by type")
            {
                GenerateReportAppointmentsByType(UniqueAppointmentMonths());
            }
            else if (reportType == "Appointments by consultant")
            {
                GenerateReportAppointmentsByConsultant(AppointmentsByConsultant());
            }
            else if (reportType == "Appointments by customer")
            {
                GenerateReportAppointmentsByCustomer(AppointmentsByCustomer());
            }
            else
            {
                MessageBox.Show("Please choose a report type.");
            }
        }

        private List<string> UniqueAppointmentMonths()
        {
            List<string> differentMonths = new List<string>();

            for (int i = 0; i < SchedulerAppointmentsDGV.RowCount; i++)
            {
                DateTime monthDateTime = (DateTime)SchedulerAppointmentsDGV.Rows[i].Cells["start"].Value;
                string month = monthDateTime.ToString("MMMM"); // returns "July" or similar 
                differentMonths.Add(month);
            }

            List<string> uniqueMonths = differentMonths.Distinct().ToList(); // A lambda expression is used here to grab each unique month
            //List<string> uniqueMonths = differentMonths.Distinct().ToList(); // A lambda expression is used here to grab each unique month

            return uniqueMonths;
        }

        private DataTable[] AppointmentsByConsultant()
        {
            List<string> uniqueConsultants = new List<string>();
            List<string[]> allConsultantData = new List<string[]>();

            uniqueConsultants = DataAccess.GetUniqueConsultants();

            DataTable[] resultFromDB = new DataTable[uniqueConsultants.Count()];

            for (int i = 0; i < uniqueConsultants.Count; i++)
            {
                DataTable consultantAppointmentsDataTable = DataAccess.GetAppointmentsByConsultant(uniqueConsultants[i]);
                resultFromDB[i] = consultantAppointmentsDataTable;
            }

            return resultFromDB;
        }

        private List<List<string[]>> AppointmentsByCustomer()
        {
            // allAppointments[0] = first customers appointments
            // allAppointments[1] = second customers appointments ...
            List<List<string[]>> allAppoinments = DataAccess.GetAppointmentsByCustomer();
            
            return allAppoinments;
        }



        private void GenerateReportAppointmentsByType(List<string> uniqueAppointmentMonths)
        {
            AppointmentByTypeReport appointmentByTypeReportForm = new AppointmentByTypeReport(uniqueAppointmentMonths);
            appointmentByTypeReportForm.Show();
        }

        private void GenerateReportAppointmentsByConsultant(DataTable[] allConsultantData)
        {
            AppointmentByConsutantReport appointmentByConsutantReportForm = new AppointmentByConsutantReport(allConsultantData);
            appointmentByConsutantReportForm.Show();
        }

        private void GenerateReportAppointmentsByCustomer(List<List<string[]>> allCustomerAppointmentData)
        {
            // Each item in allCustomerAppointmentData is a customer that contains a List<string[]> of all of the appointments they have
            AppointmentByCustomerReport appointmentByCustomerReportForm = new AppointmentByCustomerReport(allCustomerAppointmentData);
            appointmentByCustomerReportForm.Show();

        }

    }
}
