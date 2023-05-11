using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoMiHofverwaltungssoftware.Data;
using HoMiHofverwaltungssoftware.Models;
using HoMiHofverwaltungssoftware.Responses;
using HoMiHofverwaltungssoftware.Settings;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace HoMiHofverwaltungssoftware.Controllers
{
    [Route("api/Animals")]
    [ApiController]
    public class AnimalModelsController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public AnimalModelsController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<AnimalSimpleResponse>> GetSimpleAnimals()
        {
            if (_context.AnimalModel == null)
            {
                return NotFound();
            }

            AnimalSimpleResponse animalSimpleResponse = new AnimalSimpleResponse();

            var _animal = await _context.AnimalModel
                .FromSqlRaw("SELECT Tiere.Id, Nummer AS Stallnummer, Ohrmarkennummer " +
                "FROM Tiere " +
                "JOIN Stallnummern ON Tiere.Stallnummer_Id = Stallnummern.Id ")
                .Select(currentquery => new
                {
                    currentquery.Id,
                    currentquery.Ohrmarkennummer,
                    currentquery.Stallnummer
                })
                .ToListAsync();

            if (_animal != null)
            {
                foreach (var item in _animal)
                {
                    AnimalSimpleModel animalSimpleModel = new AnimalSimpleModel();
                    animalSimpleModel.Ohrmarkennummer = item.Ohrmarkennummer;
                    animalSimpleModel.Stallnummer = item.Stallnummer;
                    animalSimpleModel.Id = item.Id;

                    animalSimpleResponse.animalsSimple.Add(animalSimpleModel);
                }
            }
            return animalSimpleResponse;
        }
        //Stablenumber earnumber ordergroup

        // GET: api/Animals/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AnimalCompleteResponse>> GetAnimalModel(int id)
        {
            //Checks if the correct _context exist before trying to access it.
            AnimalCompleteResponse completeResponse = new AnimalCompleteResponse();

            if (_context.AnimalModel == null || _context.AnimalNotesModel == null || _context.PregnancyCheckupModel == null || _context.OrderGroupsModel == null || _context.MatingModel == null ||
                _context.PastureGroupConnectorModel == null || _context.PastureGroupsModel == null)
            {
                return NotFound();
            }

            //Base for the object that gets returned in the end
            AnimalCompleteModel completeSingleAnimalModel = new AnimalCompleteModel();

            //Decided to send several small queries instead of one large one - standard joins have troubles returning something if the cow doesnt
            //exist somewhere, left joins have the tendency to give back large quantities of data which needs to be filtered. A "Sql-Join-String-Constructor"
            //another option, still required to check each table for existing data beforehand, so might as well pick it already


            //Getting the baseline animal and assign corresponding values to the complete Animal
            var animal = _context.AnimalModel
                .FromSqlRaw("SELECT Nummer AS Stallnummer, Ohrmarkennummer, Geboren, Geschlecht, Name, Tiere.Archiviert, " +
                "Masttier FROM Tiere JOIN Stallnummern ON Tiere.Stallnummer_Id = Stallnummern.Id WHERE Tiere.Id = " + id.ToString())
                .Select(currentQuery => new
                {
                    currentQuery.Stallnummer,
                    currentQuery.Ohrmarkennummer,
                    currentQuery.Geboren,
                    currentQuery.Geschlecht,
                    currentQuery.Name,
                    currentQuery.Archiviert,
                    currentQuery.Masttier,
                })
                .FirstOrDefault();

            //If the baseline animal does not exist returns 404
            if (animal == null)
            {
                return NotFound();
            }

            completeSingleAnimalModel.Id = id;
            completeSingleAnimalModel.Ohrmarkennummer = animal.Ohrmarkennummer;
            completeSingleAnimalModel.Geboren = animal.Geboren;
            completeSingleAnimalModel.Geschlecht = animal.Geschlecht;
            completeSingleAnimalModel.Name = animal.Name;
            completeSingleAnimalModel.Archiviert = animal.Archiviert;
            completeSingleAnimalModel.Masttier = animal.Masttier;
            completeSingleAnimalModel.Stallnummer = animal.Stallnummer;


            //Checking if any notes exist for this animal and adding it to the general notes list
            var notes = await _context.AnimalNotesModel
                .FromSqlRaw("SELECT * FROM Tiernotizen WHERE Tiere_Id = " + id.ToString())
                .Select(currentQuery => new
                {
                    currentQuery.Id,
                    currentQuery.Tiere_Id,
                    currentQuery.Notiz,
                })
                .ToListAsync();

            if (notes != null)
            {
                foreach (var note in notes)
                {
                    completeSingleAnimalModel.AllgNotizen.Add(new AnimalNotesModel(note.Id, note.Tiere_Id, note.Notiz));
                }
            }


            //Adding all pregnancy check notes to the pregnancy check list
            var pregnancyCheck = await _context.PregnancyCheckupModel
                .FromSqlRaw("SELECT * FROM Traechtigkeitsuntersuchung WHERE Tiere_Id = " + id.ToString())
                .Select(currentQuery => new
                {
                    currentQuery.Id,
                    currentQuery.Notiz,
                    currentQuery.Termin
                })
                .ToListAsync();
            if (pregnancyCheck != null)
            {
                foreach (var _check in pregnancyCheck)
                {
                    PregnancyCheckupModel checkConstructor = new PregnancyCheckupModel();
                    checkConstructor.Tiere_Id = id;
                    checkConstructor.Id = _check.Id;
                    checkConstructor.Termin = _check.Termin;
                    checkConstructor.Notiz = _check.Notiz;

                    completeSingleAnimalModel.TUNotizen.Add(checkConstructor);
                }
            }

            //OrderGroup Call 
            var _orderGroup = await _context.OrderGroupsModel
                .FromSqlRaw("SELECT Bezeichnung FROM Ordnungsgruppen WHERE Id = " + completeSingleAnimalModel.Ohrmarkennummer)
                .Select(_currentQuery => new
                {
                    _currentQuery.Bezeichnung
                })
                .FirstOrDefaultAsync();

            if (_orderGroup != null)
            {
                completeSingleAnimalModel.Ordnungsgruppe = _orderGroup.Bezeichnung;
            }


            var _parentFinder = await _context.AnimalModel
                .FromSqlRaw("SELECT Ohrmarkennummer FROM Tiere " +
                    "LEFT JOIN Deckungen ON Deckungen.Muttertier = Tiere.Id " +
                    "WHERE Deckungen.Kindtier = " + id + " " +
                    "UNION " +
                    "SELECT Ohrmarkennummer FROM Tiere " +
                    "LEFT JOIN Deckungen ON Deckungen.Vatertier = Tiere.Id " +
                    "WHERE Deckungen.Kindtier = " + id)
                .Select(currentQuery => new
                {
                    currentQuery.Ohrmarkennummer
                })
                .ToListAsync();

            for (int i = 0; i < _parentFinder.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        completeSingleAnimalModel.Muttertier = _parentFinder[0].ToString();
                        break;
                    case 1:
                        completeSingleAnimalModel.Vatertier = _parentFinder[1].ToString();
                        break;
                }
            }

            var _pastureGroupFinder = await _context.PastureGroupsModel
                .FromSqlRaw("SELECT Bezeichnung, Weidegruppen.id " +
                "FROM Weidegruppen " +
                "JOIN Weidegruppenzuordnung " +
                "ON Weidegruppen.Id = Weidegruppenzuordnung.Weidegruppen_Id " +
                "WHERE Weidegruppenzuordnung.Tiere_Id = " + id)
                .Select(currentQuery => new
                {
                    currentQuery.Bezeichnung,
                    currentQuery.Id
                })
                .ToListAsync();

            if (_pastureGroupFinder != null && _pastureGroupFinder.Count > 0)
            {
                foreach (var currentPasture in _pastureGroupFinder)
                {
                    completeSingleAnimalModel.Weidegruppen.Add(new PastureGroupsModel(currentPasture.Id, currentPasture.Bezeichnung));
                }
            }
            completeResponse.AnimalCompleteModels.Add(completeSingleAnimalModel);
            return completeResponse;
        }

        // PUT: api/animals/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutAnimalModel(int id, AnimalCompleteModel animalModel)
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
        private bool AnimalModelExists(int id)
        {
            return (_context.AnimalModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}