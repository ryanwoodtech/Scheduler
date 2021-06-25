using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace C969
{
    static class DataAccess
    {
        static public List<Appointment> GetAppointments()
        {
            // List of objects
            List<Appointment> appointments = new List<Appointment>();

            string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT appointmentId, customerId, userId, title, description, location, contact, type, url, start, end FROM appointment;", connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                { 
                    // Reads through each returned row as they are received from the database
                    while (reader.Read())
                    {
                        // reader with no brackets returns an object which is the object that will be instanciated by Appointment! Needs to be casted
                        Appointment appointment = new Appointment(reader.GetInt32("appointmentId"), reader.GetInt32("customerId"), reader.GetInt32("userId"), reader.GetString("title"), reader.GetString("description"), reader.GetString("location"), reader.GetString("contact"), reader.GetString("type"), reader.GetString("url"), reader.GetDateTime("start"), reader.GetDateTime("end"));
                        appointments.Add(appointment);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                return appointments;
            }
        }
    }
}
