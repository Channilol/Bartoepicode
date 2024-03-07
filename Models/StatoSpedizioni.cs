using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bartoepicode.Models
{
    public class StatoSpedizioni
    {
        public int IdStato { get; set; }

        public int IdSpedizione { get; set; }

        public string StatoConsegna { get; set; }

        public string Luogo { get; set; }

        public string Descrizione { get; set; }

        public string DataAggiornamento { get; set; }
    }
}