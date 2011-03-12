using System;
using Events;
using Ncqrs.Domain;

namespace Domain
{
    public class Note : AggregateRootMappedByConvention
    {
        private string _text;

        protected Note()
        {}

        public Note(Guid noteId, string text)
            : base(noteId)
        {
            var e = new NewNoteCreatedEvent
            {
                NoteId = noteId,
                Text = text
            };

            ApplyEvent(e);
        }

        public void ChangeText(string newText)
        {
            var e = new NoteTextChangedEvent
            {
                NoteId = EventSourceId,
                NewText = newText
            };

            ApplyEvent(e);
        }

        private void OnCreated(NewNoteCreatedEvent e)
        {
            _text = e.Text;
        }

        private void OnTextChanged(NoteTextChangedEvent e)
        {
            _text = e.NewText;
        }
    }
}
