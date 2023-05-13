namespace QueryPack.Auth.Extensions
{
    using System;
    using Configuration;
    using Configuration.Impl;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Service collection extensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add access components to DI container
        /// </summary>
        /// <param name="self"></param>
        /// <param name="registrationBuilder"></param>
        public static IServiceCollection ConfigureAccess(this IServiceCollection self,
            Action<IAccessRegistration> registrationBuilder)
        {
            var registration = new AccessRegistrationImpl(self);
            registrationBuilder(registration);

            return self;
        }
    }
}