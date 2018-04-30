using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KinoWebApp.Models
{
    public class Seans
    {
        [Key]
        public int IDS { get; set; }

        [Required]
        [ForeignKey("IDF")]
        public Film Film { get; set; }
        public int IDF { get; set; }

        [Required]
        [ForeignKey("NR_SALI")]
        public Sala Sala { get; set; }
        public int NR_SALI { get; set; }

        [Required]
        public DateTime TERMIN { get; set; }
    }
}