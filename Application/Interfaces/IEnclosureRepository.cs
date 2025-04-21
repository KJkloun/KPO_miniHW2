using System.Collections.Generic;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface IEnclosureRepository
    {
        Enclosure GetById(EnclosureId id);
        IEnumerable<Enclosure> GetAll();
        void Add(Enclosure enclosure);
        void Remove(EnclosureId id);
    }
}