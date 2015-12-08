using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite2.Models;
using System.Net.Mail;
using System.IO;
using DataLayer;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;


namespace TourSite2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Airticket()
        {
            var context = new TourEntities();
            var data = context.Airticket.ToList();
            return View(data);
        }

        public ViewResult EditAirticket(int Id = 1)
        {
            var context = new TourEntities();
            var dat = context.Airticket.FirstOrDefault(p => p.Id == Id);

            return View(dat);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditAirticket(Airticket tour)
        {
            var context = new TourEntities();
            if (ModelState.IsValid)
            {

                SaveTickets(tour);
                TempData["message"] = string.Format("{0} has been saved", tour.Name);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(tour);
            }
        }

        public ActionResult Airtickets()
        {
            var context = new TourEntities();
            var data = context.Airticket.ToList();

            return View(data);

        }
        public void SaveTickets(Airticket b)
        {
            var context = new TourEntities();

            if (b.Id == 0)
            {

                context.Airticket.Add(b);
            }
            else
            {

                Airticket dbEntry = context.Airticket.Find(b.Id);
                if (dbEntry != null)
                {


                    dbEntry.Description = b.Description;

                    dbEntry.Name = b.Name;


                }
            }

            context.SaveChanges();
        }

        public ActionResult Visa()
        {
            var context = new TourEntities();
            var data = context.Visa.ToList();
            return View(data);
        }

        public ViewResult EditVisa(int Id = 1)
        {
            var context = new TourEntities();
            var dat = context.Visa.FirstOrDefault(p => p.Id == Id);

            return View(dat);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditVisa(Visa tour, HttpPostedFileBase image)
        {
            var context = new TourEntities();
            if (ModelState.IsValid)
            {

                SaveVisa(tour);
                TempData["message"] = string.Format("{0} has been saved", tour.Name);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(tour);
            }
        }

        public ActionResult Visas()
        {
            var context = new TourEntities();
            var data = context.Visa.ToList();

            return View(data);

        }
        public void SaveVisa(Visa b)
        {
            var context = new TourEntities();

            if (b.Id == 0)
            {

                context.Visa.Add(b);
            }
            else
            {

                Visa dbEntry = context.Visa.Find(b.Id);
                if (dbEntry != null)
                {


                    dbEntry.Decription = b.Decription;

                    dbEntry.Name = b.Name;


                }
            }

            context.SaveChanges();
        }

        public ActionResult Fishing()
        {
            var context = new TourEntities();
            var data = context.Fishing.ToList();
            return View(data);
        }

        public ViewResult EditFishing(int Id = 1)
        {
            var context = new TourEntities();
            var dat = context.Fishing.FirstOrDefault(p => p.Id == Id);

            return View(dat);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditFishing(Fishing tour, HttpPostedFileBase image)
        {
            var context = new TourEntities();
            if (ModelState.IsValid)
            {

                SaveFishing(tour);
                TempData["message"] = string.Format("{0} has been saved", tour.Name);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(tour);
            }
        }

        public ActionResult Fishings()
        {
            var context = new TourEntities();
            var data = context.Fishing.ToList();

            return View(data);

        }
        public void SaveFishing(Fishing b)
        {
            var context = new TourEntities();

            if (b.Id == 0)
            {

                context.Fishing.Add(b);
            }
            else
            {

                Fishing dbEntry = context.Fishing.Find(b.Id);
                if (dbEntry != null)
                {


                    dbEntry.Description = b.Description;

                    dbEntry.Name = b.Name;


                }
            }

            context.SaveChanges();
        }

        public ActionResult Studying()
        {
            var context = new TourEntities();
            var data = context.Studying.ToList();
            return View(data);
        }

        public ViewResult EditStudying(int Id = 1)
        {
            var context = new TourEntities();
            var dat = context.Studying.FirstOrDefault(p => p.Id == Id);

            return View(dat);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditStudying(Studying tour)
        {
            var context = new TourEntities();
            if (ModelState.IsValid)
            {

                SaveStudying(tour);
                TempData["message"] = string.Format("{0} has been saved", tour.Name);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(tour);
            }
        }

        public ActionResult Studyings()
        {
            var context = new TourEntities();
            var data = context.Studying.ToList();

            return View(data);

        }
        public void SaveStudying(Studying b)
        {
            var context = new TourEntities();

            if (b.Id == 0)
            {

                context.Studying.Add(b);
            }
            else
            {

                Studying dbEntry = context.Studying.Find(b.Id);
                if (dbEntry != null)
                {


                    dbEntry.Description = b.Description;

                    dbEntry.Name = b.Name;


                }
            }

            context.SaveChanges();
        }

        public ActionResult Placement()
        {
            var context = new TourEntities();
            var data = context.Placement.ToList();
            return View(data);
        }

        public ViewResult EditPlacement(int Id = 1)
        {
            var context = new TourEntities();
            var dat = context.Placement.FirstOrDefault(p => p.Id == Id);

            return View(dat);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPlacement(Placement tour, HttpPostedFileBase image)
        {
            var context = new TourEntities();
            if (ModelState.IsValid)
            {

                SavePlacement(tour);
                TempData["message"] = string.Format("{0} has been saved", tour.Name);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(tour);
            }
        }

        public ActionResult Placements()
        {
            var context = new TourEntities();
            var data = context.Placement.ToList();

            return View(data);

        }
        public void SavePlacement(Placement b)
        {
            var context = new TourEntities();

            if (b.Id == 0)
            {

                context.Placement.Add(b);
            }
            else
            {

                Placement dbEntry = context.Placement.Find(b.Id);
                if (dbEntry != null)
                {


                    dbEntry.Description = b.Description;

                    dbEntry.Name = b.Name;


                }
            }

            context.SaveChanges();
        }


        [HttpGet]

        public ActionResult Sub()
        {

            return View();
        }
        public ActionResult EuropeTour()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Gift()
        {
            return View();
        }


        //
        // GET: /Home/
        //TourSiteEntities2 storeDB = new TourSiteEntities2();

        static Random numb = new Random();
        static IEnumerable<int> GetNonRepeatingDigits()
        {
            var digits = Enumerable.Range(0, 10).ToArray();

            for (int i = digits.Length - 1; i > 0; i--)
            {
                int j = numb.Next(i);
                yield return digits[j];

                digits[j] ^= digits[i];
                digits[i] ^= digits[j];
                digits[j] ^= digits[i];
            }
        }



        [HttpPost]
        public ActionResult Details(int Id)
        {
            var context = new TourEntities();
            var data = context.HotTours.Find(Id);

            return View("PartialDetails", data);

        }
        [HttpGet]
        public ViewResult CountriesDetails(int Id)
        {
            var context = new TourEntities();
            var data = context.Country.Find(Id);

            return View(data);
        }
        //[HttpPost]
        //public ViewResult CountriesDetails(Country country)
        //{
        //    return View("Thanks", country);
        //}
        public ActionResult AllAbout()
        {
            var context = new TourEntities();
            var data = context.About.ToList();
            return View(data);
        }

        public ViewResult AboutEdit(int Id = 10)
        {
            var context = new TourEntities();
            var dat = context.About.FirstOrDefault(p => p.Id == Id);

            return View(dat);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AboutEdit(About tour, HttpPostedFileBase image)
        {
            var context = new TourEntities();
            if (ModelState.IsValid)
            {

                SaveAbout(tour);
                TempData["message"] = string.Format("{0} has been saved", tour.Name);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(tour);
            }
        }

        public ActionResult ONas()
        {
            var context = new TourEntities();
            var data = context.About.ToList();

            return View(data);

        }
        public void SaveAbout(About b)
        {
            var context = new TourEntities();

            if (b.Id == 0)
            {

                context.About.Add(b);
            }
            else
            {

                About dbEntry = context.About.Find(b.Id);
                if (dbEntry != null)
                {


                    dbEntry.Description = b.Description;

                    dbEntry.Name = b.Name;


                }
            }

            context.SaveChanges();
        }
        public ActionResult Index(int ?Id)
        {
            var context = new TourEntities();
            var data = context.HotTours.Include(m => m.Hotel).ToList();

            return View(data);
        }

        [HttpGet]
        public ActionResult Order()
        {
            FormsAuthProvider model = null;
            FillModelOrder(ref model);

            return View(model);
        }
        private void FillModelOrder(ref FormsAuthProvider model)
        {
            model = model ?? new FormsAuthProvider();

            var context = new TourEntities();
            //model.Country = new SelectList(context.Country, "Name", "Name");
        }
        [HttpPost]
        public ActionResult Order(FormsAuthProvider model)
        {
            if (ModelState.IsValid)
            {
                int order_number = 0;
                using (var iter = GetNonRepeatingDigits().GetEnumerator())
                    while (iter.MoveNext() && order_number < 10000)
                        order_number = order_number * 10 + iter.Current;

                DateTime thisday = DateTime.Now;

                MailAddress from = new MailAddress("bestpresentkh@mail.ru");
                MailAddress to = new MailAddress(model.MailAdress);
                MailAddress To = new MailAddress("nata_bar@list.ru"); //nata_bar@list.ru
                MailMessage message1 = new MailMessage(from, to);
                MailMessage message2 = new MailMessage(from, To);
                message1.Subject = "Информация о туре!";
                message1.Body = "Здравствуйте," + "\r\n" + "Благодарим Вас за оставленную заявку на подбор тура на сайте Туристического агентства Лучший подарок" + "\r\n" + "Дата заказа:  " + thisday.ToString() + "\r\n" + "Номер заказа:  " + order_number + "\r\n" + "\r\n" + "Вы заказали: " + "\r\n" +
                 "Примерные даты вылета:  " + Request.Params["departure"] + "\r\n" +
                    "Продолжительность тура:  " + model.Duration + "\r\n" + "Категория отеля:  " + Request.Params["check_cat"] + "\r\n" + "Ваше имя:  " + model.Name + "\r\n" + "Детей:  " + Request.Params["Children"] + "\r\n" + "Питание:  " + Request.Params["nutrition"]
                    + "\r\n" + "Ваш номер телефона:  " + model.Phone + "\r\n" + "Страна:" + model.Country + "\r\n" + "Где вы раньше бывали:  " + model.RestPlace + "\r\n" + "Предполагаемый бюджет:  " + model.EstimatedBudget + "\r\n" + "E-mail:  " + model.MailAdress + "\r\n" + "\r\n" + "В ближайшее время наши менеджеры обработают Вашу заявку  и свяжутся с Вами по указанным в заказе контактам. " + "\r\n" + "\r\n" + "\r\n" + "С уважением  и благодарностью сотрудники ТА Лучший подарок" + "\r\n" + "г. Харьков, Полтавский шлях 123, 2 этаж, офис №6" + "\r\n" + "тел. (057) 297-60-97" + "\r\n" + "моб. 066-626-00-76" + "\r\n" + "068-922-70-76";


                message2.Subject = "Новый тур";
                message2.Body = "Новый заказ тура: " + "\r\n" +
                 "Примерные даты вылета:  " + Request.Params["departure"] + "\r\n" +
                    "Продолжительность тура:  " + model.Duration + "\r\n" 
                    + "Категория отеля:  " + Request.Params["check_cat"] + "\r\n" + "Имя:  " + model.Name + "\r\n" + "Количевство детей:  " + Request.Params["Children"] + "\r\n" + "Питание:  " + Request.Params["nutrition"]
                    + "\r\n" + "Ваш номер телефона:  " + model.Phone + "\r\n" + "Страна:" + model.Country + "\r\n" + "e-mail:  " + model.MailAdress + "\r\n" + "Дата заказа:  " + thisday.ToString() + "\r\n" + "Номер заказа:  " + order_number + "\r\n" + "Пожелания:" + model.Comment;


                SmtpClient client = new SmtpClient();
                client.Host = "smtp.mail.ru";
                client.Credentials = new System.Net.NetworkCredential("bestpresentkh@mail.ru", "nata2507");
                client.EnableSsl = true;

                try
                {
                    Task.Factory.StartNew((Action)(() =>
                    {
                        client.Send(message1);
                        client.Send(message2);
                    }), TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
                }


                catch (Exception ex)
                {

                }
                return RedirectToAction("OrderTour");
            }
            else 
            {
                return View(model);
            }
            
        }
        public ActionResult Hotels()
        {
            var context = new TourEntities();
            var data = context.Hotel.ToList();

            int selectedIndex = 1;
            var countries = context.Country.ToList();
            countries.Insert(0, new Country { Id = -1, Name = "Выберите страну" });
            var resort = context.Resort.ToList();
            resort.Insert(0, new Resort { Id = -1, Name = "Курорт" });
            SelectList country = new SelectList(countries, "Id", "Name", selectedIndex);
            ViewBag.Countries = country;
            SelectList resorts = new SelectList(context.Resort.Where(c => c.CountryId == selectedIndex), "Id", "Name");
            ViewBag.Resorts = resorts;
            return View(data);
        }
        public ActionResult GetItems(int id)
        {
            var context = new TourEntities();
            var data = context.Hotel.ToList();
      
            return PartialView(context.Resort.Where(c => c.CountryId == id).ToList());
            
            
        }
      
        public ActionResult Hotel(int? hotelId, int? resortId, int? countrId)
        {
            var context = new TourEntities();
            var data = context.Hotel.ToList();
            if (countrId == -1)
            {
                data = context.Hotel.ToList();
            }
            else
            {
               data = context.Hotel.Where(s => (resortId.HasValue && s.ResortId == resortId.Value) ||
               (countrId.HasValue && s.CountryId == countrId.Value)).ToList();
         
            }
            
            return PartialView("PartialHotels", data);
        }
        [HttpGet]
        public ViewResult HotelDetails(int Id)
        {
            var context = new TourEntities();
            var data = context.Hotel.Find(Id);

            return View(data);
        }
        [HttpPost]
        public ActionResult CountDetails(int Id)
        {
            var context = new TourEntities();
            var data = context.Country.Find(Id);

            return View("PartialCountries", data);
        }

        public ActionResult Countries()
        {
            var context = new TourEntities();
            var data = context.Country.Include(p => p.Resort).ToList();

            return View(data);
        }
       
        public ActionResult OrderTour()
        {
            
            return View();
        }



    }


    public static class MvcHelpers
    {
        public static String RenderViewToString(ControllerContext context, String viewPath, object model = null)
        {
            context.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindView(context, viewPath, null);
                var viewContext = new ViewContext(context, viewResult.View, context.Controller.ViewData, context.Controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(context, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}

