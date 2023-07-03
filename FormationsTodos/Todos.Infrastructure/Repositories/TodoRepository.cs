using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Entities;
using Todos.Core.Repositories;
using Todos.Infrastructure.Data;
using Todos.Infrastructure.Repositories.Base;

namespace Todos.Infrastructure.Repositories
{
    internal class TodoRepository : BaseEntityFrameworkRepository<Todo>, ITodoRepository
    {
        public TodoRepository(DataBaseContexte dbContext) : base(dbContext)
        {
        }

    }
}
