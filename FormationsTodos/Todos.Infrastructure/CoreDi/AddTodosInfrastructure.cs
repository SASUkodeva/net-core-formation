using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Infrastructure.CoreDi
{
    public static class AddTodosInfrastructure
    {

        public static IServiceCollection AddTodosInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            return services;
        }
    }

}
