using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class MySqlDbService : IDbService
        {
            public s18840Context _context { get; set; }
            public MySqlDbService(s18840Context context)
            {
                _context = context;
            }

            public List<Zamowienie> GetOrders(string nazwisko)
            {
                var list = _context.Zamowienia.Where(e => e.Klient.Nazwisko == nazwisko).ToList();
                return list;
            }

            public List<Zamowienie> GetOrders()
            {
                var list = _context.Zamowienia.ToList();
                return list;
            }

            public string PrzyjmijZamowienie(DTOs.PrzyjecieZamowienia z, int idKlienta)
            {
                foreach (Wyrob w in z.wyroby)
                {
                    if (!(_context.WyrobyCukiernicze.Any(wyrob => wyrob.Nazwa == w.wyrob)))
                    {
                        return "Nie ma takiego wyrobu";
                    }
                }
                var zam = new Zamowienie { IdPracownik = 1, DataPrzyjecia = z.dataPrzyjecia, IdKlient = idKlienta, Uwagi = z.Uwagi, Zamowienie_WyrobyCukiernicze = new List<ZamowienieWyrobCukierniczy>() };
                foreach (Wyrob w in z.wyroby)
                {
                    int id = _context.WyrobyCukiernicze.FirstOrDefault(wyrob => wyrob.Nazwa == w.wyrob).IdWyrobuCukierniczego;
                    zam.Zamowienie_WyrobyCukiernicze.Add(new ZamowienieWyrobCukierniczy { IdWyrobuCukierniczego = id, Uwagi = w.uwagi, Ilosc = w.Ilosc });
                }

                _context.Add(zam);
                _context.SaveChanges();

                return "Zamowienie zostalo przyjete";

            }
        }
    }
}
