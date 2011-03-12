using System;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Website
{
    public static class Bootstrapper
    {
        public static void Boot()
        {
            NcqrsEnvironment.SetDefault<ICommandService>(CreateCommandService());
            NcqrsEnvironment.SetDefault<IEventStore>(CreateEventStore());
            NcqrsEnvironment.SetDefault<IEventBus>(CreateEventBus());
        }

        private static ICommandService CreateCommandService()
        {
            var service = new CommandService();

            return service;
        }

        private static IEventStore CreateEventStore()
        {
            var store = new MsSqlServerEventStore(@"Server=.\SQLEXPRESS;Database=EventStore;Trusted_Connection=True;");
            return store;
        }

        private static IEventBus CreateEventBus()
        {
            var bus = new InProcessEventBus(true);

            return bus;
        }
    }
}