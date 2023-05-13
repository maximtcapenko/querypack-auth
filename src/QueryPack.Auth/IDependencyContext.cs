using System.Security.Principal;

namespace QueryPack.Auth
{
    /// <summary>
    /// Contains dependencies what should be injected in runtime
    /// </summary>
    public interface IDependencyContext
    {
        /// <summary>
        /// The instance of <see cref="IPrincipal"/> what should be injectd
        /// </summary>
        IPrincipalResolver PrincipalResolver { get; }
    }
}
