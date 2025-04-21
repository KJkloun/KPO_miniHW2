namespace Domain.Interfaces
{
    public interface IEventDispatcher
    {
        void Publish<T>(T @event);
    }
}