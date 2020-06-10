using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IDbService _context;
        public OrdersController(IDbService context)
        {
            _context = context;
        }
        [HttpGet("{nazwisko}")]
        public IActionResult GetOrders(string nazwisko)
        {
            var list = _context.GetOrders(nazwisko);
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            var list = _context.GetOrders();
            return Ok(list);
        }
    }
}