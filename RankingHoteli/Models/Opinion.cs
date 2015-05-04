namespace RankingHoteli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Opinion")]
    public partial class Opinion
    {
        public int OpinionID { get; set; }

        public int UserID { get; set; }

        public int HetelID { get; set; }

        [Required]
        public string Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime AddDate { get; set; }

        public int LocationGrade { get; set; }

        public int FoodGrade { get; set; }

        public int ServiceGrade { get; set; }

        public int RoomGrade { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual User User { get; set; }
    }
}
