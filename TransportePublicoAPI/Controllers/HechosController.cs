using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportePublicoAPI.Data;
using TransportePublicoAPI.Models;

namespace TransportePublicoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HechosController : ControllerBase
    {
        private readonly TransporteDbContext _context;

        public HechosController(TransporteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HechosRuta>>> GetHechos()
        {
            return await _context.HechosRutas
                .Include(h => h.Ruta)
                .Include(h => h.Frecuencia)
                .Include(h => h.Tiempo)
                .Include(h => h.Distancia)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HechosRuta>> GetHecho(int id)
        {
            var hecho = await _context.HechosRutas
                .Include(h => h.Ruta)
                .Include(h => h.Frecuencia)
                .Include(h => h.Tiempo)
                .Include(h => h.Distancia)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (hecho == null)
                return NotFound();

            return hecho;
        }
        [HttpPost]
        public async Task<IActionResult> CrearHecho([FromBody] CrearHechoDTO dto)
        {


            var hecho = new HechosRuta
            {
                RutaId = dto.RutaId,
                TiempoId = dto.TiempoId,
                FrecuenciaId = dto.FrecuenciaId,
                DistanciaId = dto.DistanciaId,
                TiempoDestinoMinutosLunesASab = dto.TiempoDestinoMinutosLunesASab,
                TiempoTotalMinutosLunesASab = dto.TiempoTotalMinutosLunesASab,
                TiempoDestinoMinutosDomYFestivos = dto.TiempoDestinoMinutosDomYFestivos,
                TiempoTotalMinutosDomYFestivos = dto.TiempoTotalMinutosDomYFestivos
            };

            _context.HechosRutas.Add(hecho);
            await _context.SaveChangesAsync();

            return Ok(hecho);
        }
    }
}