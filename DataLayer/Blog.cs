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
    
    public partial class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.MultilineText)]
       
        public string Text { get; set; }
        public System.DateTime Date { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public Nullable<int> ThemeId { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
