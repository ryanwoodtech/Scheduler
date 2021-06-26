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
        static public DataTable GetAppointments()
        {
            string query = "SELECT * FROM appointment;";
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable appointmentsDataTable = new DataTable();
                adapter.Fill(appointmentsDataTable);
                return appointmentsDataTable;
            }
        }

        static public DataTable GetCustomers()
        {
            string query = "SELECT * FROM customer;";
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable customersDataTable = new DataTable();
                adapter.Fill(customersDataTable);
                return customersDataTable;
            }
        }

        static public bool DeleteAppointment(int appointmentId)
        {
            string query = "DELETE FROM appointment WHERE appointmentId=" + appointmentId + ";";
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();

            }
            return true;
        }

        static public bool DeleteCustomer(int customerId)
        {
            string query = "DELETE FROM customer WHERE customerId=" + customerId + ";";
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();

            }
            return true;
        }
    }
}
