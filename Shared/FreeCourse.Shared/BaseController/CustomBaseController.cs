﻿using FreeCourse.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Shared.BaseController
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
