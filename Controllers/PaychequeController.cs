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
    public class PaychequeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaychequeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Paycheque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paycheque>>> GetPaycheque()
        {
          if (_context.Paycheque == null)
          {
              return NotFound();
          }
            return await _context.Paycheque.ToListAsync();
        }

        // GET: api/Paycheque/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paycheque>> GetPaycheque(Guid id)
        {
          if (_context.Paycheque == null)
          {
              return NotFound();
          }
            var paycheque = await _context.Paycheque.FindAsync(id);

            if (paycheque == null)
            {
                return NotFound();
            }

            return paycheque;
        }

        // PUT: api/Paycheque/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaycheque(Guid id, Paycheque paycheque)
        {
            if (id != paycheque.PaychequeId)
            {
                return BadRequest();
            }

            _context.Entry(paycheque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaychequeExists(id))
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

        // POST: api/Paycheque
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paycheque>> PostPaycheque(Paycheque paycheque)
        {
          if (_context.Paycheque == null)
          {
              return Problem("Entity set 'AppDbContext.Paycheque'  is null.");
          }
            _context.Paycheque.Add(paycheque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaycheque", new { id = paycheque.PaychequeId }, paycheque);
        }

        // DELETE: api/Paycheque/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaycheque(Guid id)
        {
            if (_context.Paycheque == null)
            {
                return NotFound();
            }
            var paycheque = await _context.Paycheque.FindAsync(id);
            if (paycheque == null)
            {
                return NotFound();
            }

            _context.Paycheque.Remove(paycheque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaychequeExists(Guid id)
        {
            return (_context.Paycheque?.Any(e => e.PaychequeId == id)).GetValueOrDefault();
        }
    }
}
