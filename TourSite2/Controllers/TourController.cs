using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite2.Models;
using DataLayer;
using System.Net.Mail;
using System.IO;
using System.Data.Entity;
using System.Threading.Tasks;


namespace TourSite2.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/
        public FileContentResult GetImage(int Id)
        {
            var context = new TourEntities1();
            HotTours tours = context.HotTours.FirstOrDefault(p => p.Id == Id);
            if (tours != null)
            {
                return File(tours.ImageData, tours.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public FileContentResult GetImageCountry(int Id)
        {
            var context = new TourEntities1();
            Country count = context.Country.FirstOrDefault(p => p.Id == Id);
            if (count != null)
            {
                return File(count.ImageData, count.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public FileContentResult GetImageHotel(int Id)
        {
            var context = new TourEntities1();
            Hotel hotel = context.Hotel.FirstOrDefault(p => p.Id == Id);
            if (hotel != null)
            {
                return File(hotel.ImageData, hotel.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public FileContentResult GetImageResort(int Id)
        {
            var context = new TourEntities1();
            Resort resort = context.Resort.FirstOrDefault(p => p.Id == Id);
            if (resort != null)
            {
                return File(resort.ImageData, resort.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Details(int Id)
        {
            var context = new TourEntities1();
            var data = context.HotTours.Find(Id);

            return View(data);
        }
        [HttpPost]
        public ViewResult Details(HotTours hot_tour)
        {
            return View("Thanks", hot_tour);
        }

        [HttpGet]
        public ViewResult CountryDetails(int Id)
        {
            var context = new TourEntities1();
            var data = context.Country.Find(Id);

            context.Entry(data).Collection(d => d.Resort).Load();

            return View(data);
        }

       

        [HttpGet]
        public ViewResult ResortDetails(int Id)
        {
            var context = new TourEntities1();
            var data = context.Resort.Find(Id);
            return View(data);
        }


        public ActionResult AddToCart()
        {
            return View();
        }

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
        //public ActionResult DetailsOrder(int id)
        //{
        //    var context = new TourEntities();
        //    var orderedTour = context.HotTours.Single(tour => tour.Id == id);
        //    return View(orderedTour);
        //}
        [HttpPost]
        public ActionResult DetailOrder(OrderModel model)
        {
            var context = new TourEntities1();
            int id = Int32.Parse(Request.Params["id"]);
            model.HotTours = context.HotTours.Single(tour => tour.Id == id);
            
            if (ModelState.IsValid)
            {
                DateTime thisday = DateTime.Now;

                int order_number = 0;
                using (var iter = GetNonRepeatingDigits().GetEnumerator())
                    while (iter.MoveNext() && order_number < 10000)
                        order_number = order_number * 10 + iter.Current;

                MailAddress from = new MailAddress("bestpresentkh@mail.ru");
                MailAddress to = new MailAddress(model.MailAdress);
                MailAddress To = new MailAddress("nata_bar@list.ru"); //nata_bar@list.ru"
                MailMessage message1 = new MailMessage(from, to);
                MailMessage message2 = new MailMessage(from, To);
                message1.Subject = "Информация о туре!";
                message1.Body = "Здравствуйте," + "\r\n" + "Благодарим Вас за оставленную заявку на подбор тура на сайте Туристического агентства Лучший подарок" +
                    "\r\n" + "Дата заказа:  " + thisday.ToString() + "\r\n" + "Номер заказа:  " + order_number + "\r\n" +
                    "Курорт:  " + model.HotTours.Hotel.Resort.Name + "\r\n" + "Отель: " + model.HotTours.Hotel.Name + "\r\n" + "Цена: " + model.HotTours.Price +
                    "\r\n" + "\r\n" + "В ближайшее время наши менеджеры обработают Вашу заявку  и свяжутся с Вами по указанным в заказе контактам. " + "\r\n" + "\r\n" +
                    "\r\n" + "С уважением  и благодарностью сотрудники ТА Лучший подарок" + "\r\n" + "г. Харьков, Полтавский шлях 123, 2 этаж, офис №6" + "\r\n" + "тел. (057) 297-60-97" + "\r\n" + "моб. 066-626-00-76" + "\r\n" + "068-922-70-76";

                message1.IsBodyHtml = true;
                message2.Subject = "Заказ горящего тура!!";
                message2.Body = "Новый заказ!" + "\r\n" + "Имя туриста: " + model.Name+ "\r\n" + model.MailAdress + "\r\n" +
                    "Телефон:  " + model.Phone + "\r\n" + "Пожелания:" + model.Comment + "\r\n" + "Id тура:" + model.HotTours.Id + "\r\n" + "Курорт:  " + model.HotTours.Hotel.Resort.Name + "\r\n" + "Отель: " + model.HotTours.Hotel.Name + "\r\n" + "Цена: " + model.HotTours.Price;
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
                return RedirectToAction("AddToCart");
            }
            else
            {
                // Go back to the main store page for more shopping
                return View(model);
            }
        }
        public ActionResult DetailOrder(int id,OrderModel model)
        {
            var context = new TourEntities1();
            model.HotTours = context.HotTours.Single(tour => tour.Id == id);
            //var context = new TourEntities();
            //var orderedTour = context.HotTours.
            return View(model);
        }
        public ActionResult Hotels(int? Id)
        {
            TourEntities1 db = new TourEntities1();
            var data = db.Hotel.ToList();
            return View(data);
        }
    }
}
