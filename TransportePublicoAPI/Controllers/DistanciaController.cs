using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportePublicoAPI.Data;
using TransportePublicoAPI.Models;

namespace TransportePublicoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistanciaController : ControllerBase
    {
        private readonly TransporteDbContext _context;

        public DistanciaController(TransporteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distancia>>> GetDistancias()
        {
            return await _context.Distancias.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Distancia>> PostDistancia(Distancia distancia)
        {
            _context.Distancias.Add(distancia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostDistancia), new { id = distancia.Id }, distancia);
        }
    }
}
