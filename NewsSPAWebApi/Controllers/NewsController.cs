using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsSPAWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSPAWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private NewsSPAContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public NewsController(NewsSPAContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }


        [HttpGet]
        public IEnumerable<News> Get()
        {
            return _dbContext.News
                .Include(n => n.Author)
                .Include(n => n.Theme)
                .ToList();
        }

        [HttpPost]
        public News Save(News news)
        {
            if (news.Id == 0)
            {
                _dbContext.News.Add(news);
            }
            else
            {
                _dbContext.Entry(news).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
            return _dbContext.News.FirstOrDefault(n => n.Id == news.Id);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            News news = new News() { Id = id };
            _dbContext.News.Attach(news);
            _dbContext.News.Remove(news);
            _dbContext.SaveChanges();

            return new JsonResult("Deleted Successfully!");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {

            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Images/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }
}
