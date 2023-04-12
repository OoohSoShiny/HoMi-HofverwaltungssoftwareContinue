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

namespace HoMiHofverwaltungssoftware.Controllers
{
    [Route("api/GetAnimals")]
    [ApiController]
    public class AnimalModelsController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public AnimalModelsController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/AnimalModels
        [HttpGet]        
        public async Task<ActionResult<AnimalResponse>> GetAnimalModel()
        {
            if (_context.AnimalModel == null)
            {
                return NotFound();
            }
            AnimalResponse response = new AnimalResponse();
            response.Animals = await _context.AnimalModel.ToListAsync();
            return response;
        }

        // GET: api/AnimalModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompleteSingleAnimalModel>> GetAnimalModel(int id)
        {
            if (_context.AnimalModel == null || _context.AnimalNotesModel == null)
            {
                return NotFound();
            }
            CompleteSingleAnimalModel _completeSingleAnimalModel = new CompleteSingleAnimalModel();

            var _notes = await _context.AnimalNotesModel
                .FromSqlRaw("SELECT * FROM Tiernotizen WHERE Tiere_Id = " + id.ToString())
                .Select(_currentQuery => new
                {
                    _currentQuery.Notiz
                })
                .ToListAsync();

            if (_notes != null)
            {
                foreach(var _note in _notes)
                {
                    _completeSingleAnimalModel.AllgNotizen.Add(_note.Notiz);
                }
            }
            var _animal = _context.AnimalModel
                .FromSqlRaw("SELECT Ohrmarkennummer, Geboren, Geschlecht, Name, Archiviert, Masttier FROM Tiere WHERE Id = " + id.ToString())
                .Select(_currentQuery => new
                {
                    _currentQuery.Ohrmarkennummer,
                    _currentQuery.Geboren,
                    _currentQuery.Geschlecht,
                    _currentQuery.Name,
                    _currentQuery.Archiviert,
                    _currentQuery.Masttier
                })
                .FirstOrDefault();
            if(_animal == null)
            {
                return NotFound();
            }
            _completeSingleAnimalModel.Ohrmarkennummer = _animal.Ohrmarkennummer;
            _completeSingleAnimalModel.Geboren = _animal.Geboren;
            _completeSingleAnimalModel.Geschlecht = _animal.Geschlecht;
            _completeSingleAnimalModel.Name = _animal.Name;
            _completeSingleAnimalModel.Archiviert = _animal.Archiviert;
            _completeSingleAnimalModel.Masttier = _animal.Masttier;
                   
            return _completeSingleAnimalModel;
        }
    }
}