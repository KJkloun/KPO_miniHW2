using System;
using Domain.ValueObjects;

namespace Domain.Events
{
    public class FeedingTimeEvent
    {
        public AnimalId AnimalId { get; }
        public DateTime Time { get; }
        public FeedType FeedType { get; }
        public FeedingTimeEvent(AnimalId animalId, DateTime time, FeedType feedType)
        {
            AnimalId = animalId; Time = time; FeedType = feedType;
        }
    }
}