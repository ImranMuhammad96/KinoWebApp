using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinoWebApp.Models
{
    public class Gatunek
    {
        [Key]
        public int ID_GAT { get; set; }

        [Required]
        public string NAZWA { get; set; }

        public ICollection<Film> Filmy { get; set; }
    }
}