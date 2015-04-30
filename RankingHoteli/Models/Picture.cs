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
        public Picture()
        {
            Hotel = new HashSet<Hotel>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PictureID { get; set; }

        [Required]
        [StringLength(50)]
        public string Source { get; set; }

        public virtual ICollection<Hotel> Hotel { get; set; }
    }
}
