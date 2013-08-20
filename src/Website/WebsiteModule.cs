using System.Security.Principal;
using System.Web;
using Autofac;
using LunchPicker.Domain;
using LunchPicker.Infrastructure;

namespace LunchPicker.Web
{
    public class WebsiteModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => HttpContext.Current.User).As<IPrincipal>().ExternallyOwned().InstancePerLifetimeScope();

            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new DomainModule());
        }
    }
}