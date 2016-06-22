using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using System.Web.Mvc;

namespace TourSite2.Models
{
    public class HotelModel
    {
        public PagedList.IPagedList<Hotel> PagedHotels { get; set; }

        public string SortingField { get; set; }

        public string OrderName { get; set; }

        public int CurrentPage { get; set; }
        
        public int? ResortId { get; set; }

        public int? CountryId { get; set; }

        public int PageSize { get; set; }

        public string SearchText { get; set; }

        public SelectList CountryList { get; set; }

    }
}