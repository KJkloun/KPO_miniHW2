using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class FeedingSchedule
    {
        public Guid Id { get; }
        public AnimalId AnimalId { get; }
        public DateTime FeedingTime { get; private set; }
        public FeedType FeedType { get; private set; }
        public bool IsCompleted { get; private set; }
        public FeedingSchedule(Guid id, AnimalId animalId, DateTime feedingTime, FeedType feedType)
        {
            if (feedingTime < DateTime.UtcNow) throw new ArgumentOutOfRangeException(nameof(feedingTime));
            Id = id; AnimalId = animalId; FeedingTime = feedingTime; FeedType = feedType; IsCompleted = false;
        }
        public void Reschedule(DateTime newTime)
        {
            if (newTime < DateTime.UtcNow) throw new ArgumentOutOfRangeException(nameof(newTime));
            FeedingTime = newTime;
        }
        public void MarkCompleted() => IsCompleted = true;
    }
}