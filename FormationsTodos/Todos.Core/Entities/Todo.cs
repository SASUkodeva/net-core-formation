using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Entities.Base;

namespace Todos.Core.Entities
{
    public record Todo(int Id,string Libelle, int Statut) : EntityBase(Id) { }
  
    
}
