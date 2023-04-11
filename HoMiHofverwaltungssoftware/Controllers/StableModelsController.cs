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
    public class StableModelsController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public StableModelsController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/StableModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StableModel>>> GetStableModel()
        {
          if (_context.StableModel == null)
          {
              return NotFound();
          }
            return await _context.StableModel.ToListAsync();
        }

        // GET: api/StableModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StableModel>> GetStableModel(int id)
        {
          if (_context.StableModel == null)
          {
              return NotFound();
          }
            var stableModel = await _context.StableModel.FindAsync(id);

            if (stableModel == null)
            {
                return NotFound();
            }

            return stableModel;
        }

        // PUT: api/StableModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStableModel(int id, StableModel stableModel)
        {
            if (id != stableModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(stableModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StableModelExists(id))
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

        // POST: api/StableModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StableModel>> PostStableModel(StableModel stableModel)
        {
          if (_context.StableModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.StableModel'  is null.");
          }
            _context.StableModel.Add(stableModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStableModel", new { id = stableModel.Id }, stableModel);
        }

        // DELETE: api/StableModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStableModel(int id)
        {
            if (_context.StableModel == null)
            {
                return NotFound();
            }
            var stableModel = await _context.StableModel.FindAsync(id);
            if (stableModel == null)
            {
                return NotFound();
            }

            _context.StableModel.Remove(stableModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StableModelExists(int id)
        {
            return (_context.StableModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
