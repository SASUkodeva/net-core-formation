using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Contrats.CreateTodo;
using Todos.Application.Contrats.CreateUser;
using Todos.Application.Contrats.GetUsers;
using Todos.Application.Interfaces;
using Todos.Core.Entities;
using Todos.Core.Repositories;

namespace Todos.Application.Services
{
    internal class UserService :IUserService
    {

        public IUserRepository _userRepository { get; }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserCommand command)
        {
            var usr = new User(command.Nom, command.Prenom);
            var id = await _userRepository.Add(usr, "USER");

            return new CreateUserResponse { Id = usr.Id };
        }

        public async Task<GetUsersResponse> GetUsers(GetUserQuery query)
        {
            var usrs = _userRepository.FindAll(true)?.Select(d => new UserModel { Nom = d.Nom, Prenom = d.Prenom });



            return new GetUsersResponse { Users = usrs?.ToList() };
        }

        public async Task UpdateUser(int id, UpdateUserCommand command)
        {
            var usrs = await _userRepository.FindById(id);
            usrs = usrs with { Nom = command.Nom, Prenom = command.Prenom };

        }
    }
}
