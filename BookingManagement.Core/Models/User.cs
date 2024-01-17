using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Core.Models
{
    public class User :BaseEntity
    {

        public string Surname { get; set; }
        public string Gender { get; set; }
        public int TelNumber { get; set; }
        public ICollection<UserBooking> UserBookings { get; set; }
    }
}
