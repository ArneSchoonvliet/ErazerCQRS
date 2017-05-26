﻿using System;
using Erazer.DAL.Constants;
using Erazer.Domain.Constants;
using Erazer.Domain.Events;
using Erazer.Framework.Domain;

namespace Erazer.Domain
{
    public class Ticket : AggregateRoot
    {
        private string _title;
        private string _description;
        private int _priorityId;
        private int _statusId;

        private const int DefaultPriorityId = PriorityConstants.Medium;
        private const int DefaultStatusId = StatusConstants.Backlog;

        #region Constructors
        public Ticket(Guid id, string title, string description) : this(id, title, description, DefaultPriorityId, DefaultStatusId)
        {

        }

        private Ticket(Guid id, string title, string description, int priorityId, int statusId) 
        {
            Id = id;
            _title = title;
            _description = description;
            _priorityId = priorityId;
            _statusId = statusId;

            // TODO Write code to save 'new ticket'
        }
        #endregion

        public void AddComment(string comment, Guid commenterId)
        {
            ApplyChange(new TicketCommentEvent
            {
                Comment = comment,
                UserId = commenterId
            });
        }

        public void UpdatePriority(int priorityId, Guid userId)
        {
            var currentPriority = _priorityId;
            _priorityId = priorityId;

            ApplyChange(new TicketPriorityEvent
            {
                FromPriorityId = currentPriority,
                ToPriorityId = priorityId,
                UserId = userId
            });
        }
    }
}