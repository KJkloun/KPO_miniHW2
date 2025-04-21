using System;
using System.ComponentModel.DataAnnotations;
using Domain.ValueObjects;

namespace Application.DTOs
{
    public class CreateAnimalDto
    {
        [Required] public string Species { get; set; }
        [Required] public string Name { get; set; }
        [Required] public DateTime BirthDate { get; set; }
        [Required] public Gender Gender { get; set; }
        [Required] public FeedType FavouriteFood { get; set; }
    }
}