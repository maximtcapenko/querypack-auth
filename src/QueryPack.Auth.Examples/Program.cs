namespace QueryPack.Auth.Examples
{
    using System.Threading.Tasks;
    using Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var service = host.Services.GetRequiredService<IEntityService>();
            var result = await service.CreateAsync(Guid.NewGuid().ToString(), new EntityArg(), CancellationToken.None);

            Console.WriteLine("Hello, World!");
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {
               services.AddTransient<IEntityService, EntityService>();
               services.ConfigureAccess(regestry =>
            
                 regestry.AddContext<AccessContext>()
                         .AddPrincipalResolver<LocalPrincipalResolver>()
                         .AccessFor(new EntityAccessConfiguration()));
           });
    }
}
