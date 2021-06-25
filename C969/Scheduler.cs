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
        public Scheduler()
        {
            InitializeComponent();
            SchedulerAppointmentsDGV.DataSource = Appointments.appointments;
            SchedulerCustomersDGV.DataSource = Customers.customers;
        }

        private void AppointmentsDeleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cellData = SchedulerAppointmentsDGV.SelectedCells;

            if (cellData.Count == 0)
            {
                MessageBox.Show("You must select an appointment to delete.");
                return;
            }

            string message = "Are you sure you want to delete this appointment?";
            string caption = "Delete Appointment";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            // TODO: Send appointment id to be deleted
            // 1. Find which row in the DGV was selected
            //      cellData[0].RowIndex
            // 2. 
            int appointmentId = (int)SchedulerAppointmentsDGV.Rows[cellData[0].RowIndex].Cells[0].Value;
            Appointments.DeleteAppointment(appointmentId);

            // WARNING, HACKY CODE BELOW
            // This code executes independently of the database query e.g. if the query doesn't execute correctly, the DB won't match the DGV

            // Delete row from SchedulerAppointmentsDGV
            SchedulerAppointmentsDGV.Rows.RemoveAt(cellData[0].RowIndex);

            // Refresh DGV
            SchedulerAppointmentsDGV.DataSource = null;
            SchedulerAppointmentsDGV.DataSource = Appointments.appointments;

            MessageBox.Show("Appointment deleted!");
        }
    }
}
