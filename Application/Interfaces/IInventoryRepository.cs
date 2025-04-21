using System.Collections.Generic;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface IInventoryRepository
    {
        Item GetById(ItemId id);
        IEnumerable<Item> GetAll();
        void Add(Item item);
        void Update(Item item);
    }
}