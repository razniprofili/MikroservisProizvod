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
        public virtual DbSet<JedinicaMere> JedinicaMere { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = TMILOSEVIC-HP; Database = MikroservisProizvodDB; Trusted_Connection = True;"); // dodati konekcioni string u config file u APIju!
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.HasOne(p => p.TipProizvoda).WithMany();
                entity.HasOne(p => p.JedinicaMere).WithMany();
            });

            modelBuilder.Entity<Dobavljac>().HasData(new Dobavljac[]
            {
                new Dobavljac
                {
                    Id = 1,
                    Naziv = "Maxi",
                    PIB = "11223344",
                    Napomena = "Isporuka svakog prvog u mesecu."
                   
                },
                new Dobavljac
                {
                    Id = 2,
                    Naziv = "Dobavljac DOO",
                    PIB = "9874512"

                },
                new Dobavljac
                {
                    Id = 3,
                    Naziv = "Bio Spajz",
                    PIB = "9745123"

                }

            });

            modelBuilder.Entity<TipProizvoda>().HasData(new TipProizvoda[]
            {
                new TipProizvoda
                {
                    Id = 1,
                    Naziv = "Mlecni proizvod"

                },
                new TipProizvoda
                {
                    Id = 2,
                    Naziv = "Slatkis"

                },
                new TipProizvoda
                {
                    Id = 3,
                    Naziv = "Delikates"

                },
                 new TipProizvoda
                {
                    Id = 4,
                    Naziv = "Pice"

                },

            });

            modelBuilder.Entity<JedinicaMere>().HasData(new JedinicaMere[]
            {
                new JedinicaMere
                {
                    Id = 1,
                    Naziv = "Komad"

                },
                new JedinicaMere{ Id = 2,Naziv = "Kilogram"},
                new JedinicaMere
                {
                    Id = 3,
                    Naziv = "Litar"

                },
                 new JedinicaMere
                {
                     Id = 4,
                    Naziv = "Gram"

                }

            });

        }
    }
}
