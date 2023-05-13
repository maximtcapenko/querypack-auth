namespace QueryPack.Auth.Examples
{
    using Configuration;
    using Extensions;

    class EntityAccessConfiguration : IAccessConfiguration<AccessContext, IEntityService>
    {
        public void Configure(IAccessConfigurator<AccessContext, IEntityService> configurator)
        {
            configurator.Add(builder
                => builder.IsAuthenticated(e => e.CreateAsync)
                          .IsAuthenticated(e => e.UpdateAsync));
        }
    }
}