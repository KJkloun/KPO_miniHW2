using System;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.ValueObjects;
using Domain.Entities;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnclosureController : ControllerBase
    {
        private readonly IEnclosureRepository _enclosures;
        public EnclosureController(IEnclosureRepository enclosures) { _enclosures = enclosures; }
        [HttpGet] public IActionResult GetAll() => Ok(_enclosures.GetAll());
        [HttpGet("{id:guid}")] public IActionResult Get(Guid id) => Ok(_enclosures.GetById(new EnclosureId(id)));
        [HttpPost] public IActionResult Create([FromBody] CreateEnclosureDto dto)
        {
            var e = new Enclosure(EnclosureId.New(), dto.Type, dto.Size, dto.Capacity);
            _enclosures.Add(e);
            return CreatedAtAction(nameof(Get), new { id = e.Id.Value }, e);
        }
        [HttpDelete("{id:guid}")] public IActionResult Delete(Guid id) { _enclosures.Remove(new EnclosureId(id)); return NoContent(); }
    }
}