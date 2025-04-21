using Application.DTOs;

namespace Application.Interfaces
{
    public interface IVeterinaryClinicService
    {
        void TreatAnimal(TreatAnimalDto dto);
    }
}