using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoMiHofverwaltungssoftware.Data;
using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastureTimesController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public PastureTimesController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/PastureTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastureTimes>>> GetPastureTimes()
        {
          if (_context.PastureTimes == null)
          {
              return NotFound();
          }
            return await _context.PastureTimes.ToListAsync();
        }

        // GET: api/PastureTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastureTimes>> GetPastureTimes(int id)
        {
          if (_context.PastureTimes == null)
          {
              return NotFound();
          }
            var pastureTimes = await _context.PastureTimes.FindAsync(id);

            if (pastureTimes == null)
            {
                return NotFound();
            }

            return pastureTimes;
        }

        // PUT: api/PastureTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastureTimes(int id, PastureTimes pastureTimes)
        {
            if (id != pastureTimes.Id)
            {
                return BadRequest();
            }

            _context.Entry(pastureTimes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastureTimesExists(id))
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

        // POST: api/PastureTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PastureTimes>> PostPastureTimes(PastureTimes pastureTimes)
        {
          if (_context.PastureTimes == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.PastureTimes'  is null.");
          }
            _context.PastureTimes.Add(pastureTimes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastureTimes", new { id = pastureTimes.Id }, pastureTimes);
        }

        // DELETE: api/PastureTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastureTimes(int id)
        {
            if (_context.PastureTimes == null)
            {
                return NotFound();
            }
            var pastureTimes = await _context.PastureTimes.FindAsync(id);
            if (pastureTimes == null)
            {
                return NotFound();
            }

            _context.PastureTimes.Remove(pastureTimes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PastureTimesExists(int id)
        {
            return (_context.PastureTimes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
