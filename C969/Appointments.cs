using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    class Appointments
    {
        public Appointments() { }

        static public DataTable appointments = new DataTable();

        static public bool DeleteAppointment(int appointmentId)
        {
            DataAccess.DeleteAppointment(appointmentId);

            return true;
        }
    }
}
