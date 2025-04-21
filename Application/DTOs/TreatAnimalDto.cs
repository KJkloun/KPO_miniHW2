using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class TreatAnimalDto
    {
        [Required] public Guid AnimalId { get; set; }
        [Required] public bool IsSuccessful { get; set; }
        public string Notes { get; set; }
    }
}