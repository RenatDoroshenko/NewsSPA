using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewsSPAWebApi.Models
{
    public partial class Users
    {
        public Users()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public int? RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
