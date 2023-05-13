namespace QueryPack.Auth.Configuration.Impl
{
    using DispatchProxy.Extensions;
    using Microsoft.Extensions.DependencyInjection;

    internal class AccessRegistrationImpl : IAccessRegistration
    {
        private readonly IServiceCollection _services;

        public AccessRegistrationImpl(IServiceCollection services)
        {
            _services = services;
        }

        public IAccessRegistration AddContext<TContext>()
            where TContext : class, IDependencyContext
        {
            _services.AddTransient<TContext>();

            return this;
        }

        public IAccessRegistration AccessFor<TContext, TAuditable>(IAccessConfiguration<TContext, TAuditable> configuration)
            where TAuditable : class
            where TContext : class, IDependencyContext
        {
            var configurator = new AccessConfiguratorImpl<TContext, TAuditable>();
            configuration.Configure(configurator);
            _services.AddInterceptorFor(configurator);

            return this;
        }

        public IAccessRegistration AddPrincipalResolver<TResolver>() 
            where TResolver : class, IPrincipalResolver
        {
            _services.AddTransient<IPrincipalResolver, TResolver>();
            
            return this;
        }
    }
}