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
    public class OrdenproducciondtlController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public OrdenproducciondtlController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Ordenproducciondtl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordendeproducciondtl>>> GetOrdendeproducciondtl()
        {
            return await _context.Ordendeproducciondtl.ToListAsync();
        }

        // GET: api/Ordenproducciondtl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordendeproducciondtl>> GetOrdendeproducciondtl(int id)
        {
            var ordendeproducciondtl = await _context.Ordendeproducciondtl.FindAsync(id);

            if (ordendeproducciondtl == null)
            {
                return NotFound();
            }

            return ordendeproducciondtl;
        }

        // PUT: api/Ordenproducciondtl/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdendeproducciondtl(int id, Ordendeproducciondtl ordendeproducciondtl)
        {
            if (id != ordendeproducciondtl.Idordendetalle)
            {
                return BadRequest();
            }

            _context.Entry(ordendeproducciondtl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdendeproducciondtlExists(id))
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

        // POST: api/Ordenproducciondtl
        [HttpPost]
        public async Task<ActionResult<Ordendeproducciondtl>> PostOrdendeproducciondtl(Ordendeproducciondtl ordendeproducciondtl)
        {
            _context.Ordendeproducciondtl.Add(ordendeproducciondtl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdendeproducciondtlExists(ordendeproducciondtl.Idordendetalle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrdendeproducciondtl", new { id = ordendeproducciondtl.Idordendetalle }, ordendeproducciondtl);
        }

        // DELETE: api/Ordenproducciondtl/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ordendeproducciondtl>> DeleteOrdendeproducciondtl(int id)
        {
            var ordendeproducciondtl = await _context.Ordendeproducciondtl.FindAsync(id);
            if (ordendeproducciondtl == null)
            {
                return NotFound();
            }

            _context.Ordendeproducciondtl.Remove(ordendeproducciondtl);
            await _context.SaveChangesAsync();

            return ordendeproducciondtl;
        }

        private bool OrdendeproducciondtlExists(int id)
        {
            return _context.Ordendeproducciondtl.Any(e => e.Idordendetalle == id);
        }
    }
}
