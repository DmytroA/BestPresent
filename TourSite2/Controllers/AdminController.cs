
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Data.Entity;
//using System.Web.Http;

namespace TourSite2.Models
{
    [Authorize]
    public class AdminController : Controller
    {    
        public HotTours DeleteTour(int Id)
        {
            var context = new TourEntities();
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
            var context = new TourEntities();
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
            var context = new TourEntities();
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
            var context = new TourEntities();
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
            var context = new TourEntities();
            Feed dbEntry = context.Feed.Find(Id);
            if (dbEntry != null)
            {
                context.Feed.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public ViewResult Index()
        {
           
            return View();
        }
        public ActionResult CountryList()
        {
            TourEntities db = new TourEntities();
            var data = db.Country.ToList();
            return View(data);
        }
        public ActionResult FeedbackList()
        {
            TourEntities db = new TourEntities();
            var data = db.Feed.ToList();
            return View(data);
        }
        public ActionResult HotelList()
        {
            TourEntities db = new TourEntities();
            var data = db.Hotel.ToList();
            return View(data);
        }
        public ActionResult ResortList()
        {
            TourEntities db = new TourEntities();
            var data = db.Resort.ToList();
            return View(data);
        }
        public ActionResult HotTourList()
        {
            TourEntities db = new TourEntities();
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

            var context = new TourEntities();
            model.HotTour = context.HotTours.FirstOrDefault(p => p.Id == Id);
            model.Hotel = new SelectList(context.Hotel, "Id", "Name");
        }
        public ViewResult EditCountry(int Id)
        {

            var context = new TourEntities();
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

            var context = new TourEntities();
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

            var context = new TourEntities();
            model.Resort = context.Resort.FirstOrDefault(p => p.Id == Id);
            model.Country = new SelectList(context.Country, "Id", "Name");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditResort(EditResortModel model, HttpPostedFileBase image)
        {
            
            var context = new TourEntities();

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
            var context = new TourEntities();
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
            var context = new TourEntities();
            EditResortModel model = new EditResortModel() { 
               Resort = new Resort(),
               Country = new SelectList(context.Country, "Id", "Name")
            };
            return View("EditResort", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public void SaveCountry(Country b)
        {
            var context = new TourEntities();

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
            var context = new TourEntities();

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
            var context = new TourEntities();

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
       
       
        public ViewResult Create()
        {
            var context = new TourEntities();
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
            var context = new TourEntities();
          
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

            var context = new TourEntities();

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
            var context = new TourEntities();

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
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditHotel(EditHotelModel model, HttpPostedFileBase image)
        {

            var context = new TourEntities();

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
       
       
    }
}