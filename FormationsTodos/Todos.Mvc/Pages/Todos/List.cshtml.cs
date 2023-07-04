using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todos.Application.Contrats.GetTodos;
using Todos.Application.Interfaces;

namespace Todos.Mvc.Pages.Todos
{
    public class ListModel : PageModel
    {
        private readonly ITodosService _todosService;
        public List<TodoModel>  Todos { get; set; }
        public ListModel(ITodosService todosService)
        {
            this._todosService = todosService;
        }
        public async Task OnGet()
        {
            var todos = await _todosService.GetTodos(new GetTodosQuery());
            this.Todos = todos.Todos;
        }
    }
}
