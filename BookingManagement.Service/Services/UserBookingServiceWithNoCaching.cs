using AutoMapper;
using BookingManagement.Core.DTOs;
using BookingManagement.Core.Models;
using BookingManagement.Core.Repositories;
using BookingManagement.Core.Services;
using BookingManagement.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Service.Services
{
    public class UserBookingServiceWithNoCaching : Service<UserBooking>, IUserBookingService
    {
        private readonly IUserBookingRepository _userBookingRepository;
        private readonly IMapper   _mapper;
        public UserBookingServiceWithNoCaching(IGenericRepository<UserBooking> repository, IUnitOfWork unitOfWork, IUserBookingRepository userBookingRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _userBookingRepository = userBookingRepository;
        }

        public async Task<CustomResponseDto<List<UserBookingWithPlaceDto>>> GetUserBookingsWithPlace()
        {
            var userBookings = await _userBookingRepository.GetUserBookingsWithPlace();
            var userBookingsDto = _mapper.Map<List<UserBookingWithPlaceDto>>(userBookings);
            return CustomResponseDto<List<UserBookingWithPlaceDto>>.Success(200, userBookingsDto);

        }
    }
}
