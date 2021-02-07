using System.Collections.Generic;
using MediatR;

namespace Erebor.Service.Product.Domain.Entities.Base
{
    public class Entity
    {
        private List<INotification> _events;
        public IReadOnlyCollection<INotification> Events => _events?.AsReadOnly();

        protected void AddEvent(INotification @event)
        {
            _events ??= new List<INotification>();
            _events.Add(@event);
        }

        public void RemoveEvent(INotification @event) => _events.Remove(@event);
        public void ClearEvents() => _events.Clear();
    }
}