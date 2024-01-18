using BookingManagement.Core.Models;
using BookingManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Repository.Repositories
{
    public class UserBookingRepository : GenericRepository<UserBooking>, IUserBookingRepository
    {
        public UserBookingRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<List<UserBooking>> GetUserBookingsWithPlace()
        {
            return await _appDbContext.UserBooking.Include(x => x.Place).ToListAsync();
        }
    }
}
