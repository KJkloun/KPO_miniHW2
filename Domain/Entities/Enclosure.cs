using System;
using System.Collections.Generic;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Enclosure
    {
        public EnclosureId Id { get; }
        public string Type { get; private set; }
        public double Size { get; private set; }
        public int Capacity { get; private set; }
        private readonly List<Animal> _animals = new();
        public IReadOnlyCollection<Animal> Animals => _animals.AsReadOnly();

        public Enclosure(EnclosureId id, string type, double size, int capacity)
        {
            if (string.IsNullOrWhiteSpace(type)) throw new ArgumentException("Type is required", nameof(type));
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
            Id = id; Type = type; Size = size; Capacity = capacity;
        }
        public void AddAnimal(Animal animal)
        {
            if (_animals.Count >= Capacity) throw new InvalidOperationException("Enclosure is full");
            _animals.Add(animal);
        }
        public void RemoveAnimal(Animal animal)
        {
            if (!_animals.Remove(animal)) throw new InvalidOperationException("Animal not found");
        }
    }
}