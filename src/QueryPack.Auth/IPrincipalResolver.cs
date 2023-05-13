namespace QueryPack.Auth
{
    using System.Security.Principal;

    public interface IPrincipalResolver
    {
        IPrincipal Resolve();
    }
}