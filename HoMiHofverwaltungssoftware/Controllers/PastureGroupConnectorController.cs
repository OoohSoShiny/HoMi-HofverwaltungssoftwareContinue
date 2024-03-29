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
    [Route("api/PasturGroupConnectors")]
    [ApiController]
    public class PastureGroupConnectorController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public PastureGroupConnectorController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/PasturGroupConnectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastureGroupConnectorModel>>> GetPastureGroupConnectorModel()
        {
          if (_context.PastureGroupConnectorModel == null)
          {
              return NotFound();
          }
            return await _context.PastureGroupConnectorModel.ToListAsync();
        }

        // GET: api/PasturGroupConnectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastureGroupConnectorModel>> GetPastureGroupConnectorModel(int id)
        {
          if (_context.PastureGroupConnectorModel == null)
          {
              return NotFound();
          }
            var pastureGroupConnectorModel = await _context.PastureGroupConnectorModel.FindAsync(id);

            if (pastureGroupConnectorModel == null)
            {
                return NotFound();
            }

            return pastureGroupConnectorModel;
        }

        // PUT: api/PasturGroupConnectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastureGroupConnectorModel(int id, PastureGroupConnectorModel pastureGroupConnectorModel)
        {
            if (id != pastureGroupConnectorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(pastureGroupConnectorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastureGroupConnectorModelExists(id))
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

        // POST: api/PastureGroupConnectorModels
        [HttpPost]
        public async Task<ActionResult<PastureGroupConnectorModel>> PostPastureGroupConnectorModel(PastureGroupConnectorModel pastureGroupConnectorModel)
        {
          if (_context.PastureGroupConnectorModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.PastureGroupConnectorModel'  is null.");
          }
            _context.PastureGroupConnectorModel.Add(pastureGroupConnectorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastureGroupConnectorModel", new { id = pastureGroupConnectorModel.Id }, pastureGroupConnectorModel);
        }

        // DELETE: api/PastureGroupConnectorModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastureGroupConnectorModel(int id)
        {
            if (_context.PastureGroupConnectorModel == null)
            {
                return NotFound();
            }
            var pastureGroupConnectorModel = await _context.PastureGroupConnectorModel.FindAsync(id);
            if (pastureGroupConnectorModel == null)
            {
                return NotFound();
            }

            _context.PastureGroupConnectorModel.Remove(pastureGroupConnectorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PastureGroupConnectorModelExists(int id)
        {
            return (_context.PastureGroupConnectorModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
