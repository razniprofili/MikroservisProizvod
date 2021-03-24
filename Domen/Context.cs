using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Context : DbContext
    {
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<Dobavljac> Dobavljac { get; set; }
        public virtual DbSet<TipProizvoda> TipProizvoda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = TMILOSEVIC-HP; Database = MikroservisProizvodDB; Trusted_Connection = True;"); // dodati konekcioni string u config file u APIju!
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proizvod>().HasOne(p => p.TipProizvoda).WithMany();

        }
    }
}
