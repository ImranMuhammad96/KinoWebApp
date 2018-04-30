using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KinoWebApp.Models
{
    public class Film
    {
        [Key]
        public int IDF { get; set; }

        [Required]
        public string TYTUL { get; set; }

        [Required]
        public string REZYSER { get; set; }

        public int DLUGOSC { get; set; }

        [ForeignKey("ID_GAT")]
        public Gatunek Gatunek { get; set; }
        public int? ID_GAT { get; set; }

        [ForeignKey("IDK")]
        public Kategoria Kategoria { get; set; }
        public int? IDK { get; set; }

        public ICollection<Seans> Seanse { get; set; }
    }
}