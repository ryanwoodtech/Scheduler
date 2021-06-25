using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    class Customer
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public int addressId { get; set; }
        public int active { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdatedBy { get; set; }
        public Customer(int customerId, string customerName, int addressId, int active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            this.customerId = customerId;
            this.customerName = customerName;
            this.addressId = addressId;
            this.active = active;
            this.createDate = createDate;
            this.createdBy = createdBy;
            this.lastUpdate = lastUpdate;
            this.lastUpdatedBy = lastUpdatedBy;
        }
    }
}
