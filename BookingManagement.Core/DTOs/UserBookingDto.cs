using BookingManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Core.DTOs
{
    public class UserBookingDto:BaseDto
    {
        public int UserId { get; set; }
        public int PlaceId { get; set; }
    }
}
