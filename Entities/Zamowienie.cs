﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServis.Entities
{
    public class Zamowienie
    {
        public int Id { get; set; }
        public string NazwaTowaru { get; set; }
        public int Ilosc { get; set; }
        public decimal Cena { get; set; }
    }
}
