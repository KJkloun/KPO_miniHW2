using System;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedingScheduleController : ControllerBase
    {
        private readonly FeedingOrganizationService _feedService;
        private readonly IFeedingScheduleRepository _repo;
        public FeedingScheduleController(FeedingOrganizationService feedService, IFeedingScheduleRepository repo)
        {
            _feedService = feedService; _repo = repo;
        }
        [HttpGet] public IActionResult GetAll() => Ok(_repo.GetAll());
        [HttpPost] public IActionResult Schedule([FromBody] ScheduleFeedingDto dto) { _feedService.Schedule(dto); return CreatedAtAction(nameof(GetAll), null); }
        [HttpPost("{id:guid}/complete")] public IActionResult Complete(Guid id) { _feedService.Complete(id); return Ok(); }
    }
}