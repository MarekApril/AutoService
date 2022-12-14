using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutoServis.Entities
{
    public class AutoServiceDbContext : DbContext
    {
        public AutoServiceDbContext(DbContextOptions<AutoServiceDbContext> options) : base(options)
        {
        }

        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Kontrahent> Kontrahenci { get; set; }
        public DbSet<Mechanik> Mechanicy { get; set; }
        public DbSet<Samochod>  Samochody{ get; set; }
        public DbSet<Zamowienie> Zamowienia{ get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Zamowienie>()
                .Property(p => p.Cena)
                .HasColumnType("decimal(9,2)");
        }
    }
}
