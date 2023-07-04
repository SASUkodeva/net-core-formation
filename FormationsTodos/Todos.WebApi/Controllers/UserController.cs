using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Todos.Application.Contrats.CreateTodo;
using Todos.Application.Contrats.CreateUser;
using Todos.Application.Contrats.GetTodos;
using Todos.Application.Contrats.GetUsers;
using Todos.Application.Interfaces;
using Todos.WebApi.SignalRHub;
using static System.Net.Mime.MediaTypeNames;

namespace Todos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {



        private readonly IUserService _service;
        private readonly IHubContext<SignalRhub> _hub;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, IHubContext<SignalRhub> hub, ILogger<UserController> logger)
        {

            this._service = service;
            _hub = hub;
            _logger = logger;
        }



        [HttpGet(nameof(GetTodos))]
        [ProducesResponseType(typeof(List<UserModel>), 200)]
        public async Task<IActionResult> GetTodos()
        {
            var res = await _service.GetUsers(new Application.Contrats.GetUsers.GetUserQuery());
            ; return Ok(res.Users);

        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {

            var res = await _service.CreateUser(command);
            await _hub.Clients.Groups("ALL").SendAsync("UserCreated");
            return Ok(res);

        }


        [HttpPost("UpdateTodo/{id}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserCommand command)
        {
            await _service.UpdateUser(id, command);
            return Ok();

        }


    }
}
