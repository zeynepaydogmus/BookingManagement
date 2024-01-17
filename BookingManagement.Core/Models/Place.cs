using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Core.Models
{
    public class Place:BaseEntity
    {
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int Capacity { get; set; }
        public string Category { get; set; }
        public ICollection<UserBooking> UserBookings { get; set; }

    }
}
