using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Core.Entities
{
    public class AuditableEntity : IAuditableEntity
    {
        public DateTime UpdatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        [MaxLength(50)]
        public string UpdatedBy { get; set; }

        [MaxLength(50)]
        public string? DeletedBy { get; set; } = null;

        public DateTime CreatedOn { get; set; }
    }
}
