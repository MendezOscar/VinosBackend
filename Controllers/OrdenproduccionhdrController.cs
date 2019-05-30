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
    public class OrdenproduccionhdrController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public OrdenproduccionhdrController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Ordenproduccionhdr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordendeproduccionhdr>>> GetOrdendeproduccionhdr()
        {
            return await _context.Ordendeproduccionhdr.ToListAsync();
        }

        // GET: api/Ordenproduccionhdr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordendeproduccionhdr>> GetOrdendeproduccionhdr(int id)
        {
            var ordendeproduccionhdr = await _context.Ordendeproduccionhdr.FindAsync(id);

            if (ordendeproduccionhdr == null)
            {
                return NotFound();
            }

            return ordendeproduccionhdr;
        }

        // PUT: api/Ordenproduccionhdr/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdendeproduccionhdr(int id, Ordendeproduccionhdr ordendeproduccionhdr)
        {
            if (id != ordendeproduccionhdr.Idorden)
            {
                return BadRequest();
            }

            _context.Entry(ordendeproduccionhdr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdendeproduccionhdrExists(id))
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

        // POST: api/Ordenproduccionhdr
        [HttpPost]
        public async Task<ActionResult<Ordendeproduccionhdr>> PostOrdendeproduccionhdr(Ordendeproduccionhdr ordendeproduccionhdr)
        {
            _context.Ordendeproduccionhdr.Add(ordendeproduccionhdr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdendeproduccionhdrExists(ordendeproduccionhdr.Idorden))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrdendeproduccionhdr", new { id = ordendeproduccionhdr.Idorden }, ordendeproduccionhdr);
        }

        // DELETE: api/Ordenproduccionhdr/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ordendeproduccionhdr>> DeleteOrdendeproduccionhdr(int id)
        {
            var ordendeproduccionhdr = await _context.Ordendeproduccionhdr.FindAsync(id);
            if (ordendeproduccionhdr == null)
            {
                return NotFound();
            }

            _context.Ordendeproduccionhdr.Remove(ordendeproduccionhdr);
            await _context.SaveChangesAsync();

            return ordendeproduccionhdr;
        }

        private bool OrdendeproduccionhdrExists(int id)
        {
            return _context.Ordendeproduccionhdr.Any(e => e.Idorden == id);
        }
    }
}
