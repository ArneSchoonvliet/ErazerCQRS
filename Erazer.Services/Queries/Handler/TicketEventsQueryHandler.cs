﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Erazer.Services.Queries.Repositories;
using Erazer.Services.Queries.Requests;
using Erazer.Services.Queries.ViewModels;
using MediatR;

namespace Erazer.Services.Queries.Handler
{
    public class TicketEventsQueryHandler : IAsyncRequestHandler<TicketEventsQuery, List<TicketEventViewModel>>
    {
        private readonly ITicketEventQueryRepository _repository;
        private readonly IMapper _mapper;

        public TicketEventsQueryHandler(ITicketEventQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TicketEventViewModel>> Handle(TicketEventsQuery message)
        {
            var ticketEvents =  await _repository.Find(message.TicketId);
            return _mapper.Map<List<TicketEventViewModel>>(ticketEvents);
        }
    }
}
