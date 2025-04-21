using Application.DTOs;

namespace Application.Interfaces
{
    public interface IInventoryService
    {
        void AddItem(InventoryItemDto dto);
        void UpdateItem(string id, int quantity);
    }
}