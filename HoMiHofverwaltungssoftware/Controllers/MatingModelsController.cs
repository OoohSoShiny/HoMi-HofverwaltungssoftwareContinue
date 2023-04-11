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
    [Route("api/[controller]")]
    [ApiController]
    public class MatingModelsController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public MatingModelsController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/MatingModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatingModel>>> GetMatingModel()
        {
          if (_context.MatingModel == null)
          {
              return NotFound();
          }
            return await _context.MatingModel.ToListAsync();
        }

        // GET: api/MatingModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatingModel>> GetMatingModel(int id)
        {
          if (_context.MatingModel == null)
          {
              return NotFound();
          }
            var matingModel = await _context.MatingModel.FindAsync(id);

            if (matingModel == null)
            {
                return NotFound();
            }

            return matingModel;
        }

        // PUT: api/MatingModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatingModel(int id, MatingModel matingModel)
        {
            if (id != matingModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(matingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatingModelExists(id))
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

        // POST: api/MatingModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MatingModel>> PostMatingModel(MatingModel matingModel)
        {
          if (_context.MatingModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.MatingModel'  is null.");
          }
            _context.MatingModel.Add(matingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatingModel", new { id = matingModel.Id }, matingModel);
        }

        // DELETE: api/MatingModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatingModel(int id)
        {
            if (_context.MatingModel == null)
            {
                return NotFound();
            }
            var matingModel = await _context.MatingModel.FindAsync(id);
            if (matingModel == null)
            {
                return NotFound();
            }

            _context.MatingModel.Remove(matingModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatingModelExists(int id)
        {
            return (_context.MatingModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
