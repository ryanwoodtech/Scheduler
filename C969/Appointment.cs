using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    class Appointment
    {
        public int customerId { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdatedBy { get; set; }

        // SELECT appointmentId, customerId, userId, title, description, location, contact, type, url, start, end FROM appointment;
        public Appointment(int customerId, int userId, string title, string description, string location, string contact, string type, string url, DateTime start, DateTime end, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            this.customerId = customerId;
            this.userId = userId;
            this.title = title;
            this.description = description;
            this.location = location;
            this.contact = contact;
            this.type = type;
            this.url = url;
            this.start = start;
            this.end = end;
            this.createDate = createDate;
            this.createdBy = createdBy;
            this.lastUpdate = lastUpdate;
            this.lastUpdatedBy = lastUpdatedBy;
        }
    }
}
