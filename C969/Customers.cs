using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    class Customers
    {
        public Customers() { }

        static public DataTable customers = new DataTable();

        static public bool DeleteCustomer(int customerId)
        {
            // Delete appointment
            DataAccess.DeleteCustomer(customerId);

            // Refresh DGV
            return true;
        }
    }
}
