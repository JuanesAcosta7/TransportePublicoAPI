using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportePublicoAPI.Data;
using TransportePublicoAPI.Models;

namespace TransportePublicoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutaController : ControllerBase
    {
        private readonly TransporteDbContext _context;

        public RutaController(TransporteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ruta>>> GetRutas()
        {
            return await _context.Rutas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Ruta>> PostRuta(Ruta ruta)
        {
            _context.Rutas.Add(ruta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostRuta), new { id = ruta.Id }, ruta);
        }
    }
}
