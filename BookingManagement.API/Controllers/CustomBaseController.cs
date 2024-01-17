﻿using BookingManagement.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 200)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };



        }
    }
}
