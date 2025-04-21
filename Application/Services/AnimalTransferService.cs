using System;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    public class AnimalTransferService
    {
        private readonly IAnimalRepository _animals;
        private readonly IEnclosureRepository _enclosures;
        private readonly IEventDispatcher _dispatcher;
        public AnimalTransferService(IAnimalRepository animals, IEnclosureRepository enclosures, IEventDispatcher dispatcher)
        {
            _animals = animals; _enclosures = enclosures; _dispatcher = dispatcher;
        }
        public void Transfer(Guid animalId, Guid enclosureId)
        {
            var animal = _animals.GetById(new AnimalId(animalId));
            var enclosure = _enclosures.GetById(new EnclosureId(enclosureId));
            animal.MoveTo(enclosure, _dispatcher);
        }
    }
}