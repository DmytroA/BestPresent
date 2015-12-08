using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourSite2.Models
{
    public class SubModel
    {
        [Required(ErrorMessage = "Введите ваше имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ваш номер")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Введите вашу почта")]
        [EmailAddress(ErrorMessage = "Почта неправильная")]
        public string Email { get; set; }
    }
}