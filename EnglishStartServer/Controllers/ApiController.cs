﻿using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EnglishStartServer.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]/{data?}")]
    [EnableCors("AllowAll")]
    public class ApiController : Controller
    {
        protected Guid GetUserId()
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier));
            return claim == null ? Guid.Empty : Guid.Parse(claim.Value);
        }

        public IActionResult Json<T>(int code = 200, T data = default(T), string message = "")
        {
            return Json(new
            {
                data,
                message,
                code
            });
        }
    }
}