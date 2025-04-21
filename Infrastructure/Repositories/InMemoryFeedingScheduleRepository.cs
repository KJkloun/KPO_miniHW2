using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly List<FeedingSchedule> _store = new();
        public FeedingSchedule GetById(Guid id) => _store.Single(s => s.Id == id);
        public IEnumerable<FeedingSchedule> GetAll() => _store;
        public void Add(FeedingSchedule schedule) => _store.Add(schedule);
        public void Update(FeedingSchedule schedule)
        {
            var idx = _store.FindIndex(s => s.Id == schedule.Id);
            if (idx >= 0) _store[idx] = schedule;
        }
    }
}