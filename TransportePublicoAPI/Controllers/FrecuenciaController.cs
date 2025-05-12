using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportePublicoAPI.Data;
using TransportePublicoAPI.Models;

namespace TransportePublicoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FrecuenciaController : ControllerBase
    {
        private readonly TransporteDbContext _context;

        public FrecuenciaController(TransporteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Frecuencia>>> GetFrecuencias()
        {
            return await _context.Frecuencias.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Frecuencia>> PostFrecuencia(Frecuencia frecuencia)
        {
            _context.Frecuencias.Add(frecuencia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostFrecuencia), new { id = frecuencia.Id }, frecuencia);
        }
    }
}
