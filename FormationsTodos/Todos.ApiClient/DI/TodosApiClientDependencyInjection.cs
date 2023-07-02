using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.ApiClient.Models;

namespace Todos.ApiClient.DI
{
    public static  class TodosApiClientDependencyInjection
    {

        public static IServiceCollection AddTodosApiClient(this IServiceCollection services, string baseUrl) {

           
                services.AddScoped<IClient, Client>();
                services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri(baseUrl));
                return services;
           
        
        }
    }
}
