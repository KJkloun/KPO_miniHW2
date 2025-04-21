using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class InventoryItemDto
    {
        [Required] public string Name { get; set; }
        [Range(0, int.MaxValue)] public int Quantity { get; set; }
    }
}