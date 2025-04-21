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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly IInventoryRepository _repository;
        public InventoryController(IInventoryService inventoryService, IInventoryRepository repository)
        {
            _inventoryService = inventoryService; _repository = repository;
        }
        [HttpGet] public IActionResult GetAll() => Ok(_repository.GetAll());
        [HttpPost] public IActionResult Add([FromBody] InventoryItemDto dto) { _inventoryService.AddItem(dto); return CreatedAtAction(nameof(GetAll), null); }
        [HttpPut("{id}")] public IActionResult Update(string id, [FromQuery] int quantity) { _inventoryService.UpdateItem(id, quantity); return Ok(); }
    }
    
    public class MetadataController : ControllerBase
    {
        /// <summary>
        /// Возвращает список возможных значений для Gender (0 = Male, 1 = Female)
        /// </summary>
        [HttpGet("genders")]
        public IActionResult GetGenders()
        {
            var list = Enum.GetValues<Gender>()
                .Select(g => new { Value = (int)g, Name = g.ToString() });
            return Ok(list);
        }

        /// <summary>
        /// Возвращает список возможных значений для FeedType (0 = Meat, 1 = Vegetables, 2 = Fruits, 3 = Fish, 4 = Pellets)
        /// </summary>
        [HttpGet("feedtypes")]
        public IActionResult GetFeedTypes()
        {
            var list = Enum.GetValues<FeedType>()
                .Select(f => new { Value = (int)f, Name = f.ToString() });
            return Ok(list);
        }
    }
}