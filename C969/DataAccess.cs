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
            object[] commonTableData = GetCommonTableData();


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

        static public void DeleteCustomer(int customerId)
        {
            string query = "DELETE FROM customer WHERE customerId=" + customerId + ";";
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }

        static public void SaveNewAppointment(Appointment newAppointment)
        {
            string query = sqlFormat(newAppointment);
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static private string sqlFormat(Appointment newAppointment)
        {
            object[] commonTableData = GetCommonTableData();
            string query = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (" + newAppointment.customerId + ", " + newAppointment.userId + ", \'" + newAppointment.title + "\', \'" + newAppointment.description + "\', \'" + newAppointment.location + "\', \'" + newAppointment.contact + "\', \'" + newAppointment.type + "\', \'" + newAppointment.url + "\', \'" + newAppointment.start.ToString("yyyy-MM-dd HH:mm:ss") + "\', \'" + newAppointment.end.ToString("yyyy-MM-dd HH:mm:ss") + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";

            return query;
        }


        static public int SaveCountry(string country)
        {
            object[] commonTableData = GetCommonTableData();
            string query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (\'" + country + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";
            string selectQuery = "SELECT * FROM country WHERE country = \'" + country + "\';";
            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlCommand select = new MySqlCommand(selectQuery, connection);
                connection.Open();
                command.ExecuteNonQuery();
                MySqlDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
            }
            return -1;
        }

        static public int SaveCity(string city, int countryId)
        {
            object[] commonTableData = GetCommonTableData();
            throw new NotImplementedException();

        }

        static public int SaveAddress(string address, string address2, int cityId, string postalCode, string phone)
        {
            object[] commonTableData = GetCommonTableData();
            throw new NotImplementedException();
        }

        static private object[] GetCommonTableData()
        {
            object[] commonTableData = new object[4] { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Scheduler.userName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Scheduler.userName };
            return commonTableData;
        }
    }
}
