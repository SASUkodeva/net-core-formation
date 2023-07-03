using Microsoft.AspNetCore.Mvc;
using Todos.Application.Contrats.CreateTodo;
using Todos.Application.Contrats.GetTodos;
using Todos.Application.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Todos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TodosController> _logger;
        private readonly ITodosService _service;

        public TodosController(ITodosService service)
        {

            this._service = service;
           
        }

        public ITodosService TodosService { get; }

        [HttpGet(nameof(GetTodos))]
        [ProducesResponseType(typeof(List<TodoModel>), 200)]
        public async Task<IActionResult> GetTodos()
        {
            var res = await _service.GetTodos(new Application.Contrats.GetTodos.GetTodosQuery());
            ; return Ok(res.Todos);

        }

        [HttpPost("CreateTodo")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Create([FromBody]CreateTodoCommand command)
        {

            var res = await _service.CreateTodo(command);
            return Ok(res);

        }


    }
}