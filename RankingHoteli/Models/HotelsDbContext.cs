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

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Opinion> Opinions { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Opinions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
