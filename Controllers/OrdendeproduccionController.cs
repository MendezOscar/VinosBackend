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
    public class OrdendeproduccionController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public OrdendeproduccionController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Ordendeproduccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordendeproduccion>>> GetOrdendeproduccion()
        {
            return await _context.Ordendeproduccion.ToListAsync();
        }

        // GET: api/Ordendeproduccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordendeproduccion>> GetOrdendeproduccion(int id)
        {
            var ordendeproduccion = await _context.Ordendeproduccion.FindAsync(id);

            if (ordendeproduccion == null)
            {
                return NotFound();
            }

            return ordendeproduccion;
        }

        // PUT: api/Ordendeproduccion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdendeproduccion(int id, Ordendeproduccion ordendeproduccion)
        {
            if (id != ordendeproduccion.Idorden)
            {
                return BadRequest();
            }

            _context.Entry(ordendeproduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdendeproduccionExists(id))
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

        // POST: api/Ordendeproduccion
        [HttpPost]
        public async Task<ActionResult<Ordendeproduccion>> PostOrdendeproduccion(Ordendeproduccion ordendeproduccion)
        {
            _context.Ordendeproduccion.Add(ordendeproduccion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdendeproduccionExists(ordendeproduccion.Idorden))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrdendeproduccion", new { id = ordendeproduccion.Idorden }, ordendeproduccion);
        }

        // DELETE: api/Ordendeproduccion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ordendeproduccion>> DeleteOrdendeproduccion(int id)
        {
            var ordendeproduccion = await _context.Ordendeproduccion.FindAsync(id);
            if (ordendeproduccion == null)
            {
                return NotFound();
            }

            _context.Ordendeproduccion.Remove(ordendeproduccion);
            await _context.SaveChangesAsync();

            return ordendeproduccion;
        }

        private bool OrdendeproduccionExists(int id)
        {
            return _context.Ordendeproduccion.Any(e => e.Idorden == id);
        }
    }
}
