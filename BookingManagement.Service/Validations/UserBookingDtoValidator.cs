using BookingManagement.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Service.Validations
{
    public class UserBookingDtoValidator : AbstractValidator<UserBookingDto>
    {
        public UserBookingDtoValidator()
        {
            RuleFor(x => x.UserId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0.");
            RuleFor(x => x.PlaceId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0.");

        }
    }
}
