using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public int AddressId { get; set; }

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