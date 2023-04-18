Hier werden Punkte genannt die für die Dokumentation des Projektes wichtig ist, sowie einzelne Punkte die legalen Zwecken dienen.

Das HoMi Projekt ist eine Hofverwaltungsapp die für kleine bis mittlere Betriebe im Bereich des Milchvertriebs gedacht ist. Es besteht aus einer Datenbank,
einer Rest-API und dem Frontend, typischerweise Android-Handys. Es bietet Strukturen um Daten die für die Trächtigkeit und Untersuchungen von Kühen 
eine Rolle spielen. Da für diesen Bereich günstige Branchensoftware nicht oder nur schwer zu erhalten ist, soll diese Struktur dieses Problem beheben.

Dieses Projekt begann im Rahmen meines Abschlusses als Umschüler im Bereich der Anwendungsentwicklung in 2023. 

Controller für Models enthalten automatisch generierten Code in folgender Struktur (Alles was nicht diese Struktur fällt wurde persönlich entwickelt): 
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
    public class NameModelsController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public NameModelsController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/NameModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NameModel>>> GetNameModel()
        {
          if (_context.NameModel == null)
          {
              return NotFound();
          }
            return await _context.NameModel.ToListAsync();
        }

        // GET: api/NameModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NameModel>> GetNameModel(int id)
        {
          if (_context.NameModel == null)
          {
              return NotFound();
          }
            var nameModel = await _context.NameModel.FindAsync(id);

            if (nameModel == null)
            {
                return NotFound();
            }

            return nameModel;
        }

        // PUT: api/NameModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNameModel(int id, NameModel nameModel)
        {
            if (id != nameModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(nameModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NameModelExists(id))
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

        // POST: api/NameModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NameModel>> PostNameModel(NameModel nameModel)
        {
          if (_context.NameModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.NameModel'  is null.");
          }
            _context.NameModel.Add(nameModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNameModel", new { id = nameModel.Id }, nameModel);
        }

        // DELETE: api/NameModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNameModel(int id)
        {
            if (_context.NameModel == null)
            {
                return NotFound();
            }
            var nameModel = await _context.NameModel.FindAsync(id);
            if (nameModel == null)
            {
                return NotFound();
            }

            _context.NameModel.Remove(nameModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NameModelExists(int id)
        {
            return (_context.NameModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Weitere automatisch generierte Klassen / Files / Zeilen:
- Data/HoMiHofverwaltungssoftwareContext.cs
- appsettings.json
- HoMiHofverwaltungssoftware\Program.cs Zeile 8 - 29 