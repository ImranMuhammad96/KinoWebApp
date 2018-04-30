using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KinoWebApp.Models
{
    public class Miejsce
    {
        [Key]
        public int IDM { get; set; }

        [Required]
        [ForeignKey("NR_SALI")]
        public Sala Sala { get; set; }
        public int? NR_SALI { get; set; }

        [Required]
        public int NR_MIEJSCA { get; set; }

        [Required]
        public decimal CENA { get; set; }
    }
}