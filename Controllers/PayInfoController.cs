using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hr_webapi.Models;
using hr_webapi.DataAccess;

namespace hr_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayInfoController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public PayInfoController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/PayInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayInfo>>> GetPayInfo()
        {
          if (_context.PayInfos == null)
          {
              return NotFound();
          }
            return await _context.PayInfos.ToListAsync();
        }

        // GET: api/PayInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayInfo>> GetPayInfo(Guid id)
        {
          if (_context.PayInfos == null)
          {
              return NotFound();
          }
            var payInfo = await _context.PayInfos.FindAsync(id);

            if (payInfo == null)
            {
                return NotFound();
            }

            return payInfo;
        }

        // PUT: api/PayInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayInfo(Guid id, PayInfo payInfo)
        {
            if (id != payInfo.PayInfoId)
            {
                return BadRequest();
            }

            _context.Entry(payInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayInfoExists(id))
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

        // POST: api/PayInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PayInfo>> PostPayInfo(PayInfo payInfo)
        {
          if (_context.PayInfos == null)
          {
              return Problem("Entity set 'EmployeeContext.PayInfo'  is null.");
          }
            _context.PayInfos.Add(payInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayInfo", new { id = payInfo.PayInfoId }, payInfo);
        }

        // DELETE: api/PayInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayInfo(Guid id)
        {
            if (_context.PayInfos == null)
            {
                return NotFound();
            }
            var payInfo = await _context.PayInfos.FindAsync(id);
            if (payInfo == null)
            {
                return NotFound();
            }

            _context.PayInfos.Remove(payInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayInfoExists(Guid id)
        {
            return (_context.PayInfos?.Any(e => e.PayInfoId == id)).GetValueOrDefault();
        }
    }
}
