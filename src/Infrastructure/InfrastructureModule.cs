using Autofac;
using Common.Logging;
using Dino;
using LunchPicker.Domain.Repositories;
using LunchPicker.Domain.Utilities;
using LunchPicker.Infrastructure.Data;
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

            builder.Register(c => new LunchRepository(c.Resolve<IObjectContextProvider>()))
                .As<ILunchRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new AccountRepository(c.Resolve<IObjectContextProvider>()))
                .As<IAccountRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
