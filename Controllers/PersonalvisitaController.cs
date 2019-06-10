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
    public class PersonalvisitaController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public PersonalvisitaController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Personalvisita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personalvisita>>> GetPersonalvisita()
        {
            return await _context.Personalvisita.ToListAsync();
        }

        // GET: api/Personalvisita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personalvisita>> GetPersonalvisita(int id)
        {
            var personalvisita = await _context.Personalvisita.FindAsync(id);

            if (personalvisita == null)
            {
                return NotFound();
            }

            return personalvisita;
        }

        // PUT: api/Personalvisita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalvisita(int id, Personalvisita personalvisita)
        {
            if (id != personalvisita.Idpersonalvisita)
            {
                return BadRequest();
            }

            _context.Entry(personalvisita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalvisitaExists(id))
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

        // POST: api/Personalvisita
        [HttpPost]
        public async Task<ActionResult<Personalvisita>> PostPersonalvisita(Personalvisita personalvisita)
        {
            _context.Personalvisita.Add(personalvisita);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonalvisitaExists(personalvisita.Idpersonalvisita))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonalvisita", new { id = personalvisita.Idpersonalvisita }, personalvisita);
        }

        // DELETE: api/Personalvisita/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personalvisita>> DeletePersonalvisita(int id)
        {
            var personalvisita = await _context.Personalvisita.FindAsync(id);
            if (personalvisita == null)
            {
                return NotFound();
            }

            _context.Personalvisita.Remove(personalvisita);
            await _context.SaveChangesAsync();

            return personalvisita;
        }

        private bool PersonalvisitaExists(int id)
        {
            return _context.Personalvisita.Any(e => e.Idpersonalvisita == id);
        }
    }
}
