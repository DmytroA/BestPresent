using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite2.Models;

namespace TourSite2.Controllers
{
    public class CheckController : Controller
    {
        TourEntities1 db = new TourEntities1();
        //
        // GET: /Check/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckReservation()
        {
            CheckReservationModel model = new CheckReservationModel();
            return View(model);
        }
        //[HttpPost]
        //public ActionResult CheckReservation(CheckReservationModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var item in db.Reservation)
        //        {
        //            if (item.ReservationNumber.Value == model.ReservationNumber && item.Email.Contains(model.Email))
        //            {
        //                var reservation = db.Reservation.First(s => s.ReservationNumber == model.ReservationNumber);
        //                return RedirectToAction("Reservation", reservation);
        //            }
        //        }
        //    }
            
        //    return View(model);
        //}
        //public ActionResult Reservation(int Id)
        //{
        //    var data = db.Reservation.Find(Id);
        //    return PartialView("PartialReservation", data);
        //}
        //public ActionResult UpdateReservation(int reservationId)
        //{
        //    var model = db.Reservation.Find(reservationId);
        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult EditReservation(Reservation reservation)
        //{
        //    if (reservation.Id == 0)
        //    {
        //        db.Reservation.Add(reservation);
        //    }
        //    else
        //    {
        //        Reservation dbEntry = db.Reservation.Find(reservation.Id);
        //        if (dbEntry != null)
        //        {
        //            dbEntry.Children = reservation.Children;
        //            dbEntry.Comment = reservation.Comment;
        //            dbEntry.Country = reservation.Country;
        //            dbEntry.DepartureDay = reservation.DepartureDay;
        //            dbEntry.Email = reservation.Email;
        //            dbEntry.Finance = reservation.Finance;
        //            dbEntry.FirstName = reservation.FirstName;
        //            dbEntry.Food = reservation.Food;
        //            dbEntry.HotelCategory = reservation.HotelCategory;
        //            dbEntry.Location = reservation.Location;
        //            dbEntry.PastPlace = reservation.PastPlace;
        //            dbEntry.Period = reservation.Period;
        //            dbEntry.Phone = reservation.Phone;
        //            dbEntry.Price = reservation.Price;
        //            dbEntry.ReservationNumber = reservation.ReservationNumber;
        //            dbEntry.TourType = reservation.TourType;
        //        }
        //    }

        //    db.SaveChanges();

        //    return View(reservation);
        //}
	}
}