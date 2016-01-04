//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    
    public partial class Hotel
    {
        public Hotel()
        {
            this.HotTours = new HashSet<HotTours>();
        }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string HotelLocation { get; set; }
        public string Comment { get; set; }
        public Nullable<int> ResortId { get; set; }
    
        public virtual Resort Resort { get; set; }
        public virtual ICollection<HotTours> HotTours { get; set; }
    }
}
