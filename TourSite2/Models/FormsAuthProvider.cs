using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TourSite2.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace TourSite2.Models
{
    public class FormsAuthProvider: IAuthProvider
    {
        [Required(ErrorMessage = "Ваше имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите номер")]
        public string Phone { get; set; }
        public string DepartureDay { get; set; }

        public string HotelCategory { get; set; }
        public string Food { get; set; }
        public string EstimatedBudget { get; set; }
        //[Required(ErrorMessage = "Введите преположительный день отлета")]
        //public string DepartureDay { get; set; }
        [Required(ErrorMessage = "Введите продолжительномть")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Введите страну")]
        public string Country { get; set; }
        public string RestPlace { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string MailAdress { get; set; }
        [Required(ErrorMessage = "Введите количевство людей")]
        public int Children { get; set; }

        public string Comment { get; set; }
        [Required]
        [Display(Name = "Введите сумму на картинке")] 
        public string Captcha { get; set; }

        public int ReservationNumber { get; set; }
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }

    }
  
}
