using System;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Events;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    public class FeedingOrganizationService
    {
        private readonly IFeedingScheduleRepository _schedules;
        private readonly IEventDispatcher _dispatcher;
        public FeedingOrganizationService(IFeedingScheduleRepository schedules, IEventDispatcher dispatcher)
        {
            _schedules = schedules; _dispatcher = dispatcher;
        }
        public void Schedule(ScheduleFeedingDto dto)
        {
            var entity = new FeedingSchedule(Guid.NewGuid(), new AnimalId(dto.AnimalId), dto.Time, dto.FeedType);
            _schedules.Add(entity);
        }
        public void Complete(Guid scheduleId)
        {
            var entity = _schedules.GetById(scheduleId);
            entity.MarkCompleted();
            _schedules.Update(entity);
        }
        public void ProcessDue()
        {
            foreach (var s in _schedules.GetAll())
            {
                if (!s.IsCompleted && s.FeedingTime <= DateTime.UtcNow)
                {
                    _dispatcher.Publish(new FeedingTimeEvent(s.AnimalId, s.FeedingTime, s.FeedType));
                    s.MarkCompleted();
                    _schedules.Update(s);
                }
            }
        }
    }
}