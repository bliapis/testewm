using WM.Domain.Core.Events;

namespace WM.Domain.Core.Bus
{
    public interface IBus
    {
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}