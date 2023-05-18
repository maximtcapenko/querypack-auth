# QueryPack.Auth
Simple implementation of access control based on `QueryPack.DispatchProxy`

## Getting Started
1. Install the package into your project
```
dotnet add package QueryPack.Auth
```
2. Add access configuration
```c#
class EntityAccessConfiguration : IAccessConfiguration<AccessContext, IEntityService>
{
    public void Configure(IAccessConfigurator<AccessContext, IEntityService> configurator)
    {
        configurator.Add(builder
            => builder.IsAuthenticated(e => e.CreateAsync)
                      .IsAuthenticated(e => e.UpdateAsync));
    }
}
```
3. Register access configuration in `Program` 
```c#
    services.AddTransient<IEntityService, EntityService>();
    services.ConfigureAccess(registry =>
        registry.AddContext<AccessContext>()
                .AddPrincipalResolver<LocalPrincipalResolver>()
                .AccessFor(new EntityAccessConfiguration()));
```
4. Implement `IPrincipalResolver`
```c#
class LocalPrincipalResolver : IPrincipalResolver
{
    public IPrincipal Resolve()
    {
        var myIdentity = new GenericIdentity("MyIdentity");
        var myPrincipal = new GenericPrincipal(myIdentity, null);
        return myPrincipal;
    }
}
```
5. Service method call
```c#
IEntityService entitySerice;
var result = await entitySerice.CreateAsync("some_id", new EntityArg(), CancellationToken.None);
```
