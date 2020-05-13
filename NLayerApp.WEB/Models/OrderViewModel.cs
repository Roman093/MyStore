using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class OrderViewModel
    {
        //public int PhoneId { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        [MinLength(2)]
        public string Address { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}