using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Contrats.GetTodos;
using Todos.Application.Interfaces;
using Todos.Core.Repositories;

namespace Todos.Application.Services
{
    internal class TodoService : ITodosService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
        }
        public Task<GetTodosQueryResponseModel> GetTodos(GetTodosQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
