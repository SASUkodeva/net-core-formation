using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Contrats.CreateTodo
{
    internal class CreateTodoCommand
    {
        public String Title { get; set; }

        public String[] TagCategorie {get;set;}
    }
}
