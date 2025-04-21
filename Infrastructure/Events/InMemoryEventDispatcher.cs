using System;
using Domain.Interfaces;

namespace Infrastructure.Events
{
    public class InMemoryEventDispatcher : IEventDispatcher
    {
        public event Action<object> OnEvent;
        public void Publish<T>(T @event) => OnEvent?.Invoke(@event);
    }
}