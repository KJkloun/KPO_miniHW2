using Application.DTOs;

namespace Application.Interfaces
{
    public interface IStatisticsService
    {
        ZooStatisticsDto GetStatistics();
    }
}