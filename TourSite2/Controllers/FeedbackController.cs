using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Net.Mail;
using System.Threading.Tasks;
using PagedList;

namespace TourSite2.Controllers
{
    public class FeedbackController : Controller
    {
        //
        // GET: /Feedback/

        public ActionResult Index()
        {
            var context = new TourEntities1();
            var data = context.Feed.ToList();
            
            return View(data);
        }
        [HttpGet]
        public ActionResult FeedbackDetails(int Id)
        {
            var context = new TourEntities1();
            var data = context.Feed.SingleOrDefault(m => m.Id == Id);

            return View(data);
        }
        public ActionResult SendFeed(int Id)
        {
            var context = new TourEntities1();
            var data = context.Feed.FirstOrDefault(p => p.Id == Id);
            return View(data);
        }
        [HttpPost]
        [ValidateInput(false)]
        public void SaveFeed(Feed b)
        {
            var context = new TourEntities1();

            if (b.Id == 0)
            {
                b.Date = DateTime.Now;
                context.Feed.Add(b);
            }
            else
            {

                Feed dbEntry = context.Feed.Find(b.Id);
                if (dbEntry != null)
                {

                    dbEntry.Name = b.Name;
                    dbEntry.Description = b.Description;
                    dbEntry.ShortDesc = b.ShortDesc;
                    dbEntry.Id = b.Id;
                    dbEntry.Author = b.Author;
                }
            }

            context.SaveChanges();
        }
        public void Mail(Feed feedback)
        {
            DateTime thisday = DateTime.Now;

            MailAddress from = new MailAddress("bestpresentkh@mail.ru");
            MailAddress To = new MailAddress("nata_bar@list.ru"); //nata_bar@list.ru
            MailMessage message2 = new MailMessage(from, To);

            message2.Subject = "Новый отзыв";
            message2.Body = "На сайте новый отзыв от: " + "\r\n" + feedback.Author + "\r\n" + "Дата:" + thisday;
            

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.mail.ru";
            client.Credentials = new System.Net.NetworkCredential("bestpresentkh@mail.ru", "nata2507");
            client.EnableSsl = true;

            try
            {
                Task.Factory.StartNew((Action)(() =>
                {
                    client.Send(message2);
                }), TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
            }


            catch (Exception ex)
            {

            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendFeed(Feed feedback)
        {

            var context = new TourEntities1();

            if (ModelState.IsValid)
            {

                SaveFeed(feedback);
                TempData["message"] = string.Format("{0} has been saved", feedback.Name);
                Mail(feedback);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(feedback);
            }
        }
        public ViewResult Create()
        {
            return View("SendFeed", new Feed());
        }
   
    }
}
