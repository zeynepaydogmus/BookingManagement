using AutoMapper;
using BookingManagement.Core.DTOs;
using BookingManagement.Core.Models;
using BookingManagement.Core.Repositories;
using BookingManagement.Core.Services;
using BookingManagement.Core.UnitOfWorks;
using BookingManagement.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Caching
{
    public class UserBookingServiceWithCaching : IUserBookingService
    {
        //key-value cache
        private const string CacheUserBookingKey = "userBookingCache";
        //for Dto
        private readonly IMapper _mapper;
        //Inmemory cahce -> IMemoryCache
        private readonly IMemoryCache _memoryCache;
        //repos
        private readonly IUserBookingRepository _repository;
        //for db
        private readonly IUnitOfWork _unitOfWork;

        public UserBookingServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IUserBookingRepository userBookingRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = userBookingRepository;
            _unitOfWork = unitOfWork;
            //ilk nesne örneğinde cacheleme yap.
            if(!_memoryCache.TryGetValue(CacheUserBookingKey, out _))
            {
                _memoryCache.Set(CacheUserBookingKey, _repository.GetUserBookingsWithPlace().Result);
            }
        }

        public async Task<UserBooking> AddAsync(UserBooking entity)
        {
            //repo ile entity ekledim
            await _repository.AddAsync(entity);
            //veritabanına yansıt
            await _unitOfWork.CommitAsync();
            //cacheleyeceğin data çok sık değiştirmeyeceğin ama çok sık erişeceğin datalar olmalıdır.
            await CacheAllUserBookingsAsync();
            return entity;

        }

        public Task<bool> AnyAsync(Expression<Func<UserBooking, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(UserBooking entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllUserBookingsAsync();
        }

        public Task<IEnumerable<UserBooking>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<UserBooking>>(CacheUserBookingKey));
        }

        public Task<UserBooking> GetByIdAsync(int id)
        {
            var userBooking = (_memoryCache.Get<List<UserBooking>>(CacheUserBookingKey).FirstOrDefault(x => x.Id == id));
            if(userBooking == null)
            {

                throw new NotFoundException($"{typeof(UserBooking).Name} ({id}) not found");
            }
            return Task.FromResult(userBooking);
        }

        public  Task<CustomResponseDto<List<UserBookingWithPlaceDto>>> GetUserBookingsWithPlace()
        {
            var userBookings = _memoryCache.Get<IEnumerable<UserBooking>>(CacheUserBookingKey);
           var userBookingsWithPlaceDto = _mapper.Map<List<UserBookingWithPlaceDto>>(userBookings);
            return Task.FromResult( CustomResponseDto<List<UserBookingWithPlaceDto>>.Success(200, userBookingsWithPlaceDto));

        }

        public async Task UpdateAsync(UserBooking entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllUserBookingsAsync();
        }

        public IQueryable<UserBooking> Where(Expression<Func<UserBooking, bool>> expression)
        {
            return _memoryCache.Get<List<UserBooking>>(CacheUserBookingKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllUserBookingsAsync()
        {
            //her çağırıldığında datayı çekip cacheler
             _memoryCache.Set(CacheUserBookingKey, await _repository.GetAll().ToListAsync());
        }
    }
}
