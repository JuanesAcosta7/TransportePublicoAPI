using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportePublicoAPI.Data;
using TransportePublicoAPI.Models;

namespace TransportePublicoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiempoController : ControllerBase
    {
        private readonly TransporteDbContext _context;

        public TiempoController(TransporteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiempo>>> GetTiempos()
        {
            return await _context.Tiempos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Tiempo>> PostTiempo(Tiempo tiempo)
        {
            _context.Tiempos.Add(tiempo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostTiempo), new { id = tiempo.Id }, tiempo);
        }
    }
}
    