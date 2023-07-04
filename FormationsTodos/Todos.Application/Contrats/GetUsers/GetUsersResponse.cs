using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Contrats.GetUsers
{
    public class GetUsersResponse
    {
        public List<UserModel> Users { get; set; }  

    }

    public class UserModel
    {
        public String Nom { get; set; }
        public String Prenom { get; set; }
    }
}
