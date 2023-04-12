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
    public class PastureController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public PastureController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/Pasture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastureModel>>> GetPastureModel()
        {
          if (_context.PastureModel == null)
          {
              return NotFound();
          }
            return await _context.PastureModel.ToListAsync();
        }

        // GET: api/Pasture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastureModel>> GetPastureModel(int id)
        {
          if (_context.PastureModel == null)
          {
              return NotFound();
          }
            var pastureModel = await _context.PastureModel.FindAsync(id);

            if (pastureModel == null)
            {
                return NotFound();
            }

            return pastureModel;
        }

        // PUT: api/Pasture/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastureModel(int id, PastureModel pastureModel)
        {
            if (id != pastureModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(pastureModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastureModelExists(id))
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

        // POST: api/Pasture
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PastureModel>> PostPastureModel(PastureModel pastureModel)
        {
          if (_context.PastureModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.PastureModel'  is null.");
          }
            _context.PastureModel.Add(pastureModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastureModel", new { id = pastureModel.Id }, pastureModel);
        }

        // DELETE: api/Pasture/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastureModel(int id)
        {
            if (_context.PastureModel == null)
            {
                return NotFound();
            }
            var pastureModel = await _context.PastureModel.FindAsync(id);
            if (pastureModel == null)
            {
                return NotFound();
            }

            _context.PastureModel.Remove(pastureModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PastureModelExists(int id)
        {
            return (_context.PastureModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
