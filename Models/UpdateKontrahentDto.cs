using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServis.Models
{
    public class UpdateKontrahentDto
    {
        public string KontrahentNazwa { get; set; }
        public string Ulica { get; set; }
        public string Miejscowosc { get; set; }
        public string Poczta { get; set; }
        public string Numer { get; set; }
    }
}
