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
    [Route("api/PastureGroups")]
    [ApiController]
    public class PastureGroupsController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public PastureGroupsController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/PastureGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastureGroupsModel>>> GetPastureGroupsModel()
        {
          if (_context.PastureGroupsModel == null)
          {
              return NotFound();
          }
            return await _context.PastureGroupsModel.ToListAsync();
        }

        // GET: api/PastureGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastureGroupsModel>> GetPastureGroupsModel(int id)
        {
          if (_context.PastureGroupsModel == null)
          {
              return NotFound();
          }
            var pastureGroupsModel = await _context.PastureGroupsModel.FindAsync(id);

            if (pastureGroupsModel == null)
            {
                return NotFound();
            }

            return pastureGroupsModel;
        }

        // PUT: api/PastureGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastureGroupsModel(int id, PastureGroupsModel pastureGroupsModel)
        {
            if (id != pastureGroupsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(pastureGroupsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastureGroupsModelExists(id))
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

        // POST: api/PastureGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PastureGroupsModel>> PostPastureGroupsModel(PastureGroupsModel pastureGroupsModel)
        {
          if (_context.PastureGroupsModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.PastureGroupsModel'  is null.");
          }
            _context.PastureGroupsModel.Add(pastureGroupsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastureGroupsModel", new { id = pastureGroupsModel.Id }, pastureGroupsModel);
        }

        // DELETE: api/PastureGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastureGroupsModel(int id)
        {
            if (_context.PastureGroupsModel == null)
            {
                return NotFound();
            }
            var pastureGroupsModel = await _context.PastureGroupsModel.FindAsync(id);
            if (pastureGroupsModel == null)
            {
                return NotFound();
            }

            _context.PastureGroupsModel.Remove(pastureGroupsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PastureGroupsModelExists(int id)
        {
            return (_context.PastureGroupsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
