using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Data.Entity;
using System.Drawing;
using System.IO;
//using System.Web.Http;

namespace TourSite2.Models
{
    [Authorize]
    public class AdminController : Controller
    {
        TourEntities1 db = new TourEntities1();
        public HotTours DeleteTour(int Id)
        {
            var context = new TourEntities1();
            HotTours dbEntry = context.HotTours.Find(Id);
            if (dbEntry != null)
            {
                context.HotTours.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Country DeleteCountry(int Id)
        {
            var context = new TourEntities1();
            Country dbEntry = context.Country.Find(Id);
            if (dbEntry != null)
            {
                context.Country.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Resort DeleteResort(int Id)
        {
            var context = new TourEntities1();
            Resort dbEntry = context.Resort.Find(Id);
            if (dbEntry != null)
            {
                context.Resort.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Hotel DeleteHotel(int Id)
        {
            var context = new TourEntities1();
            Hotel dbEntry = context.Hotel.Find(Id);
            if (dbEntry != null)
            {
                context.Hotel.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Feed DeleteFeedback(int Id)
        {
            var context = new TourEntities1();
            Feed dbEntry = context.Feed.Find(Id);
            if (dbEntry != null)
            {
                context.Feed.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public News DeleteNew(int Id)
        {
            News dbEntry = db.News.Find(Id);
            if (dbEntry != null)
            {
                db.News.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
        public ViewResult Index()
        {
           
            return View();
        }
        public ActionResult CountryList()
        {
            TourEntities1 db = new TourEntities1();
            var data = db.Country.ToList();
            return View(data);
        }
        public ActionResult NewsList()
        {
            var data = db.News.ToList();
            return View(data);
        }
        public ActionResult FeedbackList()
        {
            TourEntities1 db = new TourEntities1();
            var data = db.Feed.ToList();
            return View(data);
        }
        public ActionResult HotelList()
        {
            TourEntities1 db = new TourEntities1();
            var data = db.Hotel.ToList();
            return View(data);
        }
        public ActionResult ResortList()
        {
            TourEntities1 db = new TourEntities1();
            var data = db.Resort.ToList();
            return View(data);
        }
        public ActionResult HotTourList()
        {
            TourEntities1 db = new TourEntities1();
            var data = db.HotTours.ToList(); ;
            return View(data);
        }
        public ViewResult Edit(int Id)
        {
            EditHotTourModel model = null;
            FillModelEditHotTour(ref model, Id);
            return View(model);
            //var context = new TourSite2Entities();
            //var dat = context.HotTours.FirstOrDefault(p => p.Id == Id);
            //return View(dat);
        }
        private void FillModelEditHotTour(ref EditHotTourModel model, int Id)
        {
            model = model ?? new EditHotTourModel();

            var context = new TourEntities1();
            model.HotTour = context.HotTours.FirstOrDefault(p => p.Id == Id);
            model.Hotel = new SelectList(context.Hotel, "Id", "Name");
        }
        public ViewResult EditCountry(int Id)
        {

            var context = new TourEntities1();
            var data = context.Country.FirstOrDefault(p => p.Id == Id);
            return View(data);
        }

        public ViewResult EditHotel(int Id)
        {
            EditHotelModel model = null;
            FillModelEditHotel(ref model, Id);
           
            return View(model);
        }
        private void FillModelEditHotel(ref EditHotelModel model, int Id)
        {
            model = model ?? new EditHotelModel();

            var context = new TourEntities1();
            model.Hotel = context.Hotel.FirstOrDefault(p => p.Id == Id);
            model.Resort = new SelectList(context.Resort, "Id", "Name");
        }
        public ViewResult EditResort(int Id)
        {
            EditResortModel model = null;
            FillModelEditResort(ref model, Id);
            //context.Entry(data).Collection(m => m.Country).Load();
           
            //ViewBag.list = new SelectList(context.Country,"Id","Name");
            return View(model);
        }

        private void FillModelEditResort(ref EditResortModel model, int Id)
        {
            model = model?? new EditResortModel();

            var context = new TourEntities1();
            model.Resort = context.Resort.FirstOrDefault(p => p.Id == Id);
            model.Country = new SelectList(context.Country, "Id", "Name");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditResort(EditResortModel model, HttpPostedFileBase image)
        {
            
            var context = new TourEntities1();

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    model.Resort.ImageMimeType = image.ContentType;
                    model.Resort.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(model.Resort.ImageData, 0, image.ContentLength);
                }
                SaveResort(model.Resort);
                TempData["message"] = string.Format("{0} has been saved", model.Resort.Name);
                return RedirectToAction("Index");
            }
            else
            {
                FillModelEditResort(ref model, model.Resort.Id);
                return View(model);
            }
        }

       
        public ViewResult CreateHotel()
        {
            var context = new TourEntities1();
            EditHotelModel model = new EditHotelModel()
            {
                Hotel = new Hotel(),
                Resort = new SelectList(context.Resort,"Id","Name")
            };
            return View("EditHotel", model);
        }
        public ViewResult CreateCountry()
        {
            return View("EditCountry", new Country());
        }
        public ViewResult CreateResort()
        {
            var context = new TourEntities1();
            EditResortModel model = new EditResortModel() { 
               Resort = new Resort(),
               Country = new SelectList(context.Country, "Id", "Name")
            };
            return View("EditResort", model);
        }
        public ViewResult CreateNews()
        {
            News model = new News();
            return View("EditNews", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public void SaveCountry(Country b)
        {
            var context = new TourEntities1();

            if (b.Id == 0)
            {

                context.Country.Add(b);
            }
            else
            {

                Country dbEntry = context.Country.Find(b.Id);
                if (dbEntry != null)
                {
                    
                    dbEntry.Name = b.Name;
                    dbEntry.Description = b.Description;
                    dbEntry.ImageData = b.ImageData ?? dbEntry.ImageData;
                    dbEntry.ImageMimeType = b.ImageMimeType;

                }
            }

            context.SaveChanges();
        }
        [HttpPost]
        [ValidateInput(false)]
        public void SaveHotel(Hotel b)
        {
            var context = new TourEntities1();

            if (b.Id == 0)
            {

                context.Hotel.Add(b);
            }
            else
            {

                Hotel dbEntry = context.Hotel.Find(b.Id);
                if (dbEntry != null)
                {

                    dbEntry.Name = b.Name;
                    dbEntry.Description = b.Description;
                    dbEntry.ImageData = b.ImageData ?? dbEntry.ImageData;
                    dbEntry.ImageMimeType = b.ImageMimeType;
                    dbEntry.Category = b.Category;
                    dbEntry.CountryId = b.CountryId;
                    dbEntry.ResortId = b.ResortId;
                }
            }

            context.SaveChanges();
        }
        [HttpPost]
        [ValidateInput(false)]
        public void SaveResort(Resort b)
        {
            var context = new TourEntities1();

            if (b.Id == 0)
            {

                context.Resort.Add(b);
            }
            else
            {

                Resort dbEntry = context.Resort.Find(b.Id);
                if (dbEntry != null)
                {

                    dbEntry.Name = b.Name;
                    dbEntry.Description = b.Description;
                    dbEntry.CountryId = b.CountryId;
                    dbEntry.ImageData = b.ImageData ?? dbEntry.ImageData;
                    dbEntry.ImageMimeType = b.ImageMimeType;

                }
            }

            context.SaveChanges();
        }
        [HttpPost]
        [ValidateInput(false)]
        public void SaveNews(News b)
        {
            var context = new TourEntities1();
            if (b.Id == 0)
            {
                b.Date = DateTime.Now;
                context.News.Add(b);
            }
            else
            {
                News dbEntry = context.News.Find(b.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = b.Name;
                    dbEntry.Description = b.Description;
                    dbEntry.Date = DateTime.Now;
                }
            }

            context.SaveChanges();
        }
       
        public ViewResult Create()
        {
            var context = new TourEntities1();
            EditHotTourModel model = new EditHotTourModel()
            {
                HotTour = new HotTours(),
                Hotel = new SelectList(context.Hotel, "Id", "Name")
            };
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Delete(int TourId = 1)
        {
            HotTours deletedTour = DeleteTour(TourId);
            if (deletedTour != null)
            {
                TempData["message"] = string.Format("{0} удален", deletedTour.Name);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteCountries(int CountryId = 1)
        {

            Country deletedCountry = DeleteCountry(CountryId);
            if (deletedCountry != null)
            {
                TempData["message"] = string.Format("{0} удален", deletedCountry.Name);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteHotels(int HotelId = 1)
        {

            Hotel deletedHotel = DeleteHotel(HotelId);
            if (deletedHotel != null)
            {
                TempData["message"] = string.Format("{0} удален", deletedHotel.Name);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteNews(int NewsId = 1)
        {
            News deletedNews = DeleteNew(NewsId);
            if (deletedNews != null)
            {
                TempData["message"] = string.Format("{0} удален", deletedNews.Name);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteResorts(int ResortId = 1)
        {

            Resort deletedResort = DeleteResort(ResortId);
            if (deletedResort != null)
            {
                TempData["message"] = string.Format("{0} удален", deletedResort.Name);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        public void SaveHotTour(HotTours b)
        {
            var context = new TourEntities1();
          
            if (b.Id == 0)
            {
              
                context.HotTours.Add(b);
            }
            else
            {
                
                HotTours dbEntry = context.HotTours.Find(b.Id);
                if (dbEntry != null)
                {
                    dbEntry.Description = b.Description;
                    dbEntry.Price = b.Price;
                    dbEntry.Category = b.Category;
                    dbEntry.ImageData = b.ImageData ?? dbEntry.ImageData;
                    dbEntry.ImageMimeType = b.ImageMimeType;
                    dbEntry.AmountPeople = b.AmountPeople;
                    dbEntry.DepartureDay = b.DepartureDay;
                    dbEntry.Food = b.Food;
                    dbEntry.Period = b.Period;
                    dbEntry.TourType = b.TourType;
                    dbEntry.Location = b.Location;
                    dbEntry.HotelId = b.HotelId;                   
                }
            }
            
            context.SaveChanges();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditHotTourModel model, HttpPostedFileBase image)
        {

            var context = new TourEntities1();

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    model.HotTour.ImageMimeType = image.ContentType;
                    model.HotTour.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(model.HotTour.ImageData, 0, image.ContentLength);
                }
                SaveHotTour(model.HotTour);
                TempData["message"] = string.Format("{0} has been saved", model.HotTour.Name);
                return RedirectToAction("Index");
            }
            else
            {
                FillModelEditHotTour(ref model, model.HotTour.Id);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditCountry(Country country, HttpPostedFileBase image)
        {
            var context = new TourEntities1();

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    country.ImageMimeType = image.ContentType;
                    country.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(country.ImageData, 0, image.ContentLength);
                }
                SaveCountry(country);
                TempData["message"] = string.Format("{0} has been saved", country.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(country);
            }
        }
        public ViewResult EditNews(int Id = 1)
        {
            var data = db.News.FirstOrDefault(p => p.Id == Id);
            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditNews(News news)
        {
            var context = new TourEntities1();

            if (ModelState.IsValid)
            {
                SaveNews(news);
                TempData["message"] = string.Format("{0} has been saved", news.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(news);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditHotel(EditHotelModel model, HttpPostedFileBase image)
        {

            var context = new TourEntities1();

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    model.Hotel.ImageMimeType = image.ContentType;
                    model.Hotel.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(model.Hotel.ImageData, 0, image.ContentLength);
                }
                SaveHotel(model.Hotel);
                TempData["message"] = string.Format("{0} has been saved", model.Hotel.Name);
                return RedirectToAction("Index");
            }
            else
            {
                FillModelEditHotel(ref model, model.Hotel.Id);
                return View(model);
            }
        }
        //public ActionResult AddImage()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult CreateImage()
        {
            var photo = new Photo();
            return View(photo);
        }
        public Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                else
                    tempval = newSize.Width / (imageSize.Width * 1.0);

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
                finalSize = imageSize; // image is already small size

            return finalSize;
        }
        private void SaveToFolder(Image img, string fileName, string extension, Size newSize, string pathToSave)
        {
            Size imgSize = NewImageSize(img.Size, newSize);
            System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height);

            newImg.Save(Server.MapPath(pathToSave), img.RawFormat);

        }
        [HttpPost]
        public ActionResult CreateImage(Photo photo, IEnumerable<HttpPostedFileBase> files)
        {
            var context = new TourEntities1();
            if (!ModelState.IsValid)
                return View(photo);
            if (files.Count() == 0 || files.FirstOrDefault() == null)
            {
                ViewBag.error = "Please choose a file";
                return View(photo);
            }


            foreach (var file in files)
            {
                if (file.ContentLength == 0) continue;
                var model = new Photo();
                model.Decription = photo.Decription;
                var fileName = Guid.NewGuid().ToString();
                var extension = System.IO.Path.GetExtension(file.FileName).ToLower();

                MemoryStream ms = new MemoryStream();
                file.InputStream.CopyTo(ms);
                file.InputStream.Dispose();
                ms.Seek(0, SeekOrigin.Begin);
                //var img = System.Drawing.Image.FromStream(ms);
                //img.Save("./asd123.png");

                using (var img1 = System.Drawing.Image.FromStream(ms))
                {
                    model.ThumbPath = String.Format("/ImageGallery/thumbs/{0}{1}", fileName, extension);
                    model.ImagePath = String.Format("/ImageGallery/{0}{1}", fileName, extension);
                    // Save thumbnail size image, 100 x 100
                    SaveToFolder(img1, fileName, extension, new Size(100, 100), model.ThumbPath);

                    // Save large size image, 800 x 800
                    SaveToFolder(img1, fileName, extension, new Size(600, 600), model.ImagePath);
                }

                // Save record to database
                model.CreatedOn = DateTime.Now;
                context.Photo.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}