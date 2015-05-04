namespace RankingHoteli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Picture")]
    public partial class Picture
    {
        public int PictureID { get; set; }

        public int HotelID { get; set; }

        [Required]
        [StringLength(50)]
        public string Source { get; set; }
    }
}
