using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SerialNumberAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerialNumberController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SerialNumberController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("generate/{product}")]
        public async Task<IActionResult> GenerateSerialNumber([FromRoute] string product)
        {
            if (string.IsNullOrEmpty(product)) {
                return BadRequest("Wymagany prefix");
            }
            var newSerial = new SerialNumber
            {
                Name = product,
                Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12) 
            };

            _context.SerialNumbers.Add(newSerial);
            await _context.SaveChangesAsync();

            return Ok(newSerial);
        }
        [HttpGet]
        public IActionResult GetAllSerialNumbers()
        {
            var serials = _context.SerialNumbers.ToList();
            return Ok(serials);
        }

        [HttpGet("{id}")]
        public IActionResult GetSerialById(int id)
        {
            var serial = _context.SerialNumbers.Find(id);
            if (serial == null)
                return NotFound();

            return Ok(serial);
        }
    }
}