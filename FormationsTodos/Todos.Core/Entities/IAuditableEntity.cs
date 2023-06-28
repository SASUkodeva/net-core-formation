using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Core.Entities
{
    public interface IAuditableEntity
    {
        DateTime UpdatedOn { get; set; }

        DateTime? DeletedOn { get; set; }

        DateTime CreatedOn { get; set; }

        [MaxLength(50)]
        string CreatedBy { get; set; }

        [MaxLength(50)]
        string UpdatedBy { get; set; }

        [MaxLength(50)]
        public string DeletedBy { get; set; }
    }
}
