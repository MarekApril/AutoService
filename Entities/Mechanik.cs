using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServis.Entities
{
    public class Mechanik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int AdresId{ get; set; }
        public virtual Adres Adres { get; set; }
    }
}
