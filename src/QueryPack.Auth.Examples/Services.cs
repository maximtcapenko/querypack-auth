using System.Security.Principal;

namespace QueryPack.Auth.Examples
{
    interface IEntityService
    {
        Task<EntityResult> CreateAsync(string id, EntityArg arg, CancellationToken token);
        Task UpdateAsync(string id, EntityArg arg, CancellationToken token);
    }

    class EntityService : IEntityService
    {
        public Task<EntityResult> CreateAsync(string id, EntityArg arg, CancellationToken token)
        {
            Console.WriteLine("Executing method CreateAsync");
            return Task.FromResult(new EntityResult() { Id = id });
        }

        public Task UpdateAsync(string id, EntityArg arg, CancellationToken token)
        {
            Console.WriteLine("Executing method UpdateAsync");
            return Task.CompletedTask;
        }
    }

    class LocalPrincipalResolver : IPrincipalResolver
    {
        public IPrincipal Resolve()
        {
            var myIdentity = new GenericIdentity("MyIdentity");
             var myPrincipal =
                new GenericPrincipal(myIdentity, null);

            return myPrincipal;
        }
    }
}