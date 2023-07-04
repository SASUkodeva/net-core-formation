using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Contrats.CreateTodo;
using Todos.Application.Contrats.CreateUser;
using Todos.Application.Contrats.GetTodos;
using Todos.Application.Contrats.GetUsers;

namespace Todos.Application.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Récupération de la liste des utilisateurs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetUsersResponse> GetUsers(GetUserQuery query);

        /// <summary>
        /// Récupération de la liste des utilisateurs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<CreateUserResponse> CreateUser(CreateUserCommand command);

        Task UpdateUser(int id, UpdateUserCommand command);
    }
}
