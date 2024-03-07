using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bartoepicode.Models
{
    public class Utenti
    {
        [Key]
        public int IdUtente { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "L'email deve essere compresa tra i 3 e 100 caratteri/numeri")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La password deve essere compresa tra i 3 e 255 caratteri/numeri")]
        public string Password {  get; set; }

        [Required]
        [Display(Name = "Sei un'azienda?")]
        public bool Azienda { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Il nome deve avere min. 3 caratteri, max 100 caratteri")]
        public string Nome { get; set; }

        [Display(Name = "Cognome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Il cognome deve avere min. 3 caratteri, max 100 caratteri")]
        public string Cognome { get; set; }

        [Display(Name = "Codice Fiscale")]
        [StringLength(16, ErrorMessage = "Il codice fiscale deve essere una combinazione di 16 caratteri e numeri")]
        public string CodiceFiscale { get; set; }

        [Display(Name = "Partita Iva")]
        [Range(0, 11, ErrorMessage = "Il codice fiscale deve essere una combinazione di 16 caratteri e numeri")]
        public int PartitaIVA { get; set; }

        public bool Admin {  get; set; }
    }
}