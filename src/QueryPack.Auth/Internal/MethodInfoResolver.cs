namespace QueryPack.Auth.Internal
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    internal class MethodInfoResolver : ExpressionVisitor
    {
        private MethodInfo _methodInfo;
        private MethodCallExpression _expression;
        private readonly Type _declaringType;

        public MethodInfoResolver(Type declaringType)
        {
            _declaringType = declaringType;
        }

        public MethodInfo Resolve(Expression method)
        {
            Visit(method);
            return _methodInfo;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            return base.VisitUnary(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            var t = node.Value.GetType();
            if (node.Value is MethodInfo del)
            {
                if (del.DeclaringType == _declaringType)
                {
                    _methodInfo = del;
                }
            }
            return base.VisitConstant(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var m = node.Method;
            if (node.Method.DeclaringType == _declaringType)
            {
                _methodInfo = node.Method;
            }
            else
            {
                Visit(node.Object);

            }

            return base.VisitMethodCall(node);
        }
    }
}