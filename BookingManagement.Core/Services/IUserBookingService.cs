using BookingManagement.Core.DTOs;
using BookingManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Core.Services
{
    public interface IUserBookingService : IService<UserBooking>
    {
        Task<CustomResponseDto<List<UserBookingWithPlaceDto>>> GetUserBookingsWithPlace();
    }
}
