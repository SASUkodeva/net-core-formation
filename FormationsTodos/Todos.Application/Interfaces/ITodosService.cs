using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Contrats.CreateTodo;
using Todos.Application.Contrats.GetTodos;

namespace Todos.Application.Interfaces
{
    public interface ITodosService
    {
        Task<GetTodosQueryResponseModel> GetTodos(GetTodosQuery query);

        Task<int> CreateTodo(CreateTodoCommand command);
    }
}
