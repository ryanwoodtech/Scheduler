using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace C969
{
    class DataAccess
    {
        public DataTable GetAppointments()
        {
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT appointmentId, customerId, userId, title, description, location, contact, type, url, start, end FROM appointment;", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable appointmentsDataTable = new DataTable();
                adapter.Fill(appointmentsDataTable);
                return appointmentsDataTable;
            }
        }
    }
}
