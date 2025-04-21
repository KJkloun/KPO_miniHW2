using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFeedingScheduleRepository
    {
        FeedingSchedule GetById(Guid id);
        IEnumerable<FeedingSchedule> GetAll();
        void Add(FeedingSchedule schedule);
        void Update(FeedingSchedule schedule);
    }
}