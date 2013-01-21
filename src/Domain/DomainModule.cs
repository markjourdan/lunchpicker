using Autofac;

namespace LunchPicker.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new Clock()).As<IClock>();
        }
    }
}