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
        public class FormsAuthProvider
        {
            [Required(ErrorMessage = "Please enter a product name")]
            [Display(Name = "Название")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Please enter a phone")]
            public string Phone { get; set; }
            public string EstimatedBudget { get; set; }
            [Required(ErrorMessage = "Введите преположительный день отлета")]
            public string DepartureDay { get; set; }
            [Required(ErrorMessage = "Введите продолжительномть")]
            public string Duration { get; set; }

            public SelectList Country { get; set; }
            public string RestPlace { get; set; }
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string MailAdress { get; set; }
            [Required(ErrorMessage = "Введите количевство людей")]
            public int Children { get; set; }
            public string selectedCountry { get; set; }
        }
 }
