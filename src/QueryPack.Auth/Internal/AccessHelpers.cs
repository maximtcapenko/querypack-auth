namespace QueryPack.Auth.Internal
{
    using DispatchProxy;

    internal static class AccessHelpers
    {
        private static TOut Handle<TContext, TOut>(TContext ctx, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext
        {
            var principal = ctx.PrincipalResolver.Resolve();
            if (!principal.Identity.IsAuthenticated)
            {
                throw new System.MethodAccessException();
            }
            return invoker.Invoke();
        }

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TOut>(TContext ctx, TTarget target, TIn1 t1, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, TIn5 t5, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, TIn5 t5, TIn6 t6, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, TIn5 t5, TIn6 t6, TIn7 t7, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, TIn5 t5, TIn6 t6, TIn7 t7, TIn8 t8, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, TIn5 t5, TIn6 t6, TIn7 t7, TIn8 t8, TIn9 t9, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, TIn5 t5, TIn6 t6, TIn7 t7, TIn8 t8, TIn9 t9, TIn10 t10, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, TIn5 t5, TIn6 t6, TIn7 t7, TIn8 t8, TIn9 t9, TIn10 t10, TIn11 t11, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, TIn5 t5, TIn6 t6, TIn7 t7, TIn8 t8, TIn9 t9, TIn10 t10, TIn11 t11, TIn12 t12, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);

        public static TOut IsAuthenticated<TContext, TTarget, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>(TContext ctx, TTarget target, TIn1 t1, TIn2 t2, TIn3 t3, TIn4 t4, TIn5 t5, TIn6 t6, TIn7 t7, TIn8 t8, TIn9 t9, TIn10 t10, TIn11 t11, TIn12 t12, TIn13 t13, IMethodInvoker<TOut> invoker)
            where TContext : IDependencyContext => Handle(ctx, invoker);
    }
}