using System;
using Application.DTOs;
using Application.Interfaces;
using Domain.Events;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    public class VeterinaryClinicService : IVeterinaryClinicService
    {
        private readonly IAnimalRepository _animals;
        private readonly IEventDispatcher _dispatcher;
        public VeterinaryClinicService(IAnimalRepository animals, IEventDispatcher dispatcher)
        {
            _animals = animals; _dispatcher = dispatcher;
        }
        public void TreatAnimal(TreatAnimalDto dto)
        {
            var animal = _animals.GetById(new AnimalId(dto.AnimalId));
            if (dto.IsSuccessful) animal.Heal();
            _dispatcher.Publish(new FeedingTimeEvent(animal.Id, DateTime.UtcNow, FeedType.Pellets));
        }
    }
}