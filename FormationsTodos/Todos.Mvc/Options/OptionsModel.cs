using Microsoft.EntityFrameworkCore;

namespace Todos.Mvc.Options
{
    public class OptionsModel
    {
        public String Title { get; set; } = default!;

        public List<Categorie> Categorie { get; set;} = new List<Categorie>();   


    }

    public class Categorie
    {
        public String Key { get; set; } = default!;

        public String Label { get; set; } = default!;

    }
}
