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
    public class MateriaprimaController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public MateriaprimaController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Materiaprima
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materiaprima>>> GetMateriaprima()
        {
            return await _context.Materiaprima.ToListAsync();
        }

        // GET: api/Materiaprima/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materiaprima>> GetMateriaprima(int id)
        {
            var materiaprima = await _context.Materiaprima.FindAsync(id);

            if (materiaprima == null)
            {
                return NotFound();
            }

            return materiaprima;
        }

        // PUT: api/Materiaprima/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateriaprima(int id, Materiaprima materiaprima)
        {
            if (id != materiaprima.Idmateriaprima)
            {
                return BadRequest();
            }

            _context.Entry(materiaprima).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaprimaExists(id))
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

        // POST: api/Materiaprima
        [HttpPost]
        public async Task<ActionResult<Materiaprima>> PostMateriaprima(Materiaprima materiaprima)
        {
            _context.Materiaprima.Add(materiaprima);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MateriaprimaExists(materiaprima.Idmateriaprima))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMateriaprima", new { id = materiaprima.Idmateriaprima }, materiaprima);
        }

        // DELETE: api/Materiaprima/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Materiaprima>> DeleteMateriaprima(int id)
        {
            var materiaprima = await _context.Materiaprima.FindAsync(id);
            if (materiaprima == null)
            {
                return NotFound();
            }

            _context.Materiaprima.Remove(materiaprima);
            await _context.SaveChangesAsync();

            return materiaprima;
        }

        private bool MateriaprimaExists(int id)
        {
            return _context.Materiaprima.Any(e => e.Idmateriaprima == id);
        }
    }
}
