﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServis.Entities
{
    public class Samochod
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Pojemnosc { get; set; }
        public string NumerRejestracyjny { get; set; }
        public string Email { get; set; }
        public string ImieKlienta { get; set; }
        public string NazwiskoKlienta { get; set; }
        public string TelefonKlienta { get; set; }
        public int MechanikId { get; set; }
        public virtual Mechanik Mechanik { get; set; }
    }
}
