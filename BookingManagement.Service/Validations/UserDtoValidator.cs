using BookingManagement.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Service.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Gender).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.TelNumber)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .Matches("^[0-9]{9,}$").WithMessage("{PropertyName} is false.");
        }
    }
}
