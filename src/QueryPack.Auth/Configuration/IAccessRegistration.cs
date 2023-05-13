namespace QueryPack.Auth.Configuration
{
    /// <summary>
    /// Registers audit components
    /// </summary>
    public interface IAccessRegistration
    {
        IAccessRegistration AddPrincipalResolver<TResolver>() where TResolver : class, IPrincipalResolver;
        /// <summary>
        /// Registers dependency context <see cref="IDependencyContext"/>
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        IAccessRegistration AddContext<TContext>() where TContext : class, IDependencyContext;
        /// <summary>
        /// Configures interception logic
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <typeparam name="TAuditable"></typeparam>
        /// <param name="configuration"></param>
        IAccessRegistration AccessFor<TContext, TAuditable>(IAccessConfiguration<TContext, TAuditable> configuration)
            where TAuditable : class
            where TContext : class, IDependencyContext;
    }
}