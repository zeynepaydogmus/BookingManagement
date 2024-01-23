using BookingManagement.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Service.Validations
{
    public class PlaceDtoValidator : AbstractValidator<PlaceDto>
    {
        public PlaceDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Adress).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Capacity).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Category).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}
