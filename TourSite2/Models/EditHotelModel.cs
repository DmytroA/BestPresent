using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourSite2.Models
{
    public class EditHotelModel
    {
        public Hotel Hotel { get; set; }
        public SelectList Resort { get; set; }

    }
}