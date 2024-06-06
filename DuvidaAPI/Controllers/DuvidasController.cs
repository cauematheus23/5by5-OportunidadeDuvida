using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DuvidaAPI.Data;
using Models;

namespace DuvidaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuvidasController : ControllerBase
    {
        private readonly DuvidaAPIContext _context;

        public DuvidasController(DuvidaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Duvidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duvidas>>> GetDuvidas()
        {
          if (_context.Duvidas == null)
          {
              return NotFound();
          }
            return await _context.Duvidas.ToListAsync();
        }

        // GET: api/Duvidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Duvidas>> GetDuvidas(int id)
        {
          if (_context.Duvidas == null)
          {
              return NotFound();
          }
            var duvidas = await _context.Duvidas.FindAsync(id);

            if (duvidas == null)
            {
                return NotFound();
            }

            return duvidas;
        }

        // PUT: api/Duvidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuvidas(int id, Duvidas duvidas)
        {
            if (id != duvidas.Id)
            {
                return BadRequest();
            }

            _context.Entry(duvidas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuvidasExists(id))
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

        // POST: api/Duvidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Duvidas>> PostDuvidas(Duvidas duvidas)
        {
          if (_context.Duvidas == null)
          {
              return Problem("Entity set 'DuvidaAPIContext.Duvidas'  is null.");
          }
            _context.Duvidas.Add(duvidas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDuvidas", new { id = duvidas.Id }, duvidas);
        }

        // DELETE: api/Duvidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuvidas(int id)
        {
            if (_context.Duvidas == null)
            {
                return NotFound();
            }
            var duvidas = await _context.Duvidas.FindAsync(id);
            if (duvidas == null)
            {
                return NotFound();
            }

            _context.Duvidas.Remove(duvidas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DuvidasExists(int id)
        {
            return (_context.Duvidas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
