using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public interface IDbService
    {
        List<Zamowienie> GetOrders(string nazwisko);
        List<Zamowienie> GetOrders();
        string PrzyjmijZamowienie(DTOs.PrzyjecieZamowienia z, int idKlienta);

    }
}
