using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

                    // Without suspending the CurrencyManager, chedulerAppointmentsDGV.Rows[i].Visible = false; will error
 
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
            DataGridViewRow rowData = SchedulerAppointmentsDGV.SelectedRows[0];

            if (rowData.Cells.Count == 0)
            {
                MessageBox.Show("You must select an appointment to delete.");
                return;
            }

            int appointmentId = (int)rowData.Cells[0].Value;
            Appointments.DeleteAppointment(appointmentId);

            // WARNING, HACKY CODE BELOW
            // This code executes independently of the database query e.g. if the query doesn't execute correctly, the DB won't match the DGV

            // Delete row from SchedulerAppointmentsDGV
            SchedulerAppointmentsDGV.Rows.RemoveAt(rowData.Index);

            // Refresh DGV
            SchedulerAppointmentsDGV.DataSource = null;
            SchedulerAppointmentsDGV.DataSource = Appointments.appointments;

            MessageBox.Show("Appointment deleted!");
        }

        private void CustomersDeleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow rowData = SchedulerCustomersDGV.SelectedRows[0];

            if (rowData.Cells.Count == 0)
            {
                MessageBox.Show("You must select a customer to delete.");
                return;
            }

            int customerId = (int)rowData.Cells[0].Value;
            Customers.DeleteCustomer(customerId);

            // WARNING, HACKY CODE BELOW
            // This code executes independently of the database query e.g. if the query doesn't execute correctly, the DB won't match the DGV

            SchedulerCustomersDGV.Rows.RemoveAt(rowData.Index);

            // Refresh DGV
            SchedulerCustomersDGV.DataSource = null;
            SchedulerCustomersDGV.DataSource = Customers.customers;

            MessageBox.Show("Customer deleted!");
        }

        private void AppointmentsAddButton_Click(object sender, EventArgs e)
        {
            // Show add appointment form
            // Has all of the fields required
            // When clicking save, it will run an insert query to the DB
            // When clicking cancel, it will discard all changes
            
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
            DataGridViewRow rowToUpdate = SchedulerAppointmentsDGV.SelectedRows[0];

            if (rowToUpdate.Cells.Count == 0)
            {
                MessageBox.Show("You must select an appointment to update.");
                return;
            }

            SchedulerUpdateAppointment schedulerUpdateAppointmentForm= new SchedulerUpdateAppointment(rowToUpdate, SchedulerCustomersDGV.Rows);
            schedulerUpdateAppointmentForm.Show();
        }

        private void CustomersUpdateButton_Click(object sender, EventArgs e)
        {
            // Grab selected DataGridViewRow and send it to update
            DataGridViewRow rowToUpdate = SchedulerCustomersDGV.SelectedRows[0];

            if (rowToUpdate.Cells.Count == 0)
            {
                MessageBox.Show("You must select a customer to update.");
                return;
            }
            SchedulerUpdateCustomer schedulerUpdateCustomerForm = new SchedulerUpdateCustomer(rowToUpdate);
            schedulerUpdateCustomerForm.Show();
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
    }
}
