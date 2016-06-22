using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using System.ComponentModel.DataAnnotations;
namespace TourSite2.Models
{
    public class OrderHotelModel
    {
        public Hotel Hotels { get; set; }

        [Required(ErrorMessage = "Введите ваше имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите телефон")]
        public string Phone { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string MailAdress { get; set; }
        public string Comment { get; set; }
        //[Required]
        //[Display(Name = "Введите сумму на картинке")]
        //public string Captcha { get; set; }
    }
}