using AutoMapper;
using BookingManagement.Core.DTOs;
using BookingManagement.Core.Models;
using BookingManagement.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookingController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<UserBooking> _service;
        public UserBookingController(IService<UserBooking> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetUserBookingWithPlace")]
        public Task<IActionResult> GetUserBookingWithPlace()
        {

        }




        [HttpGet]
        public async Task<IActionResult> All()
        {
            var userBookings = await _service.GetAllAsync();
            var userBookingDtos = _mapper.Map<List<UserBookingDto>>(userBookings.ToList());
            return CreateActionResult(CustomResponseDto<List<UserBookingDto>>.Success(200, userBookingDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userBooking = await _service.GetByIdAsync(id);
            var userBookingDtos = _mapper.Map<UserBookingDto>(userBooking);
            return CreateActionResult(CustomResponseDto<UserBookingDto>.Success(200, userBookingDtos));
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserBookingDto userBookingDto)
        {
            var userBooking = await _service.AddAsync(_mapper.Map<UserBooking>(userBookingDto));
            var userBookingsDtos = _mapper.Map<UserBookingDto>(userBooking);
            return CreateActionResult(CustomResponseDto<UserBookingDto>.Success(201, userBookingsDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserBookingDto userBookingDto)
        {
            await _service.UpdateAsync(_mapper.Map<UserBooking>(userBookingDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var userBooking = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(userBooking);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
