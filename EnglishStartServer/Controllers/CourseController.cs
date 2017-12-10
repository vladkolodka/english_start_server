using System;
using System.Threading.Tasks;
using EnglishStartServer.Dto;
using EnglishStartServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EnglishStartServer.Controllers
{
    public class CourseController : ApiController
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseModel data)
        {   
            return Json(data: await _service.CreateCourse(GetUserId(), data));
        }

        public async Task<IActionResult> All(int offset, int count)
        {
            return Json(data: await _service.GetAllCourses(GetUserId(), offset, count));
        }

        public async Task<IActionResult> Own()
        {
            return Json(data: await _service.GetUserCourses(GetUserId()));
        }

        public async Task<IActionResult> Assign(Guid courseId)
        {
            return Json(data: await _service.AssignCourse(GetUserId(), courseId));
        }
        public async Task<IActionResult> SetLearnStatus(Guid courseId, bool status)
        {
            return Json(data: await _service.SetCourseLearnStatus(GetUserId(), courseId, status));
        }
    }
}