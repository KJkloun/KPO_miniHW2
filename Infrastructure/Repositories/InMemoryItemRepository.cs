using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class InMemoryItemRepository : IInventoryRepository
    {
        private readonly List<Item> _store = new();
        public Item GetById(ItemId id) => _store.Single(i => i.Id.Equals(id));
        public IEnumerable<Item> GetAll() => _store;
        public void Add(Item item) => _store.Add(item);
        public void Update(Item item)
        {
            var idx = _store.FindIndex(i => i.Id.Equals(item.Id));
            if (idx >= 0) _store[idx] = item;
        }
    }
}