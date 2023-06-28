using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Entities.Base;

namespace Todos.Core.Entities
{
    public record Todos(int Id,string Libelle) : EntityBase(Id) { }
  
    
}
