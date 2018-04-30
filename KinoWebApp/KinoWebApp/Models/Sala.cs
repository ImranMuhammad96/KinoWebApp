using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinoWebApp.Models
{
    public class Sala
    {
        [Key]
        public int NR_SALI { get; set; }

        [Required]
        public int ILE_MIEJSC { get; set; }

        public ICollection<Miejsce> Miejsca { get; set; }
        public ICollection<Seans> Seanse { get; set; }
    }
}