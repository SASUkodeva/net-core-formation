using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Entities;
using Todos.Core.Repositories;
using Todos.Infrastructure.Data;
using Todos.Infrastructure.Repositories.Base;

namespace Todos.Infrastructure.Repositories
{
    internal class UserRepository : BaseEntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContexte dbContext) : base(dbContext)
        {
        }
    }
}
