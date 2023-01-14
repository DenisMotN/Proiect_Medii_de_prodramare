using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_prodramare.Models;

namespace Proiect_Medii_de_prodramare.Data
{
    public class Proiect_Medii_de_prodramareContext : DbContext
    {
        public Proiect_Medii_de_prodramareContext (DbContextOptions<Proiect_Medii_de_prodramareContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Medii_de_prodramare.Models.Game> Game { get; set; } = default!;

        public DbSet<Proiect_Medii_de_prodramare.Models.Platform> Platform { get; set; }

        public DbSet<Proiect_Medii_de_prodramare.Models.Category> Category { get; set; }

        public DbSet<Proiect_Medii_de_prodramare.Models.Customer> Customer { get; set; }

        public DbSet<Proiect_Medii_de_prodramare.Models.Shopping> Shopping { get; set; }
    }
}
