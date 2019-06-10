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
    public class PlanactividadesController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public PlanactividadesController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Planactividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planactividades>>> GetPlanactividades()
        {
            return await _context.Planactividades.ToListAsync();
        }

        // GET: api/Planactividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planactividades>> GetPlanactividades(int id)
        {
            var planactividades = await _context.Planactividades.FindAsync(id);

            if (planactividades == null)
            {
                return NotFound();
            }

            return planactividades;
        }

        // PUT: api/Planactividades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanactividades(int id, Planactividades planactividades)
        {
            if (id != planactividades.Idplanactividades)
            {
                return BadRequest();
            }

            _context.Entry(planactividades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanactividadesExists(id))
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

        // POST: api/Planactividades
        [HttpPost]
        public async Task<ActionResult<Planactividades>> PostPlanactividades(Planactividades planactividades)
        {
            _context.Planactividades.Add(planactividades);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlanactividadesExists(planactividades.Idplanactividades))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlanactividades", new { id = planactividades.Idplanactividades }, planactividades);
        }

        // DELETE: api/Planactividades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Planactividades>> DeletePlanactividades(int id)
        {
            var planactividades = await _context.Planactividades.FindAsync(id);
            if (planactividades == null)
            {
                return NotFound();
            }

            _context.Planactividades.Remove(planactividades);
            await _context.SaveChangesAsync();

            return planactividades;
        }

        private bool PlanactividadesExists(int id)
        {
            return _context.Planactividades.Any(e => e.Idplanactividades == id);
        }
    }
}
