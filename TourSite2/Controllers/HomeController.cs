﻿using System;
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
using System.Drawing.Imaging;
using System.Net;
using CaptchaMvc.HtmlHelpers;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using PagedList;

namespace TourSite2.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        TourEntities1 context = new TourEntities1();
        //public ActionResult Airticket()
        //{
        //    var context = new TourEntities1();
        //    var data = context.Airticket.ToList();
        //    return View(data);
        //}

        //public ViewResult EditAirticket(int Id = 1)
        //{
        //    var context = new TourEntities1();
        //    var dat = context.Airticket.FirstOrDefault(p => p.Id == Id);

        //    return View(dat);
        //}


        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditAirticket(Airticket tour)
        //{
        //    var context = new TourEntities1();
        //    if (ModelState.IsValid)
        //    {

        //        SaveTickets(tour);
        //        TempData["message"] = string.Format("{0} has been saved", tour.Name);
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data values
        //        return View(tour);
        //    }
        //}

        //public ActionResult Airtickets()
        //{
        //    var context = new TourEntities1();
        //    var data = context.Airticket.ToList();

        //    return View(data);

        //}
        //public void SaveTickets(Airticket b)
        //{
        //    var context = new TourEntities1();

        //    if (b.Id == 0)
        //    {

        //        context.Airticket.Add(b);
        //    }
        //    else
        //    {

        //        Airticket dbEntry = context.Airticket.Find(b.Id);
        //        if (dbEntry != null)
        //        {


        //            dbEntry.Description = b.Description;

        //            dbEntry.Name = b.Name;


        //        }
        //    }

        //    context.SaveChanges();
        //}





        ////[HttpPost]
        ////[ValidateInput(false)]
        ////public ActionResult EditVisa(Visa tour, HttpPostedFileBase image)
        ////{
        ////    var context = new TourEntities1();
        ////    if (ModelState.IsValid)
        ////    {

        ////        SaveVisa(tour);
        ////        TempData["message"] = string.Format("{0} has been saved", tour.Name);
        ////        return RedirectToAction("Index", "Admin");
        ////    }
        ////    else
        ////    {
        ////        // there is something wrong with the data values
        ////        return View(tour);
        ////    }
        ////}

        ////public ActionResult Visas()
        ////{
        ////    var context = new TourEntities1();
        ////    var data = context.Visa.ToList();

        ////    return View(data);

        ////}
        ////public void SaveVisa(Visa b)
        ////{
        ////    var context = new TourEntities1();

        ////    if (b.Id == 0)
        ////    {

        ////        context.Visa.Add(b);
        ////    }
        ////    else
        ////    {

        ////        Visa dbEntry = context.Visa.Find(b.Id);
        ////        if (dbEntry != null)
        ////        {


        ////            dbEntry.Decription = b.Decription;

        ////            dbEntry.Name = b.Name;


        ////        }
        ////    }

        ////    context.SaveChanges();
        ////}

        //public ActionResult Fishing()
        //{
        //    var context = new TourEntities1();
        //    var data = context.Fishing.ToList();
        //    return View(data);
        //}

        //public ViewResult EditFishing(int Id = 1)
        //{
        //    var context = new TourEntities1();
        //    var dat = context.Fishing.FirstOrDefault(p => p.Id == Id);

        //    return View(dat);
        //}


        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditFishing(Fishing tour, HttpPostedFileBase image)
        //{
        //    var context = new TourEntities1();
        //    if (ModelState.IsValid)
        //    {

        //        SaveFishing(tour);
        //        TempData["message"] = string.Format("{0} has been saved", tour.Name);
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data values
        //        return View(tour);
        //    }
        //}

        //public ActionResult Fishings()
        //{
        //    var context = new TourEntities1();
        //    var data = context.Fishing.ToList();

        //    return View(data);

        //}
        //public void SaveFishing(Fishing b)
        //{
        //    var context = new TourEntities1();

        //    if (b.Id == 0)
        //    {

        //        context.Fishing.Add(b);
        //    }
        //    else
        //    {

        //        Fishing dbEntry = context.Fishing.Find(b.Id);
        //        if (dbEntry != null)
        //        {
        //            dbEntry.Description = b.Description;
        //            dbEntry.Name = b.Name;
        //        }
        //    }

        //    context.SaveChanges();
        //}

        //public ActionResult Studying()
        //{
        //    var context = new TourEntities1();
        //    var data = context.Studying.ToList();
        //    return View(data);
        //}

        //public ViewResult EditStudying(int Id = 1)
        //{
        //    var context = new TourEntities1();
        //    var dat = context.Studying.FirstOrDefault(p => p.Id == Id);

        //    return View(dat);
        //}


        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditStudying(Studying tour)
        //{
        //    var context = new TourEntities1();
        //    if (ModelState.IsValid)
        //    {

        //        SaveStudying(tour);
        //        TempData["message"] = string.Format("{0} has been saved", tour.Name);
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data values
        //        return View(tour);
        //    }
        //}

        //public ActionResult Studyings()
        //{
        //    var context = new TourEntities1();
        //    var data = context.Studying.ToList();

        //    return View(data);

        //}
        //public void SaveStudying(Studying b)
        //{
        //    var context = new TourEntities1();

        //    if (b.Id == 0)
        //    {

        //        context.Studying.Add(b);
        //    }
        //    else
        //    {

        //        Studying dbEntry = context.Studying.Find(b.Id);
        //        if (dbEntry != null)
        //        {


        //            dbEntry.Description = b.Description;

        //            dbEntry.Name = b.Name;


        //        }
        //    }

        //    context.SaveChanges();
        //}

        public ActionResult Placement()
        {
            var context = new TourEntities1();
            var data = context.Placement.ToList();
            return View(data);
        }

        public ViewResult EditPlacement(int Id = 1)
        {
            var context = new TourEntities1();
            var dat = context.Placement.FirstOrDefault(p => p.Id == Id);

            return View(dat);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPlacement(Placement tour, HttpPostedFileBase image)
        {
            var context = new TourEntities1();
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
            var context = new TourEntities1();
            var data = context.Placement.ToList();

            return View(data);

        }
        public void SavePlacement(Placement b)
        {
            var context = new TourEntities1();

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
            var context = new TourEntities1();
            var data = context.HotTours.Find(Id);

            return View("PartialDetails", data);

        }
        [HttpGet]
        public ViewResult CountriesDetails(int Id)
        {
            var data = context.Country.Find(Id);
            return View(data);
        }

        //public ActionResult AllAbout()
        //{
        //    var data = context.About.ToList();
        //    return View(data);
        //}

        //public ViewResult AboutEdit(int Id = 10)
        //{
        //    var context = new TourEntities1();
        //    var dat = context.About.FirstOrDefault(p => p.Id == Id);

        //    return View(dat);
        //}


        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult AboutEdit(About tour, HttpPostedFileBase image)
        //{
        //    var context = new TourEntities1();
        //    if (ModelState.IsValid)
        //    {
        //        SaveAbout(tour);
        //        TempData["message"] = string.Format("{0} has been saved", tour.Name);
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    else
        //    {
        //        return View(tour);
        //    }
        //}

        //public ActionResult ONas()
        //{
        //    var context = new TourEntities1();
        //    var data = context.About.ToList();

        //    return View(data);

        //}
        //public void SaveAbout(About b)
        //{
        //    var context = new TourEntities1();

        //    if (b.Id == 0)
        //    {

        //        context.About.Add(b);
        //    }
        //    else
        //    {

        //        About dbEntry = context.About.Find(b.Id);
        //        if (dbEntry != null)
        //        {


        //            dbEntry.Description = b.Description;

        //            dbEntry.Name = b.Name;


        //        }
        //    }

        //    context.SaveChanges();
        //}
        public ActionResult Index(int? Id)
        {
            var context = new TourEntities1();
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

            var context = new TourEntities1();
            //model.Country = new SelectList(context.Country, "Name", "Name");
        }
        public ActionResult CaptchaImage(string prefix, bool noisy = true)
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            //generate new question 
            int a = rand.Next(10, 99);
            int b = rand.Next(0, 9);
            var captcha = string.Format("{0} + {1} = ?", a, b);

            //store answer 
            Session["Captcha" + prefix] = a + b;

            //image stream 
            FileContentResult img = null;

            using (var mem = new MemoryStream())
            using (var bmp = new Bitmap(130, 30))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));

                //add noise 
                if (noisy)
                {
                    int i, r, x, y;
                    var pen = new Pen(Color.Yellow);
                    for (i = 1; i < 10; i++)
                    {
                        pen.Color = Color.FromArgb(
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)));

                        r = rand.Next(0, (130 / 3));
                        x = rand.Next(0, 130);
                        y = rand.Next(0, 30);

                        gfx.DrawEllipse(pen, x - r, y - r, r, r);
                    }
                }

                //add question 
                gfx.DrawString(captcha, new Font("Tahoma", 15), Brushes.Gray, 2, 3);

                //render as Jpeg 
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                img = this.File(mem.GetBuffer(), "image/Jpeg");
            }

            return img;
        }
        [HttpPost]
        public ActionResult Callback()
        {
            MailAddress from = new MailAddress("info@bestprezent.com.ua");
            MailAddress to = new MailAddress("nata_bar@list.ru");
            //MailAddress toMe = new MailAddress("dand2mj@gmail.com");
            MailMessage message1 = new MailMessage(from, to);
            message1.IsBodyHtml = true;
            message1.Subject = "Перезвонить!";
            message1.Body = "Абонент " + Request.Params["aName"] + "\r\n" + " просит перезвонить по номеру " + Request.Params["aTel"];
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-5.1gb.ua";
            smtp.EnableSsl = false;
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "u77204";
            NetworkCred.Password = "2507nata";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            //smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            try
            {
                Task.Factory.StartNew((Action)(() =>
                {
                    smtp.Send(message1);
                }), TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
            }


            catch (Exception ex)
            {

            }
            return View();

        }
        [HttpPost]
        public ActionResult Order(FormsAuthProvider model)
        {
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            {
                ModelState.AddModelError("Captcha", "Неправильный ответ, поробуйте еще раз");
                //dispay error and generate a new captcha 
                return View(model);
            }
            if (ModelState.IsValid)
            {
                int order_number = 0;
                using (var iter = GetNonRepeatingDigits().GetEnumerator())
                    while (iter.MoveNext() && order_number < 10000)
                        order_number = order_number * 10 + iter.Current;

                model.DepartureDay = Request.Params["departure"];
                model.Food = Request.Params["nutrition"];
                model.HotelCategory = Request.Params["check_cat"];
                model.ReservationNumber = order_number;

                DateTime thisday = DateTime.Now;

                MailAddress from = new MailAddress("info@bestprezent.com.ua");
                MailAddress to = new MailAddress(model.MailAdress);
                MailAddress To = new MailAddress("nata_bar@list.ru"); //nata_bar@list.ru"
                MailMessage message1 = new MailMessage(from, to);
                MailMessage message2 = new MailMessage(from, To);

                message1.IsBodyHtml = true;
                message1.Subject = "Информация о туре!";
                message1.Body = "Здравствуйте," + "\r\n" + "Благодарим Вас за оставленную заявку на подбор тура на сайте Туристического агентства Лучший подарок" + "\r\n" + "Дата заказа:  " + thisday.ToString() + "\r\n" + "Номер заказа:  " + order_number + "\r\n" + "\r\n" + "Вы заказали: " + "\r\n" +
                 "Примерные даты вылета:  " + Request.Params["departure"] + "\r\n" +
                    "Продолжительность тура:  " + model.Duration + "\r\n" + "Категория отеля:  " + Request.Params["check_cat"] + "\r\n" + "Ваше имя:  " + model.Name + "\r\n" + "Детей:  " + Request.Params["Children"] + "\r\n" + "Питание:  " + Request.Params["nutrition"]
                    + "\r\n" + "Ваш номер телефона:  " + model.Phone + "\r\n" + "Страна:" + model.Country + "\r\n" + "Где вы раньше бывали:  "
                    + model.RestPlace + "\r\n" + "Предполагаемый бюджет:  " + model.EstimatedBudget + "\r\n" + "E-mail:  " + model.MailAdress +
                    "\r\n" + "\r\n" + "В ближайшее время наши менеджеры обработают Вашу заявку  и свяжутся с Вами по указанным в заказе контактам. " +
                    "\r\n" + "\r\n" + "\r\n" + "С уважением  и благодарностью сотрудники ТА Лучший подарок" + "\r\n" +
                    "г. Харьков, Полтавский шлях 123, 2 этаж, офис №6" + "\r\n" + "тел. (057) 297-60-97" + "\r\n" + "моб. 066-626-00-76" + "\r\n"
                    + "068-922-70-76";

                message2.Subject = "Новый тур";
                message2.Body = "Новый заказ тура: " + "\r\n" +
                 "Примерные даты вылета:  " + Request.Params["departure"] + "\r\n" +
                    "Продолжительность тура:  " + model.Duration + "\r\n"
                    + "Категория отеля:  " + Request.Params["check_cat"] + "\r\n" + "Имя:  " + model.Name + "\r\n" + "Количевство детей:  " + Request.Params["Children"] + "\r\n" + "Питание:  " + Request.Params["nutrition"]
                    + "\r\n" + "Ваш номер телефона:  " + model.Phone + "\r\n" + "Страна:" + model.Country + "\r\n" +
                    "e-mail:  " + model.MailAdress + "\r\n" + "Дата заказа:  " + thisday.ToString() + "\r\n" + "Номер заказа:  " + order_number + "\r\n"
                    + "Пожелания:" + model.Comment;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-5.1gb.ua";
                smtp.EnableSsl = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "u77204";
                NetworkCred.Password = "2507nata";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;

                try
                {
                    Task.Factory.StartNew((Action)(() =>
                    {
                        //NewReservation(model);
                        smtp.Send(message1);
                        smtp.Send(message2);
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
        //public void NewReservation(FormsAuthProvider model)
        //{
        //    Reservation reservation = new Reservation
        //    {
        //        Children = model.Children,
        //        Period = model.Duration,
        //        Comment = model.Comment,
        //        Country = model.Country,
        //        DepartureDay = model.DepartureDay,
        //        Email = model.MailAdress,
        //        Finance = model.EstimatedBudget,
        //        FirstName = model.Name,
        //        Food = model.Food,
        //        HotelCategory = model.HotelCategory,
        //        PastPlace = model.RestPlace,
        //        Phone = model.Phone,
        //        ReservationNumber = model.ReservationNumber
        //    };

        //    try
        //    {
        //        context.Reservation.Add(reservation);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }

        //    context.SaveChanges();

        //}

        public ActionResult Hotels(int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : string.Empty;
            ViewBag.CountrySortParm = String.IsNullOrEmpty(sortOrder) ? "country_desc" : string.Empty;
            ViewBag.ResortSortParam = String.IsNullOrEmpty(sortOrder) ? "resort" : string.Empty;
            ViewBag.CategorySortParam = String.IsNullOrEmpty(sortOrder) ? "category" : string.Empty;

            var hotels = from s in context.Hotel
                         select s;
            switch (sortOrder)
            {
                case "name_desc":
                    hotels = hotels.OrderBy(s => s.Name);
                    break;
                case "country_desc":
                    hotels = hotels.OrderBy(s => s.Resort.Country.Name);
                    break;
                case "resort":
                    hotels = hotels.OrderBy(s => s.Resort.Name);
                    break;
                case "category":
                    hotels = hotels.OrderByDescending(s => s.Category);
                    break;
                default:
                    hotels = hotels.OrderBy(s => s.Id);
                    break;
            }
            int selectedIndex = 1;
            var countries = context.Country.OrderBy(s => s.Name).ToList();
            countries.Insert(0, new Country { Id = -1, Name = "Выберите страну" });
            var resort = context.Resort.ToList();
            resort.Insert(0, new Resort { Id = -1, Name = "Курорт" });
            SelectList country = new SelectList(countries, "Id", "Name", selectedIndex);
            ViewBag.Countries = country;
            SelectList resorts = new SelectList(context.Resort.Where(c => c.CountryId == selectedIndex), "Id", "Name");
            ViewBag.Resorts = resorts;

            //int pageSize = 40;
            int pageNumber = (page ?? 1);

            return View(hotels.ToList());
        }
        public ActionResult GetItems(int id)
        {
            var context = new TourEntities1();
            var data = context.Hotel.ToList();
            var list = context.Resort.Where(c => c.CountryId == id).OrderBy(s => s.Name).ToList();
            list.Insert(0, new Resort { Id = -1, Name = "Выберите Курорт" });
            var test = list.ToDDLContent(s => s.Id, s => s.Name);
            return Content(test);
        }
        [HttpPost]
        public ActionResult GetCountry(int countryId)
        {
            List<Hotel> data = new List<Hotel>();
            if (countryId != -1 || countryId != 0)
            {
                data = context.Hotel.Where(s => s.Resort.CountryId == countryId).OrderBy(h => h.Name).ToList();
            }
            if (countryId == -1)
            {
                data = context.Hotel.ToList();
            }
            return PartialView("PartialHotels", data);
        }

        public ActionResult Hotel(int? hotelId, int? resortId, int? countrId)
        {
            var context = new TourEntities1();
            var data = context.Hotel.ToList();
            if (resortId == -1 && countrId != -1)
            {
                data = context.Hotel.Where(s => s.Resort.CountryId == countrId).ToList();
            }
            else
            {
                data = context.Hotel.Where(s => (resortId.HasValue && s.ResortId == resortId.Value) ||
                (countrId.HasValue && s.CountryId == countrId.Value)).ToList();
            }

            return PartialView("PartialHotels", data);
        }
        //private void DefaultPopupateHomeModel(ref HotelModel model)
        //{
        //    model = model ?? new HotelModel();
        //    model.PageSize = 40;
        //    model.PagedHotels = new List<Hotel>().ToPagedList(1, model.PageSize);
        //}

        //private void FillHomeModel(HotelModel model)
        //{
        //    //    ViewBag.Zero = "К сожалению, по Вашему запросу ничего не найдено";
        //    var hotels = from s in context.Hotel
        //                 select s;

        //    if (model.ResortId.HasValue)
        //    {
        //        hotels = hotels.Where(s => s.ResortId == model.ResortId.Value);
        //    }
        //    else
        //    {

        //        if (model.CountryId.HasValue)
        //        {
        //            hotels = hotels.Where(s => s.Resort.CountryId == model.CountryId.Value);
        //        }
        //    }

        //    if (!string.IsNullOrWhiteSpace(model.SearchText))
        //    {
        //        hotels = hotels.Where(s => s.Category.Contains(model.SearchText) || s.Comment.Contains(model.SearchText) 
        //            || s.Name.Contains(model.SearchText) || s.Resort.Name.Contains(model.SearchText) || s.Resort.Country.Name.Contains(model.SearchText));
        //    }


        //    switch (model.SortingField)
        //    {
        //        case "name_desc":
        //            hotels = hotels.CustomOrderBy(s => s.Name, model.OrderName);
        //            break;
        //        case "country_desc":
        //            hotels = hotels.CustomOrderBy(s => s.Resort.Country.Name, model.OrderName);
        //            break;
        //        case "resort":
        //            hotels = hotels.CustomOrderBy(s => s.Resort.Name, model.OrderName);
        //            break;
        //        case "category":
        //            hotels = hotels.CustomOrderBy(s => s.Category, model.OrderName);
        //            break;
        //        default:
        //            hotels = hotels.CustomOrderBy(s => s.Id, model.OrderName);
        //            break;
        //    }

        //    var countries = context.Country.ToSelectList(s => s.Id, s => s.Name, IsAllExist: true, IsAllName: "Выберите страну");
        //    //countries.Insert(0, new Country { Id = -1, Name = "Выберите страну" });
        //    model.CountryList = countries; // new SelectList(countries, "Id", "Name", 1);
        //    model.PagedHotels = hotels.ToPagedList(model.CurrentPage, model.PageSize);
        //}

        //public ActionResult Hotels(int page = 1)
        //{

        //    HotelModel model = null;
        //    DefaultPopupateHomeModel(ref model);
        //    model.CurrentPage = page;
        //    try
        //    {
        //        FillHomeModel(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex);
        //    }
        //    return View(model);

        //}

        //[HttpPost]
        //public ActionResult GetItems(int id)
        //{
        //    var context = new TourEntities1();
        //    var resorts = context.Resort.Where(s=>s.CountryId == id).ToDDLContent(s => s.Id, s => s.Name, IsAllExist: true, IsAllName: "Выберите курорт");
        //    return Content(resorts);
        //}

        //public ActionResult Hotel(HotelModel model)
        //{
        //    DefaultPopupateHomeModel(ref model);
        //    try
        //    {
        //        FillHomeModel(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex);
        //    }
        //    return PartialView("PartialHotels", model);
        //}
        [HttpGet]
        public ViewResult HotelDetails(int Id)
        {
            var context = new TourEntities1();
            var data = context.Hotel.Find(Id);

            return View(data);
        }
        [HttpPost]
        public ActionResult CountDetails(int Id)
        {
            var context = new TourEntities1();
            var data = context.Country.Find(Id);

            return View("PartialCountries", data);
        }

        public ActionResult Countries()
        {
            var context = new TourEntities1();
            var data = context.Country.Include(p => p.Resort).ToList();

            return View(data);
        }

        public ActionResult OrderTour()
        {
            return View();
        }
        public ActionResult RandomCountry()
        {
            var random = new Random();
            var countries = context.Country.ToList();
            List<int> countriesLength = new List<int>();
            foreach (var item in countries)
            {
                countriesLength.Add(item.Id);
            }
            
            int index = random.Next(1, countriesLength.Count);
            var name = countriesLength[index];
            var model = context.Country.Find(name);
            return View(model);
        }
        public ActionResult BlogList()
        {
            var model = new BlogModel()
            {
                Authors = context.Author.ToList(),
                Blogs = context.Blog.ToList(),
                Themes = context.Theme.ToList()
            };
            return View(model);
        }
        public ActionResult Discount()
        {
            var data = context.Discount.ToList();
            return View(data);
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

