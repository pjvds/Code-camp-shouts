using System;
using Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Commands
{
    [MapsToAggregateRootConstructor(typeof(Note))]
    public class CreateNewNoteCommand : CommandBase
    {
        public Guid NoteId 
        { get; set; }

        public string Text 
        { get; set; }
    }
}
