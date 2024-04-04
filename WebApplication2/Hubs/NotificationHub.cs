using Microsoft.AspNetCore.SignalR;

namespace EmployeeManagement.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendEmployeeAddedNotification()
        {
            await Clients.All.SendAsync("EmployeeAdded");
        }
    }
}
