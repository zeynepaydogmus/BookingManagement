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
    public class PlaceController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Place> _service;
        public PlaceController(IService<Place> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var places = await _service.GetAllAsync();
            var placeDtos = _mapper.Map<List<PlaceDto>>(places.ToList());
            return CreateActionResult(CustomResponseDto<List<PlaceDto>>.Success(200, placeDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var places = await _service.GetByIdAsync(id);
            var placeDtos = _mapper.Map<PlaceDto>(places);
            return CreateActionResult(CustomResponseDto<PlaceDto>.Success(200, placeDtos));
        }
        [HttpPost]
        public async Task<IActionResult> Save(PlaceDto placeDto)
        {
            var place = await _service.AddAsync(_mapper.Map<Place>(placeDto));
            var placeDtos = _mapper.Map<PlaceDto>(place);
            return CreateActionResult(CustomResponseDto<PlaceDto>.Success(201, placeDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(PlaceDto placeDto)
        {
            await _service.UpdateAsync(_mapper.Map<Place>(placeDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var place = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(place);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
