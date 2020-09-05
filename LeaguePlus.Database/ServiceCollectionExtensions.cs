using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LeaguePlus.Core;

namespace LeaguePlus.Database
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseStore(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(connectionString)
            );

            service.AddSingleton<IDatabase, SqlDatabase>();

            return service;
        }
    }
}
