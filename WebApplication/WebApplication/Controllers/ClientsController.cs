using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    //[Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IDbService _context;
        public ClientsController(IDbService context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        [Route("api/clients/{id}/orders")]
        public IActionResult PrzyjmijZamowienie(int id, DTOs.PrzyjecieZamowienia z)
        {
            var cos = _context.PrzyjmijZamowienie(z, id);
            if (cos == "Nie ma takiego wyrobu")
            {
                return BadRequest(cos);
            }
            else
            {
                return Ok(cos);
            }
        }
    }
}