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
    public class FincaController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public FincaController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Finca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Finca>>> GetFinca()
        {
            return await _context.Finca.ToListAsync();
        }

        // GET: api/Finca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Finca>> GetFinca(int id)
        {
            var finca = await _context.Finca.FindAsync(id);

            if (finca == null)
            {
                return NotFound();
            }

            return finca;
        }

        // PUT: api/Finca/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinca(int id, Finca finca)
        {
            if (id != finca.Idfinca)
            {
                return BadRequest();
            }

            _context.Entry(finca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FincaExists(id))
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

        // POST: api/Finca
        [HttpPost]
        public async Task<ActionResult<Finca>> PostFinca(Finca finca)
        {
            _context.Finca.Add(finca);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FincaExists(finca.Idfinca))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFinca", new { id = finca.Idfinca }, finca);
        }

        // DELETE: api/Finca/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Finca>> DeleteFinca(int id)
        {
            var finca = await _context.Finca.FindAsync(id);
            if (finca == null)
            {
                return NotFound();
            }

            _context.Finca.Remove(finca);
            await _context.SaveChangesAsync();

            return finca;
        }

        private bool FincaExists(int id)
        {
            return _context.Finca.Any(e => e.Idfinca == id);
        }
    }
}
