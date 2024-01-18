using BookingManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Repository.Seeds
{
    public class UserBookingSeed : IEntityTypeConfiguration<UserBooking>
    {
        public void Configure(EntityTypeBuilder<UserBooking> builder)
        {
            builder.HasData(new UserBooking
            {
                Name="a",
                Id = 1,
                UserId = 1,
                PlaceId = 1,
                CreatedDate = DateTime.Now,
            },
            new UserBooking
            {
                Name = "a",
                Id = 2,
                UserId = 2,
                PlaceId = 2,
                CreatedDate = DateTime.Now,
            },
            new UserBooking
            {

                Name = "a",
                Id = 3,
                UserId = 3,
                PlaceId = 1,
                CreatedDate = DateTime.Now,
            },
            new UserBooking
            {
                Name = "a",
                Id = 4,
                UserId = 4,
                PlaceId = 3,
                CreatedDate = DateTime.Now,
            }
            );
        }
    }
}
