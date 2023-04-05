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
    public class AnimalsController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public AnimalsController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalModel>>> GetAnimalModel()
        {
          if (_context.AnimalModel == null)
          {
              return NotFound();
          }
            return await _context.AnimalModel.ToListAsync();
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalModel>> GetAnimalModel(int id)
        {
          if (_context.AnimalModel == null)
          {
              return NotFound();
          }
            var animalModel = await _context.AnimalModel.FindAsync(id);

            if (animalModel == null)
            {
                return NotFound();
            }

            return animalModel;
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalModel(int id, AnimalModel animalModel)
        {
            if (id != animalModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(animalModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalModelExists(id))
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

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalModel>> PostAnimalModel(AnimalModel animalModel)
        {
          if (_context.AnimalModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.AnimalModel'  is null.");
          }
            _context.AnimalModel.Add(animalModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalModel", new { id = animalModel.Id }, animalModel);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalModel(int id)
        {
            if (_context.AnimalModel == null)
            {
                return NotFound();
            }
            var animalModel = await _context.AnimalModel.FindAsync(id);
            if (animalModel == null)
            {
                return NotFound();
            }

            _context.AnimalModel.Remove(animalModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalModelExists(int id)
        {
            return (_context.AnimalModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
