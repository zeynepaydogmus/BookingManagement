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
    public class PlaceSeed : IEntityTypeConfiguration<Place>
    {

        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasData(new Place
            {
                Id = 1,
                Name = "DummyName",
                Adress = "DummyAdress",
                Status = true,
                Capacity = 150,
                Category = "Vine House",
                CreatedDate = DateTime.Now,
            }, 
            new Place
            {
                Id = 2,
                Name = "DummyName",
                Adress = "DummyAdress",
                Status = true,
                Capacity = 130,
                Category = "Fine Dine",
                CreatedDate = DateTime.Now,
            },
            new Place
            {
                Id = 3,
                Name = "DummyName",
                Adress = "DummyAdress",
                Status = true,
                Capacity = 200,
                Category = "Grill House",
                CreatedDate = DateTime.Now,
            }
            );
        }
    }
}
