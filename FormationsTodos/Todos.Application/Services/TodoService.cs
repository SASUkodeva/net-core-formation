using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Contrats.CreateTodo;
using Todos.Application.Contrats.GetTodos;
using Todos.Application.Interfaces;
using Todos.Core.Entities;
using Todos.Core.Repositories;

namespace Todos.Application.Services
{
    public class TodoService : ITodosService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
        }

        public async  Task<int> CreateTodo(CreateTodoCommand command)
        {
            var todo = Todo.Create(command.Libelle, 1, 1);
            todo = todo with { TagCategories = command.TagCategorie };
            await _todoRepository.Add(todo, "1");

            return todo.Id;
        }

        public async Task<GetTodosQueryResponseModel> GetTodos(GetTodosQuery query)
        {
            var res = _todoRepository.FindAll(true)?.ToList();

            return new GetTodosQueryResponseModel 
            { 
                 Todos = res?.Select(s => new TodoModel { Id = s.Id, Title = s.Libelle, TagCategories = s.TagCategories })?.ToList()
            };
        }
    }
}
