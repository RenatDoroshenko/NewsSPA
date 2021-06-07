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
    public class UsersController : ControllerBase
    {
        private NewsSPAContext _dbContext;
        public UsersController(NewsSPAContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _dbContext.Users.ToList();
        }

        [HttpPost]
        public Users Save(Users user)
        {
            if (user.Id == 0)
            {
                _dbContext.Users.Add(user);
            }
            else
            {
                _dbContext.Entry(user).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
            return _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Users users = new Users() { Id = id };
            _dbContext.Users.Attach(users);
            _dbContext.Users.Remove(users);
            _dbContext.SaveChanges();

            return new JsonResult("Deleted Successfully!");
        }
    }
}
