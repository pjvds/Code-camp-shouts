using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Domain;

namespace Commands
{
    [MapsToAggregateRootMethod(typeof(Note), "ChangeText")]
    public class ChangeNoteTextCommand : CommandBase
    {
        [AggregateRootId]
        public Guid NoteId { get; set; }

        public string NewText { get; set; }
    }
}
