using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Appointments.appointments = DataAccess.GetAppointments();
            Customers.customers = DataAccess.GetCustomers();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SchedulerLogin());
        }
    }
}
