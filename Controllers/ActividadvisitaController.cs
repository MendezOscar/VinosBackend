using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinosBackend.Models;

namespace VinosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadvisitaController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public ActividadvisitaController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Actividadvisita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividadvisita>>> GetActividadvisita()
        {
            return await _context.Actividadvisita.ToListAsync();
        }

        // GET: api/Actividadvisita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividadvisita>> GetActividadvisita(int id)
        {
            var actividadvisita = await _context.Actividadvisita.FindAsync(id);

            if (actividadvisita == null)
            {
                return NotFound();
            }

            return actividadvisita;
        }

        // PUT: api/Actividadvisita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividadvisita(int id, Actividadvisita actividadvisita)
        {
            if (id != actividadvisita.Actividadvisita1)
            {
                return BadRequest();
            }

            _context.Entry(actividadvisita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadvisitaExists(id))
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

        // POST: api/Actividadvisita
        [HttpPost]
        public async Task<ActionResult<Actividadvisita>> PostActividadvisita(Actividadvisita actividadvisita)
        {
            _context.Actividadvisita.Add(actividadvisita);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActividadvisitaExists(actividadvisita.Actividadvisita1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActividadvisita", new { id = actividadvisita.Actividadvisita1 }, actividadvisita);
        }

        // DELETE: api/Actividadvisita/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actividadvisita>> DeleteActividadvisita(int id)
        {
            var actividadvisita = await _context.Actividadvisita.FindAsync(id);
            if (actividadvisita == null)
            {
                return NotFound();
            }

            _context.Actividadvisita.Remove(actividadvisita);
            await _context.SaveChangesAsync();

            return actividadvisita;
        }

        private bool ActividadvisitaExists(int id)
        {
            return _context.Actividadvisita.Any(e => e.Actividadvisita1 == id);
        }
    }
}
