using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishStartServer.Database;
using EnglishStartServer.Database.Models;
using EnglishStartServer.Dto;
using EnglishStartServer.Dto.InformationBlocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishStartServer.Controllers
{
    public class TestController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Test1()
        {
            var article = new Article
            {
                CourseId = Guid.Parse("604BC77E-9412-4180-82E3-08D53A811364"),
                Name = "First article",
                Description = "Article for tests",
                InformationBlocks = new List<InformationBlock>
                {
                    new TextInformationBlock
                    {
                        SequentialNumber = 0,
                        Text = "Introduction"
                    },
                    new TextInformationBlock
                    {
                        SequentialNumber = 1,
                        Text = "Some text"
                    },
                    new VideoInformationBlock
                    {
                        SequentialNumber = 2,
                        Url = "http://google.com/video/1"
                    },
                    new TextInformationBlock
                    {
                        SequentialNumber = 3,
                        Text = "Сonclusion"
                    }
                }
            };

            await _context.Articles.AddAsync(article);

            await _context.SaveChangesAsync();

            return Json("Executed Test1");
        }

        public async Task<IActionResult> Test2()
        {
            var id = Guid.Parse("6a14197e-a8e0-43a6-e2f7-08d53f2e2caf");

            var article = await _context.Articles.Include(a => a.InformationBlocks)
                .FirstOrDefaultAsync(a => a.Id == id);
            
            return Json(article.ToDto(article.InformationBlocks.OrderBy(b => b.SequentialNumber)));
        }

//        [HttpPost]
        public async Task<IActionResult> Test3(/*[FromBody] */InformationBlockModel m)
        {

            return Json(m);
        }
    }
}