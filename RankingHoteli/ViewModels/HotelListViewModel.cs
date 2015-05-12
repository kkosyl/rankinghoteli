using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RankingHoteli.Models;

namespace RankingHoteli.ViewModels
{
    public class HotelListViewModel
    {
        public int HotelId { get; set; }

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
    
}