using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todos.Application.Contrats.GetTodos;
using Todos.Application.Interfaces;

namespace Todos.Mvc.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly ITodosService _todosService;

        public IndexModel(ITodosService todosService)
        {
            _todosService = todosService;
        }

        List<TodoModel> Todos { get; set; }
        public void OnGet()
        {
        }
    }
}
