using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsSPAWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsSPAWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private NewsSPAContext _dbContext;
        public ThemesController(NewsSPAContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        [HttpGet]
        public IEnumerable<Themes> Get()
        {
            return _dbContext.Themes.ToList();
        }

        [HttpPost]
        public Themes Save(Themes themes)
        {
            if (themes.Id == 0)
            {
                _dbContext.Themes.Add(themes);
            }
            else
            {
                _dbContext.Entry(themes).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
            return _dbContext.Themes.FirstOrDefault(t => t.Id == themes.Id);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Themes theme = new Themes() { Id = id };
            _dbContext.Themes.Attach(theme);
            _dbContext.Themes.Remove(theme);
            _dbContext.SaveChanges();

            return new JsonResult("Deleted Successfully!");
        }
    }
}
