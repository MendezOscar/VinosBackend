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
    public class VisitahdrController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public VisitahdrController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Visitahdr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitahdr>>> GetVisitahdr()
        {
            return await _context.Visitahdr.ToListAsync();
        }

        // GET: api/Visitahdr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitahdr>> GetVisitahdr(int id)
        {
            var visitahdr = await _context.Visitahdr.FindAsync(id);

            if (visitahdr == null)
            {
                return NotFound();
            }

            return visitahdr;
        }

        // PUT: api/Visitahdr/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitahdr(int id, Visitahdr visitahdr)
        {
            if (id != visitahdr.Idvisita)
            {
                return BadRequest();
            }

            _context.Entry(visitahdr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitahdrExists(id))
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

        // POST: api/Visitahdr
        [HttpPost]
        public async Task<ActionResult<Visitahdr>> PostVisitahdr(Visitahdr visitahdr)
        {
            _context.Visitahdr.Add(visitahdr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VisitahdrExists(visitahdr.Idvisita))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVisitahdr", new { id = visitahdr.Idvisita }, visitahdr);
        }

        // DELETE: api/Visitahdr/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Visitahdr>> DeleteVisitahdr(int id)
        {
            var visitahdr = await _context.Visitahdr.FindAsync(id);
            if (visitahdr == null)
            {
                return NotFound();
            }

            _context.Visitahdr.Remove(visitahdr);
            await _context.SaveChangesAsync();

            return visitahdr;
        }

        private bool VisitahdrExists(int id)
        {
            return _context.Visitahdr.Any(e => e.Idvisita == id);
        }
    }
}
