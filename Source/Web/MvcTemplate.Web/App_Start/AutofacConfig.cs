namespace MvcTemplate.Web
{
    using System.Diagnostics;
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder
                .Register(x => new Service())
                .As<IService>()
                .InstancePerRequest();
        }
    }

#pragma warning disable SA1201 // Elements must appear in the correct order
    public interface IService
#pragma warning restore SA1201 // Elements must appear in the correct order
    {
        void Work();
    }

#pragma warning disable SA1402 // File may only contain a single class
    public class Service : IService
#pragma warning restore SA1402 // File may only contain a single class
    {
        public void Work()
        {
            Trace.WriteLine("I am working...");
        }
    }
}
