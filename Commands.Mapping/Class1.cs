using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;

namespace Commands.Mapping
{
    public static class Mapping
    {
        public static IEnumerable<ICommandExecutor<>> Get()
        {
            Ncqrs.Commanding.CommandExecution.Mapping.Fluent.Map.Command<>().ToAggregateRoot<>().CreateNew()
            return Ncqrs.Commanding.CommandExecution.Mapping.Fluent.Map.
        }
    }
}
