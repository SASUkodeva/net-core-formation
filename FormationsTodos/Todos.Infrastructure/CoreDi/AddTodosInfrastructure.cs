using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Repositories;
using Todos.Core.Repositories.Base;
using Todos.Infrastructure.Data;
using Todos.Infrastructure.Repositories;
using Todos.Infrastructure.Repositories.Base;

namespace Todos.Infrastructure.CoreDi
{
    public static class AddTodosInfrastructure
    {

        public static IServiceCollection AddTodosInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseEntityFrameworkRepository<>));
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IMigrationService, MigrationService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<DataBaseContexte>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServerDatabase"))
      );

            return services;
        }

        public static IApplicationBuilder UserTodosInfrastructureMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var migrationService = scope.ServiceProvider.GetService<IMigrationService>();

                migrationService.StartMigration().GetAwaiter().GetResult();

            }

            return app;

        }
    }

}
