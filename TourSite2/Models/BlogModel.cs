using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourSite2.Models
{
    public class BlogModel
    {
        public IEnumerable<Blog> Blogs { get;set;}
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Theme> Themes { get; set; }
    }
}