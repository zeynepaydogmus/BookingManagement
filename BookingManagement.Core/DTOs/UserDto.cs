using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Core.DTOs
{
    public class UserDto : BaseDto
    {
        public string Surname { get; set; }
        public string Gender { get; set; }
        public int TelNumber { get; set; }
    }
}
