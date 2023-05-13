using System.Security.Principal;

namespace QueryPack.Auth.Examples
{
    class EntityResult
    {
        public string Id { get; set; }
    }

    class EntityArg { }

    class AccessContext : IDependencyContext
    {
        public AccessContext(IPrincipalResolver principalResolver)
        {   
            PrincipalResolver = principalResolver;
        }

        public IPrincipalResolver PrincipalResolver { get; }
    }
}