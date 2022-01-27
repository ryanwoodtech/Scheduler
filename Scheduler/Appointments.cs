using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class Appointments
    {
        public Appointments() { }

        static public DataTable appointments = new DataTable();

        static public void AddAppointment(Appointment newAppointment)
        {
            DataAccess.SaveNewAppointment(newAppointment);
            appointments = DataAccess.GetAppointments();
        }
        static public void UpdateAppointment(Appointment updatedAppointment, int updatedAppointmentId)
        {
            DataAccess.SaveUpdatedAppointment(updatedAppointment, updatedAppointmentId);
            appointments = DataAccess.GetAppointments();
        }
        static public bool DeleteAppointment(int appointmentId)
        {
            DataAccess.DeleteAppointment(appointmentId);

            return true;
        }
    }
}
