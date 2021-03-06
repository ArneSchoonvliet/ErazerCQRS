﻿using Erazer.DAL.ReadModel.Base;
using Erazer.Services.Queries.DTOs;
using MongoDB.Bson.Serialization;

namespace Erazer.DAL.ReadModel.ClassMaps
{
    public class TicketEventClassMap : MongoDbClassMap<TicketEventDto>
    {
        public override void Map(BsonClassMap<TicketEventDto> cm)
        {
            cm.MapIdProperty(x => x.Id);

            cm.MapProperty(x => x.TicketId).SetElementName("ticketId");
            cm.MapProperty(x => x.Created).SetElementName("created");
            cm.MapProperty(x => x.Event).SetElementName("event");
            cm.MapProperty(x => x.UserId).SetElementName("userId");
        }
    }
}
