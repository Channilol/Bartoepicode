using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bartoepicode.Models
{
    public class Spedizioni
    {
        [Key]
        public int IdSpedizione { get; set; }

        [Required]
        [Range(1, 2147483647, ErrorMessage = "L'id utente deve essere superiore a 0")]
        public int IdUtente { get; set; }

        [Required]
        public string DataSpedizione { get; set; }

        [Required]
        [Range(1, 2147483647, ErrorMessage = "Il peso deve essere superiore a 0")]
        public int Peso { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La città deve avere min. 3 caratteri, max 100 caratteri")]
        public string Citta { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Il cognome deve avere min. 3 caratteri, max 100 caratteri")]
        public string Indirizzo { get; set; }

        [Required]
        public string NomeDestinatario { get; set; }

        public string CognomeDestinatario { get; set; }

        [Required]
        public decimal CostoSpedizione { get; set; }

        [Required]
        public string DataConsegnaPrevista { get; set; }
    }
}