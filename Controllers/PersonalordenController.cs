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
    public class PersonalordenController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public PersonalordenController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Personalorden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personalorden>>> GetPersonalorden()
        {
            return await _context.Personalorden.ToListAsync();
        }

        // GET: api/Personalorden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personalorden>> GetPersonalorden(int id)
        {
            var personalorden = await _context.Personalorden.FindAsync(id);

            if (personalorden == null)
            {
                return NotFound();
            }

            return personalorden;
        }

        // PUT: api/Personalorden/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalorden(int id, Personalorden personalorden)
        {
            if (id != personalorden.Idpersonal)
            {
                return BadRequest();
            }

            _context.Entry(personalorden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalordenExists(id))
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

        // POST: api/Personalorden
        [HttpPost]
        public async Task<ActionResult<Personalorden>> PostPersonalorden(Personalorden personalorden)
        {
            _context.Personalorden.Add(personalorden);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonalordenExists(personalorden.Idpersonal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonalorden", new { id = personalorden.Idpersonal }, personalorden);
        }

        // DELETE: api/Personalorden/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personalorden>> DeletePersonalorden(int id)
        {
            var personalorden = await _context.Personalorden.FindAsync(id);
            if (personalorden == null)
            {
                return NotFound();
            }

            _context.Personalorden.Remove(personalorden);
            await _context.SaveChangesAsync();

            return personalorden;
        }

        private bool PersonalordenExists(int id)
        {
            return _context.Personalorden.Any(e => e.Idpersonal == id);
        }
    }
}
