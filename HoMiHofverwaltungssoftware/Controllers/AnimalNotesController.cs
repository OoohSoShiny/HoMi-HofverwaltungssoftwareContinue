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
    [Route("api/AnimalNotes")]
    [ApiController]
    public class AnimalNotesController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public AnimalNotesController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/AnimalNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalNotesModel>>> GetAnimalNotesModel()
        {
          if (_context.AnimalNotesModel == null)
          {
              return NotFound();
          }
            return await _context.AnimalNotesModel.ToListAsync();
        }

        // GET: api/AnimalNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalNotesModel>> GetAnimalNotesModel(int id)
        {
          if (_context.AnimalNotesModel == null)
          {
              return NotFound();
          }
            var animalNotesModel = await _context.AnimalNotesModel.FindAsync(id);

            if (animalNotesModel == null)
            {
                return NotFound();
            }

            return animalNotesModel;
        }

        // PUT: api/AnimalNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalNotesModel(int id, AnimalNotesModel animalNotesModel)
        {
            if (id != animalNotesModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(animalNotesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalNotesModelExists(id))
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

        // POST: api/AnimalNotes
        [HttpPost]
        public async Task<ActionResult<AnimalNotesModel>> PostAnimalNotesModel(AnimalNotesModel animalNotesModel)
        {
          if (_context.AnimalNotesModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.AnimalNotesModel'  is null.");
          }
            _context.AnimalNotesModel.Add(animalNotesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalNotesModel", new { id = animalNotesModel.Id }, animalNotesModel);
        }

        // DELETE: api/AnimalNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalNotesModel(int id)
        {
            if (_context.AnimalNotesModel == null)
            {
                return NotFound();
            }
            var animalNotesModel = await _context.AnimalNotesModel.FindAsync(id);
            if (animalNotesModel == null)
            {
                return NotFound();
            }

            _context.AnimalNotesModel.Remove(animalNotesModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalNotesModelExists(int id)
        {
            return (_context.AnimalNotesModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
