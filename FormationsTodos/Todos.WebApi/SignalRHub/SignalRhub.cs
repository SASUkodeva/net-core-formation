using Microsoft.AspNetCore.SignalR;

namespace Todos.WebApi.SignalRHub
{
    public class SignalRhub :Hub
    {

        public override async Task OnConnectedAsync()
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, "ALL");
            await Groups.AddToGroupAsync(Context.ConnectionId,"SUPPORT");
            await base.OnConnectedAsync();
        }
    }
}
