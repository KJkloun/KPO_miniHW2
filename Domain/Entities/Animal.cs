using System;
using Domain.Events;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Animal
    {
        public AnimalId Id { get; }
        public string Species { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public FeedType FavouriteFood { get; private set; }
        public bool IsHealthy { get; private set; }
        private Enclosure _enclosure;
        public Enclosure Enclosure => _enclosure;

        public Animal(AnimalId id, string species, string name,
                      DateTime birthDate, Gender gender, FeedType favouriteFood)
        {
            if (string.IsNullOrWhiteSpace(species)) throw new ArgumentException("Species is required", nameof(species));
            if (string.IsNullOrWhiteSpace(name))    throw new ArgumentException("Name is required", nameof(name));
            if (birthDate > DateTime.UtcNow)        throw new ArgumentOutOfRangeException(nameof(birthDate), "BirthDate cannot be in the future");
            Id = id; Species = species; Name = name; BirthDate = birthDate; Gender = gender; FavouriteFood = favouriteFood; IsHealthy = true;
        }

        public void Heal() => IsHealthy = true;
        public void Feed(FeedType feed, IEventDispatcher dispatcher)
        {
            if (feed != FavouriteFood) throw new InvalidOperationException($"Cannot feed {feed}, favourite is {FavouriteFood}");
            dispatcher.Publish(new FeedingTimeEvent(Id, DateTime.UtcNow, feed));
        }
        public void MoveTo(Enclosure target, IEventDispatcher dispatcher)
        {
            if (_enclosure == target) return;
            _enclosure?.RemoveAnimal(this);
            target.AddAnimal(this);
            var from = _enclosure?.Id;
            _enclosure = target;
            dispatcher.Publish(new AnimalMovedEvent(Id, from, target.Id, DateTime.UtcNow));
        }
    }
}