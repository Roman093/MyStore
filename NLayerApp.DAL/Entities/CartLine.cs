﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NLayerApp.DAL.Entities
{
    public class CartLine
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }
    }
}