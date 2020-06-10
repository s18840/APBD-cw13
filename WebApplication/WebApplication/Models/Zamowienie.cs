using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Zamowienie
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public int IdKlient { get; set; }
        public virtual Klient IdVirtualKlient { get; set; }
        public int IdPracownik { get; set; }
        public virtual Pracownik IdVirtualPracownik { get; set; }
        public ICollection<ZamowienieWyrobCukierniczy> Zamowienie_WyrobyCukiernicze { get; set; }
    }
}
