namespace QueryPack.Auth.Configuration
{
    using System;
    using DispatchProxy;

    /// <summary>
    /// Interception configuration
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <typeparam name="TAuditable"></typeparam>
    public interface IAccessConfigurator<TContext, TAuditable> 
        where TAuditable : class 
        where TContext : class, IDependencyContext
    {
        /// <summary>
        /// Configures interception
        /// </summary>
        /// <param name="interceptorBuilder"></param>
        /// <returns></returns>
        IAccessConfigurator<TContext, TAuditable> Add(Action<IInterceptorBuilder<TContext, TAuditable>> interceptorBuilder);
    }
}