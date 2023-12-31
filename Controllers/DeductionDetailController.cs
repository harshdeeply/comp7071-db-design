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
    public class DeductionDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeductionDetailController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DeductionDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeductionDetail>>> GetDeductionDetail()
        {
          if (_context.DeductionDetail == null)
          {
              return NotFound();
          }
            return await _context.DeductionDetail.ToListAsync();
        }

        // GET: api/DeductionDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeductionDetail>> GetDeductionDetail(Guid id)
        {
          if (_context.DeductionDetail == null)
          {
              return NotFound();
          }
            var deductionDetail = await _context.DeductionDetail.FindAsync(id);

            if (deductionDetail == null)
            {
                return NotFound();
            }

            return deductionDetail;
        }

        // PUT: api/DeductionDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeductionDetail(Guid id, DeductionDetail deductionDetail)
        {
            if (id != deductionDetail.DeductionDetailId)
            {
                return BadRequest();
            }

            _context.Entry(deductionDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeductionDetailExists(id))
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

        // POST: api/DeductionDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeductionDetail>> PostDeductionDetail(DeductionDetail deductionDetail)
        {
          if (_context.DeductionDetail == null)
          {
              return Problem("Entity set 'AppDbContext.DeductionDetail'  is null.");
          }
            _context.DeductionDetail.Add(deductionDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeductionDetail", new { id = deductionDetail.DeductionDetailId }, deductionDetail);
        }

        // DELETE: api/DeductionDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeductionDetail(Guid id)
        {
            if (_context.DeductionDetail == null)
            {
                return NotFound();
            }
            var deductionDetail = await _context.DeductionDetail.FindAsync(id);
            if (deductionDetail == null)
            {
                return NotFound();
            }

            _context.DeductionDetail.Remove(deductionDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeductionDetailExists(Guid id)
        {
            return (_context.DeductionDetail?.Any(e => e.DeductionDetailId == id)).GetValueOrDefault();
        }
    }
}
