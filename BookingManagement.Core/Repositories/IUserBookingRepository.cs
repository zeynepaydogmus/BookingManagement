using BookingManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Core.Repositories
{
    public interface IUserBookingRepository : IGenericRepository<UserBooking>
    {
        Task<List<UserBooking>> GetUserBookingsWithPlace();
    }
}
