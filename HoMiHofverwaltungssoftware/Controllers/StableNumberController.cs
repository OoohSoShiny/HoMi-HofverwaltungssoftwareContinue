﻿using System;
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
    [Route("api/StableNumbers")]
    [ApiController]
    public class StableNumberController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public StableNumberController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/StableNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StableNumberModel>>> GetStableModel()
        {
          if (_context.StableModel == null)
          {
              return NotFound();
          }
            return await _context.StableModel.ToListAsync();
        }

        // GET: api/StableNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StableNumberModel>> GetStableNumberModel(int id)
        {
          if (_context.StableModel == null)
          {
              return NotFound();
          }
            var stableNumberModel = await _context.StableModel.FindAsync(id);

            if (stableNumberModel == null)
            {
                return NotFound();
            }

            return stableNumberModel;
        }

        // PUT: api/StableNumbers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStableNumberModel(int id, StableNumberModel stableNumberModel)
        {
            if (id != stableNumberModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(stableNumberModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StableNumberModelExists(id))
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

        // POST: api/StableNumbers
        [HttpPost]
        public async Task<ActionResult<StableNumberModel>> PostStableNumberModel(StableNumberModel stableNumberModel)
        {
          if (_context.StableModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.StableModel'  is null.");
          }
            _context.StableModel.Add(stableNumberModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStableNumberModel", new { id = stableNumberModel.Id }, stableNumberModel);
        }

        // DELETE: api/StableNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStableNumberModel(int id)
        {
            if (_context.StableModel == null)
            {
                return NotFound();
            }
            var stableNumberModel = await _context.StableModel.FindAsync(id);
            if (stableNumberModel == null)
            {
                return NotFound();
            }

            _context.StableModel.Remove(stableNumberModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StableNumberModelExists(int id)
        {
            return (_context.StableModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
