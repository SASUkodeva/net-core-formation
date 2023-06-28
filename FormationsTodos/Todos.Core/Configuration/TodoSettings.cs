using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Core.Configuration
{
    internal class TodoSettings
    {

        public List<CategorieTodo> Categories { get; set; } = new List<CategorieTodo>();
    }

    public class CategorieTodo
    {
        public string Key { get; set; } = default!;

        public string Libelle { get; set; } = default!;

        public string Color { get; set; } = default!;
    }
}
