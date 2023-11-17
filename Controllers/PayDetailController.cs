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
    public class PayDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PayDetailController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PayDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayDetail>>> GetPayDetail()
        {
          if (_context.PayDetail == null)
          {
              return NotFound();
          }
            return await _context.PayDetail.ToListAsync();
        }

        // GET: api/PayDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayDetail>> GetPayDetail(Guid id)
        {
          if (_context.PayDetail == null)
          {
              return NotFound();
          }
            var payDetail = await _context.PayDetail.FindAsync(id);

            if (payDetail == null)
            {
                return NotFound();
            }

            return payDetail;
        }

        // PUT: api/PayDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayDetail(Guid id, PayDetail payDetail)
        {
            if (id != payDetail.PayDetailId)
            {
                return BadRequest();
            }

            _context.Entry(payDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayDetailExists(id))
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

        // POST: api/PayDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PayDetail>> PostPayDetail(PayDetail payDetail)
        {
          if (_context.PayDetail == null)
          {
              return Problem("Entity set 'AppDbContext.PayDetail'  is null.");
          }
            _context.PayDetail.Add(payDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayDetail", new { id = payDetail.PayDetailId }, payDetail);
        }

        // DELETE: api/PayDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayDetail(Guid id)
        {
            if (_context.PayDetail == null)
            {
                return NotFound();
            }
            var payDetail = await _context.PayDetail.FindAsync(id);
            if (payDetail == null)
            {
                return NotFound();
            }

            _context.PayDetail.Remove(payDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayDetailExists(Guid id)
        {
            return (_context.PayDetail?.Any(e => e.PayDetailId == id)).GetValueOrDefault();
        }
    }
}
