using System;
using System.ComponentModel.DataAnnotations;
using Domain.ValueObjects;

namespace Application.DTOs
{
    public class ScheduleFeedingDto
    {
        [Required] public Guid AnimalId { get; set; }
        [Required] public DateTime Time { get; set; }
        [Required] public FeedType FeedType { get; set; }
    }
}