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
            var context = new TourEntities();
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
            var context = new TourEntities();
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
            var context = new TourEntities();
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
            var context = new TourEntities();
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
            var context = new TourEntities();
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
            var context = new TourEntities();
            var data = context.Country.Find(Id);

            context.Entry(data).Collection(d => d.Resort).Load();

            return View(data);
        }

        [HttpPost]
        public ViewResult CountryDetails(Country country)
        {

            return View();
        }

        [HttpGet]
        public ViewResult ResortDetails(int Id)
        {
            var context = new TourEntities();
            var data = context.Resort.Find(Id);
            return View(data);
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            int id = Int32.Parse(Request.Params["id"]);
            var context = new TourEntities();
            var orderedTour = context.HotTours.Single(tour => tour.Id == id);

            DateTime thisday = DateTime.Now;

            int order_number = 0;
            using (var iter = GetNonRepeatingDigits().GetEnumerator())
                while (iter.MoveNext() && order_number < 10000)
                    order_number = order_number * 10 + iter.Current;

            MailAddress from = new MailAddress("bestpresentkh@mail.ru");
            MailAddress to = new MailAddress(Request.Params["mail_adress"]);
            MailAddress To = new MailAddress("nata_bar@list.ru"); //nata_bar@list.ru"
            MailMessage message1 = new MailMessage(from, to);
            MailMessage message2 = new MailMessage(from, To);
            message1.Subject = "Информация о туре!";
            message1.Body = "Здравствуйте," + "\r\n" + "Благодарим Вас за оставленную заявку на подбор тура на сайте Туристического агентства Лучший подарок" +
                "\r\n" + "Дата заказа:  " + thisday.ToString() + "\r\n" + "Номер заказа:  " + order_number + "\r\n" +
                "Курорт:  " + orderedTour.Hotel.Resort.Name + "\r\n" + "Отель: " + orderedTour.Hotel.Name + "\r\n" + "Цена: " + orderedTour.Price +
                "\r\n" + "\r\n" + "В ближайшее время наши менеджеры обработают Вашу заявку  и свяжутся с Вами по указанным в заказе контактам. " + "\r\n" + "\r\n" +
                "\r\n" + "С уважением  и благодарностью сотрудники ТА Лучший подарок" + "\r\n" + "г. Харьков, Полтавский шлях 123, 2 этаж, офис №6" + "\r\n" + "тел. (057) 297-60-97" + "\r\n" + "моб. 066-626-00-76" + "\r\n" + "068-922-70-76";

            message1.IsBodyHtml = true;
            message2.Subject = "Заказ горящего тура!!";
            message2.Body = "Новый заказ!" + "\r\n" + "Имя туриста: " + Request.Params["Name"] + "\r\n" + Request.Params["mail_adress"] + "\r\n" +
                "Телефон:  " + Request.Params["Phone"] + "\r\n" + "Пожелания:" + Request.Params["Comment"] + "\r\n" + "Id тура:" + orderedTour.Id + "\r\n" + "Курорт:  " + orderedTour.Hotel.Resort.Name + "\r\n" + "Отель: " + orderedTour.Hotel.Name + "\r\n" + "Цена: " + orderedTour.Price;
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

            // Go back to the main store page for more shopping
            return View(orderedTour);
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
        public ActionResult DetailsOrder(int id)
        {
            var context = new TourEntities();
            var orderedTour = context.HotTours.Single(tour => tour.Id == id);
            return View(orderedTour);
        }
        public ActionResult DetailOrder(int id)
        {
            var context = new TourEntities();
            var orderedTour = context.HotTours.Single(tour => tour.Id == id);
            return View(orderedTour);
        }
        public ActionResult Hotels(int? Id)
        {
            TourEntities db = new TourEntities();
            var data = db.Hotel.ToList();
            return View(data);
        }
    }
}
