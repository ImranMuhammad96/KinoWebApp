using KinoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KinoWebApp.Persistence
{
    public class KinoWebAppDbContext : DbContext
    {
        public DbSet<Gatunek> Gatunki { get; set; }

        public DbSet<Kategoria> Kategorie { get; set; }

        public DbSet<Sala> Sale { get; set; }

        public DbSet<Film> Filmy { get; set; }

        public DbSet<Miejsce> Miejsca { get; set; }

        public DbSet<Seans> Seanse { get; set; }
    }
}