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

        static private int SaveSimilarData(string address, string address2, string city, string country, string postalCode, string phone)
        {
            int countryId = DataAccess.SaveCountry(country);
            int cityId = DataAccess.SaveCity(city, countryId);
            int addressId = DataAccess.SaveAddress(address, address2, cityId, postalCode, phone);

            return addressId;
        }

        static public void AddCustomer(string customerName, string address, string address2, string city, string country, string postalCode, string phone, bool active)
        {
            int addressId = SaveSimilarData(address, address2, city, country, postalCode, phone);

            DataAccess.SaveNewCustomer(customerName, addressId, active);
        }
        static public bool DeleteCustomer(int customerId)
        {
            // Delete appointment
            return DataAccess.DeleteCustomer(customerId);
            
        }
    }
}
