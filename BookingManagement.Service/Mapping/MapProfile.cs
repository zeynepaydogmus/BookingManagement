using AutoMapper;
using BookingManagement.Core.DTOs;
using BookingManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Place , PlaceDto>().ReverseMap();
            CreateMap<UserBooking, UserBookingDto>().ReverseMap();  
        }
    }
}
