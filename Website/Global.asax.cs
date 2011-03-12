using System;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;

namespace Website
{
    public class WebsiteApplication : MvcApplication
    {
        public static ICommandService CommandService { get { return NcqrsEnvironment.Get<ICommandService>(); } }

        protected void Application_Start()
        {
            Bootstrapper.Boot();
        }
    }
}