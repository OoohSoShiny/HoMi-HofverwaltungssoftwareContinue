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
    public class PregnancyCheckupController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public PregnancyCheckupController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/PregnancyCheckup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PregnancyCheckupModel>>> GetPregnancyCheckupModel()
        {
          if (_context.PregnancyCheckupModel == null)
          {
              return NotFound();
          }
            return await _context.PregnancyCheckupModel.ToListAsync();
        }

        // GET: api/PregnancyCheckup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PregnancyCheckupModel>> GetPregnancyCheckupModel(int id)
        {
          if (_context.PregnancyCheckupModel == null)
          {
              return NotFound();
          }
            var pregnancyCheckupModel = await _context.PregnancyCheckupModel.FindAsync(id);

            if (pregnancyCheckupModel == null)
            {
                return NotFound();
            }

            return pregnancyCheckupModel;
        }

        // PUT: api/PregnancyCheckup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPregnancyCheckupModel(int id, PregnancyCheckupModel pregnancyCheckupModel)
        {
            if (id != pregnancyCheckupModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(pregnancyCheckupModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PregnancyCheckupModelExists(id))
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

        // POST: api/PregnancyCheckup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PregnancyCheckupModel>> PostPregnancyCheckupModel(PregnancyCheckupModel pregnancyCheckupModel)
        {
          if (_context.PregnancyCheckupModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.PregnancyCheckupModel'  is null.");
          }
            _context.PregnancyCheckupModel.Add(pregnancyCheckupModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPregnancyCheckupModel", new { id = pregnancyCheckupModel.Id }, pregnancyCheckupModel);
        }

        // DELETE: api/PregnancyCheckup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePregnancyCheckupModel(int id)
        {
            if (_context.PregnancyCheckupModel == null)
            {
                return NotFound();
            }
            var pregnancyCheckupModel = await _context.PregnancyCheckupModel.FindAsync(id);
            if (pregnancyCheckupModel == null)
            {
                return NotFound();
            }

            _context.PregnancyCheckupModel.Remove(pregnancyCheckupModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PregnancyCheckupModelExists(int id)
        {
            return (_context.PregnancyCheckupModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
