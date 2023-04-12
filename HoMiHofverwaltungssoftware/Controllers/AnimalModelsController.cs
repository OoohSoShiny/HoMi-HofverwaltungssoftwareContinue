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
        public async Task<ActionResult<CompleteSingleAnimalResponse>> GetAnimalModel(int id)
        {
            if (_context.AnimalModel == null)
            {
                return NotFound();
            }
            CompleteSingleAnimalModel _completeSingleAnimalModel = new CompleteSingleAnimalModel();

            List<AnimalNotesModel>? _animalNotes = await _context.AnimalNotesModel
                .FromSqlRaw("SELECT Notiz FROM Tiernotizen WHERE Id = " + id.ToString())
                .ToListAsync();
            
            if(_animalNotes != null)
            {
                _completeSingleAnimalModel.AllgNotizen = _animalNotes.Select(x => x.Tiernotiz).ToList();
            }
        }
    }
}
