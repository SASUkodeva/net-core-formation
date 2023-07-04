using Microsoft.AspNetCore.Mvc;

namespace Todos.Mvc.ViewComponents
{
    public class UserComponent :ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(id);
        }
    }
}
