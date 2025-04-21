using System.Collections.Generic;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface IAnimalRepository
    {
        Animal GetById(AnimalId id);
        IEnumerable<Animal> GetAll();
        void Add(Animal animal);
        void Remove(AnimalId id);
    }
}