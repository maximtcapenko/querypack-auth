namespace QueryPack.Auth.Configuration
{
    /// <summary>
    /// Configures access control
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <typeparam name="TAuditable"></typeparam>
    public interface IAccessConfiguration<TContext, TAuditable> 
        where TAuditable : class
        where TContext : class, IDependencyContext
    {
        /// <summary>
        /// Configures access conponents
        /// </summary>
        /// <param name="configurator"></param>
        void Configure(IAccessConfigurator<TContext, TAuditable> configurator);
    }
}