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
    public class EmploymentEventController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmploymentEventController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EmploymentEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentEvent>>> GetEmploymentEvent()
        {
          if (_context.EmploymentEvent == null)
          {
              return NotFound();
          }
            return await _context.EmploymentEvent.ToListAsync();
        }

        // GET: api/EmploymentEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentEvent>> GetEmploymentEvent(Guid id)
        {
          if (_context.EmploymentEvent == null)
          {
              return NotFound();
          }
            var employmentEvent = await _context.EmploymentEvent.FindAsync(id);

            if (employmentEvent == null)
            {
                return NotFound();
            }

            return employmentEvent;
        }

        // PUT: api/EmploymentEvent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploymentEvent(Guid id, EmploymentEvent employmentEvent)
        {
            if (id != employmentEvent.EmploymentEventId)
            {
                return BadRequest();
            }

            _context.Entry(employmentEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentEventExists(id))
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

        // POST: api/EmploymentEvent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmploymentEvent>> PostEmploymentEvent(EmploymentEvent employmentEvent)
        {
          if (_context.EmploymentEvent == null)
          {
              return Problem("Entity set 'AppDbContext.EmploymentEvent'  is null.");
          }
            _context.EmploymentEvent.Add(employmentEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploymentEvent", new { id = employmentEvent.EmploymentEventId }, employmentEvent);
        }

        // DELETE: api/EmploymentEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploymentEvent(Guid id)
        {
            if (_context.EmploymentEvent == null)
            {
                return NotFound();
            }
            var employmentEvent = await _context.EmploymentEvent.FindAsync(id);
            if (employmentEvent == null)
            {
                return NotFound();
            }

            _context.EmploymentEvent.Remove(employmentEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploymentEventExists(Guid id)
        {
            return (_context.EmploymentEvent?.Any(e => e.EmploymentEventId == id)).GetValueOrDefault();
        }
    }
}
