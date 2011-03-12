using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Commands;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;
using Ncqrs.Eventing.ServiceModel.Bus;
using ReadModel.Denormalizers;

namespace Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebsiteApplication : System.Web.HttpApplication
    {
        public static ICommandService CommandService { get { return NcqrsEnvironment.Get<ICommandService>(); } }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            NcqrsEnvironment.SetDefault<ICommandService>(CreateCommandService());
            NcqrsEnvironment.SetDefault<IEventStore>(CreateEventStore());
            NcqrsEnvironment.SetDefault<IEventBus>(CreateEventBus());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected ICommandService CreateCommandService()
        {
            var service = new CommandService();
            service.RegisterExecutorsInAssembly(typeof(CreateNewNoteCommand).Assembly);

            return service;
        }

        protected IEventStore CreateEventStore()
        {
            var store = new MsSqlServerEventStore(@"Server=.\SQLEXPRESS;Database=EventStore;Trusted_Connection=True;");
            return store;
        }

        protected IEventBus CreateEventBus()
        {
            var bus = new InProcessEventBus(true);
            bus.RegisterAllHandlersInAssembly(typeof(NoteDenormalizer).Assembly);

            return bus;
        }
    }
}