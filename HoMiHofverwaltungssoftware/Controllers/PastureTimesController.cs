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
    [Route("api/PastureTimes")]
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
        public async Task<ActionResult<IEnumerable<PastureTimesModel>>> GetPastureTimes()
        {
          if (_context.PastureTimes == null)
          {
              return NotFound();
          }
            return await _context.PastureTimes.ToListAsync();
        }

        // GET: api/PastureTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastureTimesModel>> GetPastureTimesModel(int id)
        {
          if (_context.PastureTimes == null)
          {
              return NotFound();
          }
            var pastureTimesModel = await _context.PastureTimes.FindAsync(id);

            if (pastureTimesModel == null)
            {
                return NotFound();
            }

            return pastureTimesModel;
        }

        // PUT: api/PastureTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastureTimesModel(int id, PastureTimesModel pastureTimesModel)
        {
            if (id != pastureTimesModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(pastureTimesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastureTimesModelExists(id))
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
        public async Task<ActionResult<PastureTimesModel>> PostPastureTimesModel(PastureTimesModel pastureTimesModel)
        {
          if (_context.PastureTimes == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.PastureTimes'  is null.");
          }
            _context.PastureTimes.Add(pastureTimesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastureTimesModel", new { id = pastureTimesModel.Id }, pastureTimesModel);
        }

        // DELETE: api/PastureTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastureTimesModel(int id)
        {
            if (_context.PastureTimes == null)
            {
                return NotFound();
            }
            var pastureTimesModel = await _context.PastureTimes.FindAsync(id);
            if (pastureTimesModel == null)
            {
                return NotFound();
            }

            _context.PastureTimes.Remove(pastureTimesModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PastureTimesModelExists(int id)
        {
            return (_context.PastureTimes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
