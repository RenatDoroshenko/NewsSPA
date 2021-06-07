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
    public class RolesController : ControllerBase
    {
        private NewsSPAContext _dbContext;
        public RolesController(NewsSPAContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IEnumerable<Roles> Get()
        {
            return _dbContext.Roles.ToList();
        }

        [HttpPost]
        public Roles Save(Roles role)
        {
            if (role.Id == 0)
            {
                _dbContext.Roles.Add(role);
            }
            else
            {
                _dbContext.Entry(role).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
            return _dbContext.Roles.FirstOrDefault(r => r.Id == role.Id);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Roles role = new Roles() { Id = id };
            _dbContext.Roles.Attach(role);
            _dbContext.Roles.Remove(role);
            _dbContext.SaveChanges();

            return new JsonResult("Deleted Successfully!");
        }
    }
}
