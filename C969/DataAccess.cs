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
        internal DataTable GetAppointments()
        {
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM appointment;", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable appointmentsDataTable = new DataTable();
                adapter.Fill(appointmentsDataTable);
                return appointmentsDataTable;
            }
        }

        internal DataTable GetCustomers()
        {
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM customer;", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable customersDataTable = new DataTable();
                adapter.Fill(customersDataTable);
                return customersDataTable;
            }
        }
    }
}
