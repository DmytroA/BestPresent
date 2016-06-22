using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace TourSite2.Controllers
{
    public class NewsController : Controller
    {
        TourEntities1 context = new TourEntities1();
        public ActionResult Index(int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_news" : string.Empty;
            var news = from s in context.News
                         select s;
            switch (sortOrder)
            {
                case "name_news":
                    news = news.OrderBy(s => s.Name);
                    break;
              
                default:
                    news = news.OrderBy(s => s.Id);
                    break;
            }
            //var data = context.News.ToList();
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(news.ToPagedList(pageNumber, pageSize));
            
        }
        [HttpGet]
        public ActionResult NewsDetails(int Id)
        {
            var data = context.News.SingleOrDefault(m => m.Id == Id);

            return View(data);
        }
	}
}