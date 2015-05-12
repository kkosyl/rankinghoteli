using RankingHoteli.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RankingHoteli.ViewModels
{
    public class HotelDetailsViewModel
    {
        public int HotelId { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        [Display(Name = "Zdjęcie")]
        public IList<string> Picture { get; set; }

        [Display(Name = "Opinie")]
        public IList<KeyValuePair<string, Opinion>> Opinions { get; set; }
    }
}