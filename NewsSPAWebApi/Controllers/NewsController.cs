using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsSPAWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSPAWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private NewsSPAContext _dbContext;
        public NewsController(NewsSPAContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IEnumerable<News> Get()
        {
            return _dbContext.News.ToList();
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
    }
}
