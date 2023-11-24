using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LuisJose_AP1_P2_Real.Server.DAL;
using LuisJose_AP1_P2_Real.Shared;

namespace LuisJose_AP1_P2_Real.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobrosController : ControllerBase
    {
        private readonly Context _context;

        public CobrosController(Context context)
        {
            _context = context;
        }

        // GET: api/Cobros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cobros>>> GetCobros()
        {
            if (_context.Cobros == null)
            {
                return NotFound();
            }
            return await _context.Cobros.ToListAsync();
        }

        // GET: api/Cobros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cobros>> GetCobros(int id)
        {
            if (_context.Cobros == null)
            {
                return NotFound();
            }
            var cobros = await _context.Cobros
                .Include(e => e.CobrosDetalle)
                .Where(e => e.CobroId == id)
                .FirstOrDefaultAsync();

            if (cobros == null)
            {
                return NotFound();
            }

            return cobros;
        }

        // PUT: api/Cobros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCobros(int id, Cobros cobros)
        {
            if (id != cobros.CobroId)
            {
                return BadRequest();
            }

            _context.Entry(cobros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CobrosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cobros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cobros>> PostCobros(Cobros cobros)
        {
            if (!CobrosExists(cobros.CobroId))
                _context.Cobros.Add(cobros);
            else
                _context.Cobros.Update(cobros);

            await _context.SaveChangesAsync();

            return Ok(cobros);
        }

        // DELETE: api/Cobros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobros(int id)
        {
            if (_context.Cobros == null)
            {
                return NotFound();
            }
            var cobros = await _context.Cobros.FindAsync(id);
            if (cobros == null)
            {
                return NotFound();
            }

            _context.Cobros.Remove(cobros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CobrosExists(int id)
        {
            return (_context.Cobros?.Any(e => e.CobroId == id)).GetValueOrDefault();
        }

        [HttpDelete("DeleteDetalles/{id}")]
        public async Task<IActionResult> DeleteDetalles(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var cobros = await _context.CobrosDetalles.FirstOrDefaultAsync(td => td.DetalleId == id);
            if (cobros is null)
            {
                return NotFound();
            }
            _context.CobrosDetalles.Remove(cobros);
            await _context.SaveChangesAsync();

            return Ok();
        }
        private bool CobroExists(int id)
        {
            return (_context.Cobros?.Any(e => e.CobroId == id)).GetValueOrDefault();
        }
    } 
}
