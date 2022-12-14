using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServis.Entities
{
    public class Kontrahent
    {
        public int Id { get; set; }
        public string KontrahentNazwa { get; set; }
        public int AdresId { get; set; }
        public virtual Adres Adres { get; set; }
    }
}
