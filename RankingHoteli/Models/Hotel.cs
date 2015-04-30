namespace RankingHoteli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    public partial class Hotel
    {
        public Hotel()
        {
            Opinion = new HashSet<Opinion>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelID { get; set; }

        public int? PictureID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(500)]
        public string Descritpion { get; set; }

        public decimal? Price { get; set; }

        public virtual Picture Picture { get; set; }

        public virtual ICollection<Opinion> Opinion { get; set; }
    }
}
