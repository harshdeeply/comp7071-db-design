using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hr_webapi.Models;

namespace hr_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayOffController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DayOffController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DayOff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayOff>>> GetDayOff()
        {
          if (_context.DayOff == null)
          {
              return NotFound();
          }
            return await _context.DayOff.ToListAsync();
        }

        // GET: api/DayOff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayOff>> GetDayOff(Guid id)
        {
          if (_context.DayOff == null)
          {
              return NotFound();
          }
            var dayOff = await _context.DayOff.FindAsync(id);

            if (dayOff == null)
            {
                return NotFound();
            }

            return dayOff;
        }

        // PUT: api/DayOff/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayOff(Guid id, DayOff dayOff)
        {
            if (id != dayOff.DayOffId)
            {
                return BadRequest();
            }

            _context.Entry(dayOff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayOffExists(id))
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

        // POST: api/DayOff
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayOff>> PostDayOff(DayOff dayOff)
        {
          if (_context.DayOff == null)
          {
              return Problem("Entity set 'AppDbContext.DayOff'  is null.");
          }
            _context.DayOff.Add(dayOff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayOff", new { id = dayOff.DayOffId }, dayOff);
        }

        // DELETE: api/DayOff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayOff(Guid id)
        {
            if (_context.DayOff == null)
            {
                return NotFound();
            }
            var dayOff = await _context.DayOff.FindAsync(id);
            if (dayOff == null)
            {
                return NotFound();
            }

            _context.DayOff.Remove(dayOff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayOffExists(Guid id)
        {
            return (_context.DayOff?.Any(e => e.DayOffId == id)).GetValueOrDefault();
        }
    }
}
