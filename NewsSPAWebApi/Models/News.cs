using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewsSPAWebApi.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int? ThemeId { get; set; }

        public virtual Users Author { get; set; }
        public virtual Themes Theme { get; set; }
    }
}
