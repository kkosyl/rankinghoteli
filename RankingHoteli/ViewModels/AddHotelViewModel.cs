using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RankingHoteli.ViewModels
{
    public class AddHotelViewModel
    {
        public AddHotelViewModel()
        {
            Picture = new List<HttpPostedFileBase>();
        }

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
        public IEnumerable<HttpPostedFileBase> Picture { get; set; }
    }
}