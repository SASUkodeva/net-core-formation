using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Contrats.GetTodos
{
    public class GetTodosQueryResponseModel
    {

        public List<TodoModel> Todos { get; set; }
    }

    public class TodoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
