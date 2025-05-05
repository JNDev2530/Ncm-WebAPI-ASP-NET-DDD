using NcmAPI.Domain.Interfaces;
using NcmAPI.Infrastructure.Repositories;

namespace NcmAPI.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IOldNcmRepository, OldNcmRepository>();
            services.AddScoped<INewNcmRepository, NewNcmRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
