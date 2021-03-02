using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
   public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {

        }

        public DbSet<Firma> Firmalar {get; set;}
        public DbSet<Calisan> Calisanlar {get; set;}
        public DbSet<Departman> Departmanlar {get; set;}
        public DbSet<CalisanDepartman> CalisanDepartmanlar {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CalisanDepartman>()
                        .HasKey(cd => new {cd.CalisanId,cd.DepartmanId});

            modelBuilder.Entity<Calisan>().Property(c => c.AdSoyad).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Calisan>().Property(c => c.FirmaId).IsRequired();
            modelBuilder.Entity<Firma>().Property(f => f.Ad).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Departman>().Property(d => d.Ad).HasMaxLength(200).IsRequired();

        }
        
    }
}