using System.Security.Principal;
using Autofac;
using Common.Logging;
using Dino;
using LunchPicker.Domain.Factories;
using LunchPicker.Domain.Repositories;
using LunchPicker.Domain.Utilities;
using LunchPicker.Infrastructure.Data;
using LunchPicker.Infrastructure.Factories;
using LunchPicker.Infrastructure.Repositories;
using LunchPicker.Infrastructure.Utilities;

namespace LunchPicker.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => LogManager.GetCurrentClassLogger()).As<ILog>();

            builder.Register(c => new EncryptionUtility()).As<IEncryptionUtility>().InstancePerLifetimeScope();

            builder.Register(c => new LunchContext())
                .As<IObjectContext>()
                .InstancePerLifetimeScope();

            builder.Register(c => UnitOfWork.Configure(config => config.WithContext<LunchContext>(c.Resolve<IObjectContext>())).Initialize())
                .As<ISession>().As<IObjectContextProvider>()
                .InstancePerLifetimeScope();

            builder.Register(c => new RestaurantRepository(c.Resolve<IObjectContextProvider>()))
                .As<IRestaurantRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new StateRepository(c.Resolve<IObjectContextProvider>()))
                .As<IStateRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new UserRepository(c.Resolve<IObjectContextProvider>()))
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CliqueRepository(c.Resolve<IObjectContextProvider>()))
                .As<ICliqueRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CreateStates(c.Resolve<IPrincipal>()))
                   .As<ICreateStates>()
                   .InstancePerLifetimeScope();
        }
    }
}
