using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace Scheduler
{
    static class DataAccess
    {
        static readonly string ConnectionString = "server=us-cdbr-east-05.cleardb.net;userid=b6df9e9570183d;database=heroku_f72e74ad46fe9f2;password=fdf3b631;";

        static public DataTable GetAppointments()
        {
            string query = "SELECT * FROM appointment;";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable appointmentsDataTable = new DataTable();
                adapter.Fill(appointmentsDataTable);
                
                // Convert UTC to local
                foreach (DataRow row in appointmentsDataTable.Rows)
                {
                    DateTime start = (DateTime)row["start"];
                    row["start"] = start.ToLocalTime();
                    DateTime end = (DateTime)row["end"];
                    row["end"] = end.ToLocalTime();
                    DateTime createDate = (DateTime)row["createDate"];
                    row["createDate"] = createDate.ToLocalTime();
                    DateTime lastUpdate = (DateTime)row["lastUpdate"];
                    row["lastUpdate"] = lastUpdate.ToLocalTime();
                }

                return appointmentsDataTable;
            }
        }
        internal static Appointment GetAppointment(int appointmentId)
        {
            string query = "SELECT * FROM appointment WHERE appointmentId=" + appointmentId + ";";
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Appointment(reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), (DateTime)reader.GetValue(9), (DateTime)reader.GetValue(10));
                }
            }

            throw new Exception();
           
        }

        static public int GetAppointmentId(int customerId, int userId, string title)
        {
            string query = "SELECT appointmentId FROM appointment WHERE customerId=\'" + customerId + "\' AND userId=\'" + userId + "\' AND title=\'" + title + "\';";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
            }

            throw new Exception();
        }
        static public string GetCustomerName(int customerId)
        {
            string query = "SELECT customerName FROM customer WHERE customerId=" + customerId + ";";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0); // country
                }
            }
            throw new Exception();
        }

        static public DataTable GetCustomers()
        {
            string query = "SELECT * FROM customer;";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable customersDataTable = new DataTable();
                adapter.Fill(customersDataTable);

                // Convert UTC to local
                foreach (DataRow row in customersDataTable.Rows)
                {
                    DateTime createDate = (DateTime)row["createDate"];
                    row["createDate"] = createDate.ToLocalTime();
                    DateTime lastUpdate = (DateTime)row["lastUpdate"];
                    row["lastUpdate"] = lastUpdate.ToLocalTime();
                }

                return customersDataTable;
            }
        }

        internal static void SaveNewUser(string userName, string hashedPassword)
        {

            // INSERT INTO user(userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES(ryan, e0e3a2b6471d044a53a7757994b51dd33c6b3ec90e1aca21cebc8e2ae79d6d9b, '1', '2022-01-09 17:05:33', '', '2022-01-09 17:05:33', '');
            // "INSERT INTO user(userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('ryan', 'e0e3a2b6471d044a53a7757994b51dd33c6b3ec90e1aca21cebc8e2ae79d6d9b', '1', '2022-01-09 17:09:42', 'ryan', '2022-01-09 17:09:42', 'ryan');"

            object[] commonTableData = GetCommonTableData();
            string query = "INSERT INTO user(userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES(\'" + userName + "\', \'" + hashedPassword + "\', \'" + 1 + "\', \'" + commonTableData[0] + "\', \'" + userName + "\', \'" + commonTableData[2] + "\', \'" + userName + "\');";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal static ArrayList GetColumn(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                ArrayList userNames = new ArrayList();

                if (reader.HasRows)
                {
                    // Reads one row at a time
                    while (reader.Read())
                    {
                        userNames.Add(reader[0]);
                    }

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();
                return userNames;
            }
        }

        static public List<string[]> GetCustomersInfo()
        {
            string query = "SELECT * FROM customer;";
            List<string[]> customerData = new List<string[]>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] customer = new string[2];
                    customer[0] = reader.GetInt32(0).ToString(); // countryId
                    customer[1] = reader.GetString(1); // country
                    customerData.Add(customer);
                }

                return customerData;
            }
            throw new Exception();
        }

        static public IEnumerable<string> GetCustomerAddress(int addressId)
        {
            string[] customerAddressData = new string[9];

            string[] addressData  = getAddress(addressId);
            string[] cityData = getCity(addressData[3]);
            string[] countryData = getCountry(cityData[2]);

            customerAddressData[0] = addressData[0]; // addressId
            customerAddressData[1] = cityData[0]; // cityId 
            customerAddressData[2] = countryData[0]; // countryId

            customerAddressData[3] = addressData[1]; // address
            customerAddressData[4] = addressData[2]; // address2
            customerAddressData[5] = addressData[4]; // postalCode
            customerAddressData[6] = addressData[5]; // phone

            customerAddressData[7] = cityData[1]; // city
            customerAddressData[8] = countryData[1]; // country


            return customerAddressData;
        }

        private static string[] getCountry(object countryId)
        {
            string query = "SELECT * FROM country WHERE countryId=" + countryId + ";";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] country = new string[2];
                    country[0] = reader.GetInt32(0).ToString(); // countryId
                    country[1] = reader.GetString(1); // country

                    return country;
                }
            }
            throw new Exception();
        }

       

        private static string[] getCity(object cityId)
        {
            string query = "SELECT * FROM city WHERE cityId=" + int.Parse(cityId.ToString()) + ";";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] city = new string[3];
                    city[0] = reader.GetInt32(0).ToString(); // cityId
                    city[1] = reader.GetString(1); // city
                    city[2] = reader.GetInt32(6).ToString(); // countryId

                    return city;
                }
            }
            throw new Exception();
        }

        private static string[] getAddress(object addressId)
        {
            string query = "SELECT * FROM address WHERE addressId=" + addressId + ";";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] address = new string[6];

                    address[0] = reader.GetInt32(0).ToString(); // addressId
                    address[1] = reader.GetString(1); // address
                    address[2] = reader.GetString(2); // address2
                    address[3] = reader.GetInt32(3).ToString(); //cityId
                    address[4] = reader.GetString(4); // postalCode
                    address[5] = reader.GetString(5); // phone

                    return address;
                }
            }
            throw new Exception();
        }

        static public bool DeleteAppointment(int appointmentId)
        {
            string query = "DELETE FROM appointment WHERE appointmentId=" + appointmentId + ";";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
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

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        static public void SaveNewAppointment(Appointment newAppointment)
        {
            string query = SqlFormat(newAppointment);

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static public void SaveUpdatedAppointment(Appointment updatedAppointment, int updatedAppointmentId)
        {
            // find appointment id and replace with new appointment
            string query = "UPDATE appointment SET customerId=" + updatedAppointment.CustomerId + ", userId=" + updatedAppointment.UserId + ", title=' " + updatedAppointment.Title + "', description='" + updatedAppointment.Description + "', location='" + updatedAppointment.Location + "', contact='" + updatedAppointment.Contact + "', type='" + updatedAppointment.Type + "', url='" + updatedAppointment.Url + "', start='" + updatedAppointment.Start.ToString("yyyy-MM-dd HH:mm:ss") + "', end='" + updatedAppointment.End.ToString("yyyy-MM-dd HH:mm:ss") + "', lastUpdate='" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss") + "', lastUpdateBy='" + Scheduler.userName + "' WHERE appointmentId=" + updatedAppointmentId + ";";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }
        // int customerId, int addressId, int cityId, int countryId, string customerName, string address, string address2, string city, string country, string postalCode, string phone, bool active

        static public void SaveUpdatedCustomer(Customer updatedCustomer)
        {
            // createDate, createdBy, lastUpdate, lastUpdatedBy
            object[] commonTableData = GetCommonTableData();

            string queryCountry = "UPDATE country SET country='" + updatedCustomer.Country + "', lastUpdate='" + commonTableData[2] + "' WHERE countryId=" + updatedCustomer.CountryId + ";";
            string queryCity = "UPDATE city SET city='" + updatedCustomer.City + "', lastUpdate='" + commonTableData[2] + "' WHERE cityId=" + updatedCustomer.CityId + ";"; 
            // Confirm update queryCity works
            string queryAddress = "UPDATE address SET address='" + updatedCustomer.Address + "', address2='" + updatedCustomer.Address2 + "', postalCode='" + updatedCustomer.PostalCode + "', phone='" + updatedCustomer.Phone + "', lastUpdate='" + commonTableData[2] + "' WHERE addressId=" + updatedCustomer.AddressId + ";";
            string queryCustomer = "UPDATE customer SET customerName='" + updatedCustomer.CustomerName + "', active=" + updatedCustomer.Active + ", lastUpdate='" + commonTableData[2] + "', lastUpdateBy='" + commonTableData[3] + "' WHERE customerId=" + updatedCustomer.CustomerId + ";";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand commandCountry = new MySqlCommand(queryCountry, connection);
                MySqlCommand commandCity = new MySqlCommand(queryCity, connection);
                MySqlCommand commandAddress = new MySqlCommand(queryAddress, connection);
                MySqlCommand commandCustomer = new MySqlCommand(queryCustomer, connection);

                connection.Open();
                
                commandCountry.ExecuteNonQuery();
                commandCity.ExecuteNonQuery();
                commandAddress.ExecuteNonQuery();
                commandCustomer.ExecuteNonQuery();
            }
        }

        internal static List<string> GetUniqueConsultants()
        {
            List<string> uniqueConsultants = new List<string>();
            string query = "SELECT DISTINCT userName FROM user;";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    uniqueConsultants.Add(reader.GetString(0)); // user.userName
                }
            }

            return uniqueConsultants;
        }

        static public DataTable GetAppointmentsByConsultant(string consultant)

        {
            string query = "SELECT * FROM appointment WHERE createdBy='" + consultant + "';";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable appointmentsDataTable = new DataTable();
                adapter.Fill(appointmentsDataTable);

                // Convert UTC to local
                foreach (DataRow row in appointmentsDataTable.Rows)
                {
                    DateTime start = (DateTime)row["start"];
                    row["start"] = start.ToLocalTime();
                    DateTime end = (DateTime)row["end"];
                    row["end"] = end.ToLocalTime();
                    DateTime createDate = (DateTime)row["createDate"];
                    row["createDate"] = createDate.ToLocalTime();
                    DateTime lastUpdate = (DateTime)row["lastUpdate"];
                    row["lastUpdate"] = lastUpdate.ToLocalTime();
                }

                return appointmentsDataTable;
            }
        }

        static public List<List<string[]>> GetAppointmentsByCustomer()
        {
            List<List<string[]>> allAppointments = new List<List<string[]>>();
            List<int> customerIds = new List<int>();

            // Get all customersId
            string customerIdQuery = "SELECT customerId FROM customer;";


            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(customerIdQuery, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customerIds.Add(reader.GetInt32(0)); // user.userName
                }
                connection.Close();
            }

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                
                for(int i = 0; i < customerIds.Count; i++)
                {
                    string appointmentQuery = "SELECT * FROM appointment WHERE customerId=" + customerIds[i];
                    List<string[]> appointmentsPerCustomer = new List<string[]>();

                    MySqlCommand command = new MySqlCommand(appointmentQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) // Reads one row at a time
                    {
                        string[] appointmentData = new string[4];
                        appointmentData[0] = reader.GetInt32(1).ToString(); // customerId
                        appointmentData[1] = reader.GetString(3); // title
                        appointmentData[2] = reader.GetDateTime(9).ToLocalTime().ToString(); // start
                        appointmentData[3] = reader.GetDateTime(10).ToLocalTime().ToString(); // end
                        appointmentsPerCustomer.Add(appointmentData);
                    }
                    allAppointments.Add(appointmentsPerCustomer);
                    reader.Close();
                }
                connection.Close();
            }

            return allAppointments;
        }

        static private string SqlFormat(Appointment newAppointment)
        {
            object[] commonTableData = GetCommonTableData();
            string query = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (" + newAppointment.CustomerId + ", " + newAppointment.UserId + ", \'" + newAppointment.Title + "\', \'" + newAppointment.Description + "\', \'" + newAppointment.Location + "\', \'" + newAppointment.Contact + "\', \'" + newAppointment.Type + "\', \'" + newAppointment.Url + "\', \'" + newAppointment.Start.ToString("yyyy-MM-dd HH:mm:ss") + "\', \'" + newAppointment.End.ToString("yyyy-MM-dd HH:mm:ss") + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";
           
            return query;
        }


        static public int SaveCountry(string country)
        {
            object[] commonTableData = GetCommonTableData();

            string query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (\'" + country + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";

            string selectQuery = "SELECT LAST_INSERT_ID()";
            //string selectQuery = "SELECT countryId FROM country WHERE country = \'" + country + "\';";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlCommand select = new MySqlCommand(selectQuery, connection);
                connection.Open();
                command.ExecuteNonQuery();
                MySqlDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    int result = reader.GetInt32(0);
                    return result;
                }
            }
            return -1;
        }

        static public int SaveCity(string city, int countryId)
        {
            object[] commonTableData = GetCommonTableData();

            string query = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (\'" + city + "\', " + countryId + ", \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";
            string selectQuery = "SELECT LAST_INSERT_ID()";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
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

        static public int SaveAddress(string address, string address2, int cityId, string postalCode, string phone)
        {
            object[] commonTableData = GetCommonTableData();

            string query = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (\'" + address + "\', \'" + address2 + "\', \'" + cityId + "\', \'" + postalCode + "\', \'" + phone + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";
            string selectQuery = "SELECT LAST_INSERT_ID()";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
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

        static public void SaveNewCustomer(Customer newCustomer)
        {
            object[] commonTableData = GetCommonTableData();

            string query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (\'" + newCustomer.CustomerName + "\', " + newCustomer.AddressId + ", \'" + Convert.ToInt32(newCustomer.Active) + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }
        static private object[] GetCommonTableData()
        {
            // createDate, createdBy, lastUpdate, lastUpdatedBy
            object[] commonTableData = new object[4] { DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"), Scheduler.userName, DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"), Scheduler.userName };
            return commonTableData;
        }

    }
}
