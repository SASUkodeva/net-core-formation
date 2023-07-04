using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Contrats.CreateUser
{
    /// <summary>
    /// Command permettant de créer un utilisateur
    /// </summary>
    public class UpdateUserCommand
    {
        public String Nom { get; set; }

        public String Prenom { get; set; }
    }
}
