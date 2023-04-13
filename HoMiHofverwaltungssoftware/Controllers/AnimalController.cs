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
            //Checks if the correct _context exist before trying to access it. 

            if (_context.AnimalModel == null || _context.AnimalNotesModel == null || _context.PregnancyCheckupModel == null || _context.OrderGroupsModel == null || _context.MatingModel == null ||
                _context.PastureGroupConnectorModel == null || _context.PastureGroupsModel == null)
            {
                return NotFound();
            }

            //Base for the object that gets returned in the end
            CompleteSingleAnimalModel _completeSingleAnimalModel = new CompleteSingleAnimalModel();

            //Decided to send several small queries instead of one large one - standard joins have troubles returning something if the cow doesnt
            //exist somewhere, left joins have the tendency to give back large quantities of data which needs to be filtered. A "Sql-Join-String-Constructor"
            //another option, still required to check each table for existing data beforehand, so might as well pick it already


            //Getting the baseline animal and assign corresponding values to the complete Animal
            var _animal = _context.AnimalModel
                .FromSqlRaw("SELECT Ordnungsgruppen_Id, Nummer AS Stallnummer_Id, Ohrmarkennummer, Geboren, Geschlecht, Name, Tiere.Archiviert, Masttier FROM Tiere JOIN Stallnummern ON Tiere.Stallnummer_Id = Stallnummern.Id WHERE Tiere.Id = " + id.ToString())
                .Select(_currentQuery => new
                {
                    _currentQuery.Ordnungsgruppen_Id,
                    _currentQuery.Stallnummer_Id,
                    _currentQuery.Ohrmarkennummer,
                    _currentQuery.Geboren,
                    _currentQuery.Geschlecht,
                    _currentQuery.Name,
                    _currentQuery.Archiviert,
                    _currentQuery.Masttier,
                })
                .FirstOrDefault();

            //If the baseline animal does not exist returns 404
            if(_animal == null)
            {
                return NotFound();
            }

            _completeSingleAnimalModel.Id = id;
            _completeSingleAnimalModel.Ohrmarkennummer = _animal.Ohrmarkennummer;
            _completeSingleAnimalModel.Geboren = _animal.Geboren;
            _completeSingleAnimalModel.Geschlecht = _animal.Geschlecht;
            _completeSingleAnimalModel.Name = _animal.Name;
            _completeSingleAnimalModel.Archiviert = _animal.Archiviert;
            _completeSingleAnimalModel.Masttier = _animal.Masttier;
            _completeSingleAnimalModel.Stallnummer = _animal.Stallnummer_Id.ToString();
            _completeSingleAnimalModel.Ordnungsgruppe = _animal.Ordnungsgruppen_Id.ToString();


            //Checking if any notes exist for this animal and adding it to the general notes list
            var _notes = await _context.AnimalNotesModel
                .FromSqlRaw("SELECT * FROM Tiernotizen WHERE Tiere_Id = " + id.ToString())
                .Select(_currentQuery => new
                {
                    _currentQuery.Notiz
                })
                .ToListAsync();

            if (_notes != null)
            {
                foreach (var _note in _notes)
                {
                    _completeSingleAnimalModel.AllgNotizen.Add(_note.Notiz);
                }
            }


            //Adding all pregnancy check notes to the pregnancy check list
            var _pregnancyCheck = await _context.PregnancyCheckupModel
                .FromSqlRaw("SELECT * FROM Traechtigkeitsuntersuchung WHERE Tiere_Id = " + id.ToString())
                .Select(_currentQuery => new 
                {                     
                    _currentQuery.Id,
                    _currentQuery.Notiz,
                    _currentQuery.Termin
                })
                .ToListAsync();
            if( _pregnancyCheck != null )
            {
                foreach(var _check in _pregnancyCheck)
                {
                    PregnancyCheckupModel _checkConstructor = new PregnancyCheckupModel();
                    _checkConstructor.Tiere_Id = id;
                    _checkConstructor.Id = _check.Id;
                    _checkConstructor.Termin = _check.Termin;
                    _checkConstructor.Notiz = _check.Notiz;

                    _completeSingleAnimalModel.TUNotizen.Add(_checkConstructor);
                }
            }

            //OrderGroup Call 
            var _orderGroup = await _context.OrderGroupsModel
                .FromSqlRaw("SELECT Bezeichnung FROM Ordnungsgruppen WHERE Id = " + _completeSingleAnimalModel.Ordnungsgruppe)
                .Select(_currentQuery => new
                {
                    _currentQuery.Bezeichnung
                })
                .FirstOrDefaultAsync();

            if( _orderGroup != null ) 
            {
                _completeSingleAnimalModel.Ordnungsgruppe = _orderGroup.Bezeichnung;
            }

            var _parentFinder = await _context.AnimalModel
                .FromSqlRaw("SELECT Ohrmarkennummer FROM Tiere " + 
                    "LEFT JOIN Deckungen ON Deckungen.Muttertier = Tiere.Id " +
                    "WHERE Deckungen.Kindtier = " + id + " " +
                    "UNION " +
                    "SELECT Ohrmarkennummer FROM Tiere " +
                    "LEFT JOIN Deckungen ON Deckungen.Vatertier = Tiere.Id "+ 
                    "WHERE Deckungen.Kindtier = " + id)
                .Select(_currentQuery => new
                {
                    _currentQuery.Ohrmarkennummer
                })
                .ToListAsync();

            for(int i = 0;  i < _parentFinder.Count; i++)
            {
                switch (i)
                {
                    case 0: _completeSingleAnimalModel.Muttertier = _parentFinder[0].ToString();
                        break;
                    case 1: _completeSingleAnimalModel.Vatertier = _parentFinder[1].ToString();
                        break;
                }
            }

            var _pastureGroupFinder = await _context.PastureGroupsModel
                .FromSqlRaw("SELECT Bezeichnung " +
                "FROM Weidegruppen " +
                "JOIN Weidegruppenzuordnung " +
                "ON Weidegruppen.Id = Weidegruppenzuordnung.Weidegruppen_Id " +
                "WHERE Weidegruppenzuordnung.Tiere_Id = " + id)
                .Select(_currentQuery => new
                {
                    _currentQuery.Bezeichnung
                })
                .ToListAsync();

            if (_pastureGroupFinder.Count > 0)
            {
                foreach (var _currentPasture in _pastureGroupFinder)
                {
                    _completeSingleAnimalModel.Weidegruppen.Add(_currentPasture.ToString());
                }
            }

            return _completeSingleAnimalModel;
        }
    }
}