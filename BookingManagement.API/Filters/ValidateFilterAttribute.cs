using BookingManagement.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookingManagement.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        //sync
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var err = context.ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400 , err));
                
            }
        }
    }
}
