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
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Test",
                    Surname = "Test",
                    Gender = "Kadın",
                    TelNumber = 21211222,
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 2,
                    Name = "Test1",
                    Surname = "Test1",
                    Gender = "Kadın",
                    TelNumber = 21211222,
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 3,
                    Name = "Test2",
                    Surname = "Test2",
                    Gender = "Erkek",
                    TelNumber = 21211222,
                    CreatedDate = DateTime.Now,

                }, 
                new User
                {
                    Id = 4,
                    Name = "Test3",
                    Surname = "Test3",
                    Gender = "Erkek",
                    TelNumber = 21211222,
                    CreatedDate = DateTime.Now,
                }
                );
        }
    }
}
