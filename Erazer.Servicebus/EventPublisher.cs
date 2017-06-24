﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erazer.Framework.Events;
using Erazer.Web.Shared;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace Erazer.Servicebus
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IQueueClient _queueClient;

        public EventPublisher(IQueueClient queueClient)
        {
            _queueClient = queueClient;
        }
        public async Task Publish<T>(T @event) where T : class, IEvent
        {
            var jsonEvent = JsonConvert.SerializeObject(@event, DefaultJsonSerializerSettings.DefaultSettings);
            var message = new Message(Encoding.UTF8.GetBytes(jsonEvent));
            
            // Send the message to the queue
            await _queueClient.SendAsync(message);
        }

        public async Task Publish<T>(IEnumerable<T> events) where T : class, IEvent
        {
            var messages = events.Select(@event => JsonConvert.SerializeObject(@event, DefaultJsonSerializerSettings.DefaultSettings))
                    .Select(jsonEvent => new Message(Encoding.UTF8.GetBytes(jsonEvent)))
                    .ToList();

            // Send the message to the queue
            await _queueClient.SendAsync(messages);
        }

        public async Task Close()
        {
            await _queueClient.CloseAsync();
        }
    }
}
