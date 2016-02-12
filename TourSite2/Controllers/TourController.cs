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
using System.Drawing.Text;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace TourSite2.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/
        TourEntities1 context = new TourEntities1();
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
        public ActionResult DetailOrder(OrderModel model)
        {
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            {
                ModelState.AddModelError("Captcha", "Неправильный ответ, поробуйте еще раз");
                //dispay error and generate a new captcha 
                return View(model);
            }
            int id = Int32.Parse(Request.Params["id"]);
            model.HotTours = context.HotTours.Single(tour => tour.Id == id);

            int order_number = 0;
            using (var iter = GetNonRepeatingDigits().GetEnumerator())
                while (iter.MoveNext() && order_number < 10000)
                    order_number = order_number * 10 + iter.Current;
            model.ReservationNumber = order_number;

            if (ModelState.IsValid)
            {
                DateTime thisday = DateTime.Now;

                MailAddress from = new MailAddress("info@bestprezent.com.ua");
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
                message2.Body = "Новый заказ!" + "\r\n" + "Имя туриста: " + model.Name + "\r\n" + model.MailAdress + "\r\n" +
                    "Телефон:  " + model.Phone + "\r\n" + "Пожелания:" + model.Comment + "\r\n" + "Id тура:" + model.HotTours.Id + "\r\n" + "Курорт:  " + model.HotTours.Hotel.Resort.Name + "\r\n" + "Отель: " + model.HotTours.Hotel.Name + "\r\n" + "Цена: " + model.HotTours.Price;
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
                    SaveReservation(model);
                    Task.Factory.StartNew((Action)(() =>
                    {
                        smtp.Send(message1);
                        smtp.Send(message2);
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
        public void SaveReservation(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    DepartureDay = model.HotTours.DepartureDay,
                    FirstName = model.Name,
                    Food = model.HotTours.Food,
                    HotTourId = model.HotTours.Id,
                    Location = model.HotTours.Location,
                    Period = model.HotTours.Period,
                    Price = model.HotTours.Price,
                    ReservationNumber = model.ReservationNumber,
                    TourType = model.HotTours.TourType,
                    Phone = model.Phone,
                    Email = model.MailAdress
                };

                try
                {
                    context.Reservation.Add(reservation);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                context.SaveChanges();
            }
        }
        public ActionResult DetailOrder(int id, OrderModel model)
        {
            model.HotTours = context.HotTours.Single(tour => tour.Id == id);

            return View(model);
        }
        public ActionResult OrderHotel(int id)
        {
            OrderHotelModel model = new OrderHotelModel();
            model.Hotels = context.Hotel.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult OrderHotel(OrderHotelModel model)
        {
            var context = new TourEntities1();
            int id = Int32.Parse(Request.Params["id"]);
            model.Hotels = context.Hotel.Single(s => s.Id == id);
            //if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            //{
            //    ModelState.AddModelError("Captcha", "Неправильный ответ, поробуйте еще раз");
            //    //dispay error and generate a new captcha 
            //    return View(model);
            //}

            if (ModelState.IsValid)
            {
                DateTime thisday = DateTime.Now;

                int order_number = 0;
                using (var iter = GetNonRepeatingDigits().GetEnumerator())
                    while (iter.MoveNext() && order_number < 10000)
                        order_number = order_number * 10 + iter.Current;

                MailAddress from = new MailAddress("info@bestprezent.com.ua");
                MailAddress to = new MailAddress(model.MailAdress);
                MailAddress To = new MailAddress("nata_bar@list.ru"); //nata_bar@list.ru"
                MailMessage message1 = new MailMessage(from, to);
                MailMessage message2 = new MailMessage(from, To);
                message1.Subject = "Информация о заказе!";
                message1.Body = "Вы заказали отель:" + model.Hotels.Name + "\r\n" + "Описание" + model.Hotels.Description + "\r\n" + "В ближайшее время наши менеджеры обработают Вашу заявку  и свяжутся с Вами по указанным в заказе контактам. " +
                    "\r\n" + "\r\n" + "\r\n" + "С уважением  и благодарностью сотрудники ТА Лучший подарок" + "\r\n" +
                    "г. Харьков, Полтавский шлях 123, 2 этаж, офис №6" + "\r\n" + "тел. (057) 297-60-97" + "\r\n" + "моб. 066-626-00-76" + "\r\n"
                    + "068-922-70-76";
                message1.IsBodyHtml = true;
                message2.Subject = "Заказ отеля!!";
                message2.Body = "Заказ отеля!" + "\r\n" + "Имя туриста: " + model.Name + "\r\n" + model.MailAdress + "\r\n" +
                    "Телефон:  " + model.Phone + "\r\n" + "Пожелания:" + model.Comment + "\r\n" + "Id тура:" + model.Hotels.Id + "\r\n"
                    + "Курорт:  " + model.Hotels.Resort.Name + "\r\n" + "Отель: " + model.Hotels.Name + "\r\n" + model.Hotels.Description;
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
                        smtp.Send(message1);
                        smtp.Send(message2);
                    }), TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
                }

                catch (Exception ex)
                {

                }
                return RedirectToAction("AddToCart");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Hotels(int? Id)
        {
            TourEntities1 db = new TourEntities1();
            var data = db.Hotel.ToList();
            return View(data);
        }
    }
}
