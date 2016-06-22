using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourSite2.Models
{
    public class EditBlogModel
    {
        public Blog Blogs { get; set; }
        public SelectList Author { get; set; }
        public SelectList Theme { get; set; }
    }
}