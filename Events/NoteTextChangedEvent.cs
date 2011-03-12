using System;

namespace Events
{
    public class NoteTextChangedEvent
    {
        public Guid NoteId { get; set; }
        public string NewText { get; set; }
    }
}
