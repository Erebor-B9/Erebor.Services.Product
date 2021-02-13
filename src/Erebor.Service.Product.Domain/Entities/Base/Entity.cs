using System;
using System.Collections.Generic;
using Erebor.Service.Product.Domain.Events;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;

namespace Erebor.Service.Product.Domain.Entities.Base
{
    public class Entity
    {
        [BsonId] public string Id { get;  set; } = Guid.NewGuid().ToString();
        private List<INotificationEvent> _events;
        protected IReadOnlyCollection<INotificationEvent> Events => _events?.AsReadOnly();

        protected void AddEvent(INotificationEvent @event)
        {
            _events ??= new List<INotificationEvent>();
            _events.Add(@event);
        }

        public void RemoveEvent(INotificationEvent @event) => _events.Remove(@event);
        public void ClearEvents() => _events.Clear();
    }
}