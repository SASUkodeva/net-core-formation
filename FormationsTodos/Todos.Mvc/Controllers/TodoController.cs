using Microsoft.AspNetCore.Mvc;
using Todos.Application.Interfaces;

namespace Todos.Mvc.Controllers
{
    public class TodoController : Controller
    {
        public TodoController(ITodosService todosService)
        {
            TodosService = todosService;
        }

        public ITodosService TodosService { get; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
