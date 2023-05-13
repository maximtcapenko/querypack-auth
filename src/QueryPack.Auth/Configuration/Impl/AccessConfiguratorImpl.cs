namespace QueryPack.Auth.Configuration.Impl
{
    using System;
    using System.Collections.Generic;
    using DispatchProxy;

    internal class AccessConfiguratorImpl<TContext, TAuditable> : IAccessConfigurator<TContext, TAuditable>,
        InterceptorProxyFactoryBuilder<TContext, TAuditable>
        where TAuditable : class
        where TContext : class, IDependencyContext
    {
        private readonly List<Action<IInterceptorBuilder<TContext, TAuditable>>> _interceptorBuilders = new List<Action<IInterceptorBuilder<TContext, TAuditable>>>();

        public IAccessConfigurator<TContext, TAuditable> Add(Action<IInterceptorBuilder<TContext, TAuditable>> interceptorBuilder)
        {
            _interceptorBuilders.Add(interceptorBuilder);
            return this;
        }

        public void AddInterceptor(IInterceptorBuilder<TContext, TAuditable> interceptorBuilder)
        {
            foreach(var builder in _interceptorBuilders)
                builder.Invoke(interceptorBuilder);
        }
    }
}