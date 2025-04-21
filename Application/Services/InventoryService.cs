using System;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _items;
        public InventoryService(IInventoryRepository items) { _items = items; }
        public void AddItem(InventoryItemDto dto)
        {
            var item = new Item(ItemId.New(), dto.Name, dto.Quantity);
            _items.Add(item);
        }
        public void UpdateItem(string id, int quantity)
        {
            var item = _items.GetById(new ItemId(Guid.Parse(id)));
            item.UpdateQuantity(quantity);
            _items.Update(item);
        }
    }
}