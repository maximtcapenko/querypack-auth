namespace QueryPack.Auth.Extensions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using DispatchProxy;
    using Internal;

    /// <summary>
    /// Interceptor Builder Extensions
    /// </summary>
    public static class InterceptorBuilderExtensions
    {
        /// <summary>
        /// Checks whether the user is authenticated before calling the target method
        /// </summary>
        public static IInterceptorBuilder<TContext, TTarget> IsAuthenticated<TContext, TTarget>(
            this IInterceptorBuilder<TContext, TTarget> self, Expression<Func<TTarget, Delegate>> inputMethod)
         where TContext : class, IDependencyContext
         where TTarget : class
        {
            var inputMethodInfo = MethodInfoResolver.Resolve<TTarget>(inputMethod);
            var inputParameters = inputMethodInfo.GetParameters().Select(e => Expression.Parameter(e.ParameterType));
            var genericArgTypes = inputMethod.Parameters.Concat(inputParameters).Select(e => e.Type)
                                                        .Concat(new[] { inputMethodInfo.ReturnParameter.ParameterType });

            var callExpression = Expression.Call(inputMethod.Parameters.First(), inputMethodInfo, inputParameters);
            var callLambda = Expression.Lambda(callExpression, inputParameters);
            var lambda = Expression.Lambda(callLambda, Expression.Parameter(genericArgTypes.First()));

            // Find and prepare registeration method
            var onMethodExecutingGenericParameters = inputMethodInfo.GetParameters().Select(e => e.ParameterType)
                                                                    .Concat(new[] { inputMethodInfo.ReturnParameter.ParameterType });
            var onMethodExecuting = self.GetType().GetMethods()
                .FirstOrDefault(e => e.Name == nameof(IInterceptorBuilder<TContext, TTarget>.OnMethodExecuting) && e.GetGenericArguments().Count() == onMethodExecutingGenericParameters.Count());
            var onMethodExecutingGeneric = onMethodExecuting.MakeGenericMethod(onMethodExecutingGenericParameters.ToArray());
            // Find and prepare handler method
            var isAuthenticatedGenericArgs = new Type[] { typeof(TContext) }.Concat(genericArgTypes);
            var isAuthenticated = typeof(AccessHelpers).GetMethods()
                .FirstOrDefault(e => e.Name == nameof(AccessHelpers.IsAuthenticated) && e.GetGenericArguments().Count() == isAuthenticatedGenericArgs.Count());
            var isAuthenticatedGeneric = isAuthenticated.MakeGenericMethod(isAuthenticatedGenericArgs.ToArray());
            // Prepare handler params
            var invoker = typeof(IMethodInvoker<>).MakeGenericType(inputMethodInfo.ReturnType);
            var isAuthenticatedGenericArgsList = isAuthenticatedGenericArgs.ToList();
            isAuthenticatedGenericArgsList.Insert(isAuthenticatedGenericArgsList.Count() - 1, invoker);

            var isAuthenticatedGenericFunc = GetDelegateType(isAuthenticatedGenericArgsList.Count()).MakeGenericType(isAuthenticatedGenericArgsList.ToArray());
            var isAuthenticatedGenericDelegate = isAuthenticatedGeneric.CreateDelegate(isAuthenticatedGenericFunc);
            onMethodExecutingGeneric.Invoke(self, new object[] { lambda, isAuthenticatedGenericDelegate });

            return self;
        }

        private static Type GetDelegateType(int args)
        => args switch
        {
            1 => typeof(Func<>),
            2 => typeof(Func<,>),
            3 => typeof(Func<,,>),
            4 => typeof(Func<,,,>),
            5 => typeof(Func<,,,,>),
            6 => typeof(Func<,,,,,>),
            7 => typeof(Func<,,,,,,>),
            8 => typeof(Func<,,,,,,,>),
            9 => typeof(Func<,,,,,,,,>),
            10 => typeof(Func<,,,,,,,,,>),
            11 => typeof(Func<,,,,,,,,,,>),
            12 => typeof(Func<,,,,,,,,,,,>),
            13 => typeof(Func<,,,,,,,,,,,,>),
            _ => throw new NotSupportedException()
        };
    }
}