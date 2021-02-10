using System.Collections.Generic;
using Erebor.Service.Product.Domain.Events;
using MediatR;

namespace Erebor.Service.Product.Domain.Entities.Base
{
    public class Entity
    {
        private List<INotificationEvent> _events;
        public IReadOnlyCollection<INotificationEvent> Events => _events?.AsReadOnly();

        protected void AddEvent(INotificationEvent @event)
        {
            _events ??= new List<INotificationEvent>();
            _events.Add(@event);
        }

        public void RemoveEvent(INotificationEvent @event) => _events.Remove(@event);
        public void ClearEvents() => _events.Clear();
    }
}