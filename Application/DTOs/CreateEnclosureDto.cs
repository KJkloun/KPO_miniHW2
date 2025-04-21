using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateEnclosureDto
    {
        [Required] public string Type { get; set; }
        [Range(0.1, double.MaxValue)] public double Size { get; set; }
        [Range(1, 1000)] public int Capacity { get; set; }
    }
}