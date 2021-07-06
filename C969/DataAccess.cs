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
        static string connectionString = "server=wgudb.ucertify.com;userid=U08hnQ;database=U08hnQ;password=53689293162;";
        static public DataTable GetAppointments()
        {
            string query = "SELECT * FROM appointment;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

        static public string GetCustomerName(int customerId)
        {
            string query = "SELECT customerName FROM customer WHERE customerId=" + customerId + ";";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

        static public List<string[]> GetCustomersInfo()
        {
            string query = "SELECT * FROM customer;";
            List<string[]> customerData = new List<string[]>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] city = new string[3];
                    city[0] = reader.GetInt32(2).ToString(); // cityId
                    city[1] = reader.GetString(1); // city
                    city[2] = reader.GetInt32(2).ToString(); // countryId

                    return city;
                }
            }
            throw new Exception();
        }

        private static string[] getAddress(object addressId)
        {
            string query = "SELECT * FROM address WHERE addressId=" + addressId + ";";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static public void SaveNewAppointment(Appointment newAppointment)
        {
            string query = SqlFormat(newAppointment);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static public void SaveUpdatedAppointment(Appointment updatedAppointment, int updatedAppointmentId)
        {
            // find appointment id and replace with new appointment
            string query = "UPDATE appointment SET customerId=" + updatedAppointment.customerId + ", userId=" + updatedAppointment.userId + ", title=' " + updatedAppointment.title + "', description='" + updatedAppointment.description + "', location='" + updatedAppointment.location + "', contact='" + updatedAppointment.contact + "', type='" + updatedAppointment.type + "', url='" + updatedAppointment.url + "', start='" + updatedAppointment.start.ToString("yyyy-MM-dd HH:mm:ss") + "', end='" + updatedAppointment.end.ToString("yyyy-MM-dd HH:mm:ss") + "', lastUpdate='" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss") + "', lastUpdateBy='" + Scheduler.userName + "' WHERE appointmentId=" + updatedAppointmentId + ";";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        static public void SaveUpdatedCustomer(int customerId, int addressId, int cityId, int countryId, string customerName, string address, string address2, string city, string country, string postalCode, string phone, bool active)
        {
            // Confirm correct cityId was passed in
            object[] commonTableData = GetCommonTableData();

            string queryCountry = "UPDATE country SET country='" + country + "', lastUpdate='" + commonTableData[2] + "' WHERE countryId=" + countryId + ";";
            string queryCity = "UPDATE city SET city='" + city + "', lastUpdate='" + commonTableData[2] + "' WHERE cityId=" + cityId + ";"; 
            // Confirm update queryCity works
            string queryAddress = "UPDATE address SET address='" + address + "', address2='" + address2 + "', postalCode='" + postalCode + "', phone='" + phone + "', lastUpdate='" + commonTableData[2] + "' WHERE addressId=" + addressId + ";";
            string queryCustomer = "UPDATE customer SET customerName='" + customerName + "', active=" + active + ", lastUpdate='" + commonTableData[2] + "' WHERE customerId=" + customerId + ";";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

        static private string SqlFormat(Appointment newAppointment)
        {
            object[] commonTableData = GetCommonTableData();
            string query = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (" + newAppointment.customerId + ", " + newAppointment.userId + ", \'" + newAppointment.title + "\', \'" + newAppointment.description + "\', \'" + newAppointment.location + "\', \'" + newAppointment.contact + "\', \'" + newAppointment.type + "\', \'" + newAppointment.url + "\', \'" + newAppointment.start.ToString("yyyy-MM-dd HH:mm:ss") + "\', \'" + newAppointment.end.ToString("yyyy-MM-dd HH:mm:ss") + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";

            return query;
        }


        static public int SaveCountry(string country)
        {
            object[] commonTableData = GetCommonTableData();

            string query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (\'" + country + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";

            string selectQuery = "SELECT LAST_INSERT_ID()";
            //string selectQuery = "SELECT countryId FROM country WHERE country = \'" + country + "\';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

        static public int SaveAddress(string address, string address2, int cityId, string postalCode, string phone)
        {
            object[] commonTableData = GetCommonTableData();

            string query = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (\'" + address + "\', \'" + address2 + "\', \'" + cityId + "\', \'" + postalCode + "\', \'" + phone + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";
            string selectQuery = "SELECT LAST_INSERT_ID()";

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

        static public void SaveNewCustomer(string customerName, int addressId, bool active)
        {
            object[] commonTableData = GetCommonTableData();

            string query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (\'" + customerName + "\', " + addressId + ", \'" + Convert.ToInt32(active) + "\', \'" + commonTableData[0] + "\', \'" + commonTableData[1] + "\', \'" + commonTableData[2] + "\', \'" + commonTableData[3] + "\');";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
