using System;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.ValueObjects;
using Domain.Entities;
using Domain.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animals;
        private readonly AnimalTransferService _transfer;
        private readonly IEventDispatcher _dispatcher;
        public AnimalController(IAnimalRepository animals, AnimalTransferService transfer, IEventDispatcher dispatcher)
        {
            _animals = animals; _transfer = transfer; _dispatcher = dispatcher;
        }
        [HttpGet] public IActionResult GetAll() => Ok(_animals.GetAll());
        [HttpGet("{id:guid}")] public IActionResult Get(Guid id) => Ok(_animals.GetById(new AnimalId(id)));
        [HttpPost] public IActionResult Create([FromBody] CreateAnimalDto dto)
        {
            var a = new Animal(AnimalId.New(), dto.Species, dto.Name, dto.BirthDate, dto.Gender, dto.FavouriteFood);
            _animals.Add(a);
            return CreatedAtAction(nameof(Get), new { id = a.Id.Value }, a);
        }
        [HttpDelete("{id:guid}")] public IActionResult Delete(Guid id) { _animals.Remove(new AnimalId(id)); return NoContent(); }
        [HttpPost("{id:guid}/move")] public IActionResult Move(Guid id, [FromQuery] Guid enclosureId) { _transfer.Transfer(id, enclosureId); return Ok(); }
        [HttpPost("{id:guid}/feed")] public IActionResult Feed(Guid id, [FromQuery] FeedType feed) { var a = _animals.GetById(new AnimalId(id)); a.Feed(feed, _dispatcher); return Ok(); }
    }
}