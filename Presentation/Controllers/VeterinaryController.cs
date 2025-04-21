using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.ValueObjects;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinaryController : ControllerBase
    {
        private readonly IVeterinaryClinicService _veterinaryService;
        private readonly IAnimalRepository _animals;
        public VeterinaryController(IVeterinaryClinicService veterinaryService, IAnimalRepository animals)
        {
            _veterinaryService = veterinaryService; _animals = animals;
        }
        [HttpPost("treat")]
        public IActionResult Treat([FromBody] TreatAnimalDto dto)
        {
            _veterinaryService.TreatAnimal(dto);
            return Ok(_animals.GetById(new AnimalId(dto.AnimalId)));
        }
    }
}