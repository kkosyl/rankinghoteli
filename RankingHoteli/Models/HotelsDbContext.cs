namespace RankingHoteli.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelsDbContext : DbContext
    {
        public HotelsDbContext()
            : base("name=HotelsDbContext")
        {
        }

        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Opinion> Opinion { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Opinion)
                .WithRequired(e => e.Hotel)
                .HasForeignKey(e => e.HetelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Opinion)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
