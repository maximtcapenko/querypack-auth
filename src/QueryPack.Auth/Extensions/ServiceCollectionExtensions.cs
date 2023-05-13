namespace QueryPack.Auth.Extensions
{
    using System;
    using System.Linq;
    using Configuration;
    using Configuration.Impl;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Service collection extensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds access control components to the DI container
        /// </summary>
        /// <param name="self"></param>
        /// <param name="registrationBuilder"></param>
        public static IServiceCollection ConfigureAccess(this IServiceCollection self,
            Action<IAccessRegistration> registrationBuilder)
        {
            var registration = new AccessRegistrationImpl(self);
            registrationBuilder(registration);
            ValidateRegestry(self);

            return self;
        }

        private static void ValidateRegestry(IServiceCollection services)
        {
            // Check if IDependencyContext is registered
            var dependencyContext = services.FirstOrDefault(e => e.ServiceType.GetInterface(nameof(IDependencyContext)) != null);
            if(dependencyContext == null)
                throw new ArgumentNullException(nameof(IDependencyContext));

            // Check if IPrincipalResolver is registered
             var principalResolver = services.FirstOrDefault(e => e.ServiceType == typeof(IPrincipalResolver));
            if(principalResolver == null)
                throw new ArgumentNullException(nameof(IPrincipalResolver));
        }
    }
}