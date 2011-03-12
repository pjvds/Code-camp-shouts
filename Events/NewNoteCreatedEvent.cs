using System;

namespace Events
{
    public class NewNoteCreatedEvent
    {
        public Guid NoteId { get; set; }
        public string Text { get; set; }
    }
}
