using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Entities.Base;

namespace Todos.Core.Entities
{
    public record Todo : EntityBase {

        public static Todo Create(string libelle, int statut, int userId)
        {
            var todo= new Todo { Libelle = libelle, Statut = statut, UserId = userId }; ;


            return todo;
        }

        public string Libelle { get; init; }

        public int Statut { get; set; }

        public int UserId { get; set; }
        public String[] TagCategories { get; set; }
        public virtual User User  {get;set;}


    }
  
    
}
