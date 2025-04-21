using System.Linq;
using Application.DTOs;
using Application.Interfaces;

namespace Application.Services
{
    public class ZooStatisticsService : IStatisticsService
    {
        private readonly IAnimalRepository _animals;
        private readonly IEnclosureRepository _enclosures;
        private readonly IInventoryRepository _items;
        public ZooStatisticsService(IAnimalRepository animals, IEnclosureRepository enclosures, IInventoryRepository items)
        {
            _animals = animals; _enclosures = enclosures; _items = items;
        }
        public ZooStatisticsDto GetStatistics()
        {
            var encls = _enclosures.GetAll().ToList();
            return new ZooStatisticsDto
            {
                TotalAnimals = _animals.GetAll().Count(),
                TotalEnclosures = encls.Count,
                FreeEnclosures = encls.Count(e => e.Animals.Count < e.Capacity),
                TotalItems = _items.GetAll().Count()
            };
        }
    }
}