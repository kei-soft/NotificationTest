using Microsoft.AspNetCore.SignalR;

namespace NotificationTest
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationToAll(string title, string message, string type = "info")
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", title, message, type);
        }

        public async Task SendNotificationToUser(string userId, string title, string message, string type = "info")
        {
            await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", title, message, type);
        }

        public async Task SendNotificationToGroup(string groupName, string title, string message, string type = "info")
        {
            await _hubContext.Clients.Group(groupName).SendAsync("ReceiveNotification", title, message, type);
        }

        public async Task SendPopupToAll(string title, string message, string type = "info")
        {
            await _hubContext.Clients.All.SendAsync("ReceivePopup", title, message, type);
        }

        public async Task SendPopupToUser(string userId, string title, string message, string type = "info")
        {
            await _hubContext.Clients.User(userId).SendAsync("ReceivePopup", title, message, type);
        }
    }
}
