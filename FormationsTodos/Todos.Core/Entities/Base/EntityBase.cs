using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Core.Entities.Base
{
    public abstract record  EntityBase {

        [Key]
        public int Id { get; init; } 
    }

}
