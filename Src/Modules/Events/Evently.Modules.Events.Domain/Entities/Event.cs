using System;
using Evently.Commons.Domain.Abstractions.Entity;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Domain.Events.Event;

namespace Evently.Modules.Events.Domain.Entities;

public sealed class Event : Domain<Guid>
{
    private Event()
    {

    }

    public Guid CategoryId { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Location { get; private set; }

    public DateTime StartsAtUtc { get; private set; }

    public DateTime? EndsAtUtc { get; private set; }

    public EventStatus Status { get; private set; }

    public static Result<Event> Create(
        Guid categoryId,
        string title,
        string description,
        string location,
        DateTime startsAtUtc,
        DateTime? endsAtUtc
    )
    {
        Result<Event> result = Errors.Event.EndDatePrecedesStartDate;

        if (endsAtUtc == null || endsAtUtc > startsAtUtc)
        {
            var entity = new Event()
            {
                Id = Guid.NewGuid(),
                CategoryId = categoryId,
                Title = title,
                Description = description,
                Location = location,
                StartsAtUtc = startsAtUtc,
                EndsAtUtc = endsAtUtc,
                Status = EventStatus.Draft
            };

            entity.Raise(new EventCreatedEvent(entity.Id));

            result = entity;
        }

        return result;
    }

    public Result Publish()
    {
        Result result = Errors.Event.NotDraft;

        if (Status == EventStatus.Draft)
        {
            Status = EventStatus.Published;

            Raise(new EventPublishedEvent(Id));

            result = true;
        }

        return result;
    }

    public void Reschedule(DateTime startsAtUtc, DateTime? endsAtUtc)
    {
        if (StartsAtUtc == startsAtUtc && EndsAtUtc == endsAtUtc)
        {
            return;
        }

        StartsAtUtc = startsAtUtc;
        EndsAtUtc = endsAtUtc;

        Raise(new EventRescheduledEvent(Id, StartsAtUtc, EndsAtUtc));
    }

    public Result Cancel(DateTime utcNow)
    {
        Result result = Errors.Event.AlreadyCanceled;

        if (Status != EventStatus.Canceled )
        {
            result = Errors.Event.AlreadyStarted;

            if (StartsAtUtc > utcNow)
            {
                Status = EventStatus.Canceled;

                Raise(new EventCanceledEvent(Id));

                result = true;
            }
        }

        return result;
    }
}
