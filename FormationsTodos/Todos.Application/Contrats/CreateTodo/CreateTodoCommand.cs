using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Contrats.CreateTodo
{
    /// <summary>
    /// Command permettant de créer un todo
    /// </summary>
    public class CreateTodoCommand
    {
        public String Libelle { get; set; }

        public int Statut { get; set; }
        public String[] TagCategorie {get;set;}
    }
}
