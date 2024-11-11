using Microsoft.EntityFrameworkCore;

namespace Celestial.API.Domain.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Star> Stars { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Star>(x =>
            {
                x.ToTable("Stars");

                x.HasKey(s => s.Id);

                x.OwnsOne(s => s.Position, position =>
                {
                    position.Property(p => p.RightAscension).HasColumnName("RightAscension");
                    position.Property(p => p.Declination).HasColumnName("Declination");
                    position.Property(p => p.Distance).HasColumnName("Distance");
                });

                x.Property(s => s.Name).IsRequired().HasMaxLength(255);
                x.Property(s => s.Magnitude).HasPrecision(18, 2);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
