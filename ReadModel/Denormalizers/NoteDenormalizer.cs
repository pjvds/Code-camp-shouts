using System;
using System.Linq;
using Events;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace ReadModel.Denormalizers
{
    public class NoteDenormalizer : IEventHandler<NewNoteCreatedEvent>, IEventHandler<NoteTextChangedEvent>
    {
        public void Handle(IPublishedEvent<NewNoteCreatedEvent> evnt)
        {
            using(var context = new ReadModelDataContext())
            {
                var newNote = new NoteItem
                {
                    Id = evnt.Payload.NoteId,
                    Text = evnt.Payload.Text,
                    CreationDate = evnt.EventTimeStamp
                };

                context.NoteItems.InsertOnSubmit(newNote);
                context.SubmitChanges();
            }
        }

        public void Handle(IPublishedEvent<NoteTextChangedEvent> evnt)
        {
            using(var context = new ReadModelDataContext())
            {
                var note = context.NoteItems.Single(e => e.Id == evnt.Payload.NoteId);
                note.Text = evnt.Payload.NewText;

                context.SubmitChanges();
            }
        }
    }
}
