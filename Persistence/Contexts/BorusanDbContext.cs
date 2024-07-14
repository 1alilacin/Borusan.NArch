using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BorusanDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BOTO27161\\SQLEXPRESS; Database=BorusanDB; Trusted_Connection=True;Encrypt=false");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>().ToTable("Cars").HasKey(c => c.Id);
            //modelBuilder.Entity<Car>()
            //    .HasOne(c => c.Model)
            //    .WithMany(b => b.)
            //    .HasForeignKey(c => c.BrandId);
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Brand>().HasKey(c => c.Id);
            //modelBuilder.Entity<Model>().HasKey(c => c.Id);
            //modelBuilder.Entity<Fuel>().HasKey(c => c.Id);
            //modelBuilder.Entity<Color>().HasKey(c => c.Id);
            //modelBuilder.Entity<Transmission>().HasKey(c => c.Id);
        }
    }
}
