using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class InMemoryEnclosureRepository : IEnclosureRepository
    {
        private readonly List<Enclosure> _store = new();
        public Enclosure GetById(EnclosureId id) => _store.Single(e => e.Id.Equals(id));
        public IEnumerable<Enclosure> GetAll() => _store;
        public void Add(Enclosure enclosure) => _store.Add(enclosure);
        public void Remove(EnclosureId id) => _store.Remove(GetById(id));
    }
}