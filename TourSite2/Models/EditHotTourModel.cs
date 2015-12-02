using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourSite2.Models
{
    public class EditHotTourModel
    {
        public HotTours HotTour { get; set; }
        public SelectList Hotel { get; set; }

    }
}