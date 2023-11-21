using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hr_webapi.Models;
using System.Collections;
using hr_webapi.DataAccess;

namespace hr_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public ScheduleController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Schedule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedule()
        {
          if (_context.Schedules == null)
          {
              return NotFound();
          }
            return await _context.Schedules.ToListAsync();
        }

        // GET: api/Schedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(Guid id)
        {
          if (_context.Schedules == null)
          {
              return NotFound();
          }
            var Schedule = await _context.Schedules
                                         .Include(s => s.Employees)
                                         .Include(s => s.Shifts)
                                         .FirstOrDefaultAsync(s => s.ScheduleId == id);

            if (Schedule == null)
            {
                return NotFound();
            }

            return Schedule;
        }

        // PUT: api/Schedule/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(Guid id, Schedule Schedule)
        {
            if (id != Schedule.ScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(Schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        // POST: api/Schedule
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule(Schedule Schedule)
        {
            if (_context.Schedules == null)
            {
                return Problem("Entity set 'EmployeeContext.Schedule'  is null.");
            }

            _context.Schedules.Add(Schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchedule", new { id = Schedule.ScheduleId }, Schedule);
        }

        // DELETE: api/Schedule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(Guid id)
        {
            if (_context.Schedules == null)
            {
                return NotFound();
            }
            var Schedule = await _context.Schedules.FindAsync(id);
            if (Schedule == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(Schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Schedule/5/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{scheduleId}/Employee")]
        public async Task<ActionResult<Schedule>> PostEmployeeToSchedule(Guid scheduleId, ExistingEmployee employee)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null)
            {
                return NotFound("No schedule found for this id");
            }

            var employeeFromContext = await _context.Employees.FirstAsync(e => e.EmployeeId == employee.employeeId);
            if (employeeFromContext == null)
            {
                return BadRequest("Invalid employee");
            }

            try
            {
                schedule.Employees.Add(employeeFromContext);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Schedule/5/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{scheduleId}/Shift")]
        public async Task<ActionResult<Schedule>> PostShiftToSchedule(Guid scheduleId, ExistingShift shift)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null)
            {
                return NotFound("No schedule found for this id");
            }

            var shiftFromContext = await _context.Shifts.FirstAsync(s => s.ShiftId == shift.shiftId);
            if (shiftFromContext == null)
            {
                return BadRequest("Invalid shift");
            }

            try
            {
                schedule.Shifts.Add(shiftFromContext);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        public class ExistingEmployee
        {
            public Guid employeeId { get; set; }
        }

        public class ExistingShift
        {
            public Guid shiftId { get; set; }
        }

        private bool ScheduleExists(Guid id)
        {
            return (_context.Schedules?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }
    }
}
