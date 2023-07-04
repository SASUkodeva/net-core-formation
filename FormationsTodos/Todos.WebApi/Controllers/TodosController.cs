using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Todos.Application.Contrats.CreateTodo;
using Todos.Application.Contrats.GetTodos;
using Todos.Application.Interfaces;
using Todos.WebApi.SignalRHub;
using static System.Net.Mime.MediaTypeNames;

namespace Todos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
       

        private readonly ITodosService _service;

        //Hub SignalR 
        private readonly IHubContext<SignalRhub> _hub;
        public TodosController(ITodosService service, IHubContext<SignalRhub> hub)
        {

            this._service = service;
            _hub = hub;
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
        public async Task<IActionResult> Create([FromBody] CreateTodoCommand command)
        {

            var res = await _service.CreateTodo(command);
            await  _hub.Clients.Groups("ALL").SendAsync("tupeuxrefresh");
            return Ok(res);

        }


        [HttpPost("UpdateTodo/{id}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] CreateTodoCommand command)
        {

            var res = await _service.CreateTodo(command);
            return Ok(res);

        }


    }
}
