﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace van_rental.Models
{
    public partial class getInfosOneModelAndPriceResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picture_url { get; set; }
        public int? gas_tank { get; set; }
        public int? pax { get; set; }
        public int? price_per_day { get; set; }
        public decimal? rentalPrice { get; set; }
    }
}