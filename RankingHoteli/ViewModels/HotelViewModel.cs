﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RankingHoteli.ViewModels
{
    public class HotelListViewModel
    {
        [Display(Name="Nazwa")]
        public string Name { get; set; }

        [Display(Name="Adres")]
        public string Address { get; set; }

        [Display(Name="Opis")]
        public string Description { get; set; }

        [Display(Name="Cena")]
        public decimal? Price { get; set; }

        [Display(Name="Zdjęcia")]
        public string Picture { get; set; }
    }

    public class AddHotelViewModel
    {
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        [Required]
        [Display(Name = "Zdjęcie")]
        public HttpPostedFileBase Picture { get; set; }
    }
}