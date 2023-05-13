namespace QueryPack.Auth
{
    using System.Security.Principal;

    /// <summary>
    /// Principal Resolver
    /// </summary>
    public interface IPrincipalResolver
    {
        /// <summary>
        /// Resolves current principal
        /// </summary>
        IPrincipal Resolve();
    }
}