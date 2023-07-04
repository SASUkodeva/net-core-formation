using Microsoft.Extensions.DependencyInjection;
using Todos.Application.Interfaces;
using Todos.Application.Services;

namespace Todos.Application.ApplicationDI
{
    public static class AddTodosApplication
    {

        public static IServiceCollection AddTodosApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITodosService, TodoService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
