using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ZamowienieWyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public int IdZamowienia { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }
        public virtual WyrobCukierniczy IdVirtualWyrobCukierniczy { get; set; }
        public virtual Zamowienie IdVirtualZamowienie { get; set; }
    }
}
