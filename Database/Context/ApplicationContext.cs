using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Serie> Serie { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Productora> Productora { get; set; }

  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //PK

            modelBuilder.Entity<Serie>().HasKey(x => x.Id);
            modelBuilder.Entity<Genero>().HasKey(x => x.Id);
            modelBuilder.Entity<Productora>().HasKey(x => x.Id);
      

            //Relationships

            modelBuilder.Entity<Genero>()
                .HasMany<Serie>(g => g.Series)
                .WithOne(s => s.Genero)
                .HasForeignKey(s => s.GeneroId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Productora>()
                .HasMany<Serie>(p => p.SerieList)
                .WithOne(s => s.Productora)
                .HasForeignKey(s => s.ProductoraId)
                .OnDelete(DeleteBehavior.Cascade);

            //Preferences

            modelBuilder.Entity<Genero>()
                .Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();
            modelBuilder.Entity<Serie>()
                .Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();
            modelBuilder.Entity<Productora>()
                .Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();
        }
    }
}
