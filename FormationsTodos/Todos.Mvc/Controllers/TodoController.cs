using Microsoft.AspNetCore.Mvc;
using Todos.Application.Interfaces;

namespace Todos.Mvc.Controllers
{
    public class TodosController : Controller
    {
        private readonly ITodosService _service;

        public TodosController(ITodosService service)
        {
        
            this._service = service;
        }

        public ITodosService TodosService { get; }

        public async Task<IActionResult> Index()
        {
            var res= await _service.GetTodos(new Application.Contrats.GetTodos.GetTodosQuery());
;            return View(res.Todos);

        }

        public async Task<IActionResult> Create()
        {
            
            var res = await _service.CreateTodo(new Application.Contrats.CreateTodo.CreateTodoCommand
            {
                Libelle   = "Libelel",
                TagCategorie = new string[] { "TAG" }
            }) ;
            return Ok();

        }
    }
}
