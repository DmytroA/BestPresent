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
    
    public partial class HotTours
    {
        public HotTours()
        {
            this.Reservation = new HashSet<Reservation>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string Category { get; set; }
        public Nullable<int> AmountPeople { get; set; }
        public string DepartureDay { get; set; }
        public string Food { get; set; }
        public Nullable<int> Period { get; set; }
        public string TourType { get; set; }
        public string Location { get; set; }
        public Nullable<int> HotelId { get; set; }
        public string Name { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
