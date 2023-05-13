namespace QueryPack.Auth.Configuration
{
    /// <summary>
    /// Registers access components
    /// </summary>
    public interface IAccessRegistration
    {
        /// <summary>
        /// Adds a default principal resolver to the DI container <see cref="IPrincipalResolver"/>
        /// </summary>
        IAccessRegistration AddPrincipalResolver<TResolver>() where TResolver : class, IPrincipalResolver;
        /// <summary>
        /// Adds a dependency context to the DI container <see cref="IDependencyContext"/>
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        IAccessRegistration AddContext<TContext>() where TContext : class, IDependencyContext;
        /// <summary>
        /// Configures interception components
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <typeparam name="TAuditable"></typeparam>
        /// <param name="configuration"></param>
        IAccessRegistration AccessFor<TContext, TAuditable>(IAccessConfiguration<TContext, TAuditable> configuration)
            where TAuditable : class
            where TContext : class, IDependencyContext;
    }
}