using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public void OnGet()
        {
        }
    }
}
