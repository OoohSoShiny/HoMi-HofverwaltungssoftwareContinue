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
    [Route("api/RutChecks")]
    [ApiController]
    public class RutCheckController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public RutCheckController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/RutChecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RutCheckModel>>> GetRutCheckModel()
        {
          if (_context.RutCheckModel == null)
          {
              return NotFound();
          }
            return await _context.RutCheckModel.ToListAsync();
        }

        // GET: api/RutChecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RutCheckModel>> GetRutCheckModel(int id)
        {
          if (_context.RutCheckModel == null)
          {
              return NotFound();
          }
            var rutCheckModel = await _context.RutCheckModel.FindAsync(id);

            if (rutCheckModel == null)
            {
                return NotFound();
            }

            return rutCheckModel;
        }

        // PUT: api/RutChecks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRutCheckModel(int id, RutCheckModel rutCheckModel)
        {
            if (id != rutCheckModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(rutCheckModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutCheckModelExists(id))
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

        // POST: api/RutChecks
        [HttpPost]
        public async Task<ActionResult<RutCheckModel>> PostRutCheckModel(RutCheckModel rutCheckModel)
        {
          if (_context.RutCheckModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.RutCheckModel'  is null.");
          }
            _context.RutCheckModel.Add(rutCheckModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRutCheckModel", new { id = rutCheckModel.Id }, rutCheckModel);
        }

        // DELETE: api/RutChecks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRutCheckModel(int id)
        {
            if (_context.RutCheckModel == null)
            {
                return NotFound();
            }
            var rutCheckModel = await _context.RutCheckModel.FindAsync(id);
            if (rutCheckModel == null)
            {
                return NotFound();
            }

            _context.RutCheckModel.Remove(rutCheckModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RutCheckModelExists(int id)
        {
            return (_context.RutCheckModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
