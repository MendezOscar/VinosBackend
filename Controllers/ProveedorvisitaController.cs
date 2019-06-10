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
    public class ProveedorvisitaController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public ProveedorvisitaController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Proveedorvisita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedorvisita>>> GetProveedorvisita()
        {
            return await _context.Proveedorvisita.ToListAsync();
        }

        // GET: api/Proveedorvisita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedorvisita>> GetProveedorvisita(int id)
        {
            var proveedorvisita = await _context.Proveedorvisita.FindAsync(id);

            if (proveedorvisita == null)
            {
                return NotFound();
            }

            return proveedorvisita;
        }

        // PUT: api/Proveedorvisita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedorvisita(int id, Proveedorvisita proveedorvisita)
        {
            if (id != proveedorvisita.Idproveedorvisita)
            {
                return BadRequest();
            }

            _context.Entry(proveedorvisita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorvisitaExists(id))
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

        // POST: api/Proveedorvisita
        [HttpPost]
        public async Task<ActionResult<Proveedorvisita>> PostProveedorvisita(Proveedorvisita proveedorvisita)
        {
            _context.Proveedorvisita.Add(proveedorvisita);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProveedorvisitaExists(proveedorvisita.Idproveedorvisita))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProveedorvisita", new { id = proveedorvisita.Idproveedorvisita }, proveedorvisita);
        }

        // DELETE: api/Proveedorvisita/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proveedorvisita>> DeleteProveedorvisita(int id)
        {
            var proveedorvisita = await _context.Proveedorvisita.FindAsync(id);
            if (proveedorvisita == null)
            {
                return NotFound();
            }

            _context.Proveedorvisita.Remove(proveedorvisita);
            await _context.SaveChangesAsync();

            return proveedorvisita;
        }

        private bool ProveedorvisitaExists(int id)
        {
            return _context.Proveedorvisita.Any(e => e.Idproveedorvisita == id);
        }
    }
}
