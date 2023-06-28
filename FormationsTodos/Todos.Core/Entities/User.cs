using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Entities.Base;

namespace Todos.Core.Entities
{
    internal record User(int id, string Nom, string Prenom) : EntityBase(id)
    {
    }
}
