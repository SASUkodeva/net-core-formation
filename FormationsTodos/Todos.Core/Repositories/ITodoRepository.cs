using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Entities;
using Todos.Core.Repositories.Base;

namespace Todos.Core.Repositories
{
    public interface ITodoRepository : IBaseRepository<Todo>
    {
    }
}
