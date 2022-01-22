using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class Customer
    {
        public string CustomerName;
        public string Address;
        public string Address2;
        public string City;
        public string PostalCode;
        public string Phone;
        public bool Active;
        public int AddressId; 

        public Customer(string customerName, string address, string address2, string city, string postalCode, string phone, bool active, int addressId = -1)
        {
            CustomerName = customerName;
            Address = address;
            Address2 = address2;
            City = city;
            PostalCode = postalCode;
            Phone = phone;
            Active = active;
            AddressId = addressId;
        }
    }
}