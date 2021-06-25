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
            
            //BindingList<Appointment> appointments = DataAccess.GetAppointments();
            //SchedulerAppointmentsDGV.DataSource = appointments;

            //PopulateAppointments();
        }

        public void PopulateAppointments()
        {
            List<Appointment> appointments = DataAccess.GetAppointments();
            SchedulerAppointmentsDGV.DataSource = appointments;
            Console.WriteLine(appointments);
        }
    }
}
