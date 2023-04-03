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
    public class ControllerCows : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public ControllerCows(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/ControllerCows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cows>>> GetCows()
        {
          if (_context.Cows == null)
          {
              return NotFound();
          }
            return await _context.Cows.ToListAsync();
        }

        // GET: api/ControllerCows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cows>> GetCows(int id)
        {
          if (_context.Cows == null)
          {
              return NotFound();
          }
            var cows = await _context.Cows.FindAsync(id);

            if (cows == null)
            {
                return NotFound();
            }

            return cows;
        }

        // PUT: api/ControllerCows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCows(int id, Cows cows)
        {
            if (id != cows.Id)
            {
                return BadRequest();
            }

            _context.Entry(cows).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CowsExists(id))
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

        // POST: api/ControllerCows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cows>> PostCows(Cows cows)
        {
          if (_context.Cows == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.Cows'  is null.");
          }
            _context.Cows.Add(cows);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCows", new { id = cows.Id }, cows);
        }

        // DELETE: api/ControllerCows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCows(int id)
        {
            if (_context.Cows == null)
            {
                return NotFound();
            }
            var cows = await _context.Cows.FindAsync(id);
            if (cows == null)
            {
                return NotFound();
            }

            _context.Cows.Remove(cows);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CowsExists(int id)
        {
            return (_context.Cows?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
