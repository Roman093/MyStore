using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class CartViewModel
    {
        public int ProductId {get; set;}
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}