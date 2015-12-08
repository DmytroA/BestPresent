using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourSite2.Models
{
    public class EditResortModel
    {
        public Resort Resort { get; set; }
        public SelectList Country { get; set; }

    }
}