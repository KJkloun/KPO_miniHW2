using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class InMemoryAnimalRepository : IAnimalRepository
    {
        private readonly List<Animal> _store = new();
        public Animal GetById(AnimalId id) => _store.Single(a => a.Id.Equals(id));
        public IEnumerable<Animal> GetAll() => _store;
        public void Add(Animal animal) => _store.Add(animal);
        public void Remove(AnimalId id) => _store.Remove(GetById(id));
    }
}