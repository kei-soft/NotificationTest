using Microsoft.AspNetCore.SignalR;

using NotificationTest.Common;

namespace NotificationTest.Services
{
    /// <summary>
    /// SignalR를 통해 클라이언트에 실시간 알림/팝업 메시지를 전송하는 서비스입니다.
    /// </summary>
    public class NotificationService
    {
        // SignalR 허브 컨텍스트 (NotificationHub에 접근)
        private readonly IHubContext<NotificationHub> _hubContext;

        /// <summary>
        /// 생성자 - DI로 허브 컨텍스트 주입
        /// </summary>
        /// <param name="hubContext">NotificationHub의 SignalR 컨텍스트</param>
        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        /// <summary>
        /// 모든 사용자에게 토스트 알림 전송
        /// </summary>
        /// <param name="title">알림 제목</param>
        /// <param name="message">알림 메시지</param>
        /// <param name="type">알림 타입(info/success/warning/error)</param>
        public async Task SendNotificationToAll(string title, string message, string type = "info")
        {
            // 모든 클라이언트에 "ReceiveNotification" 이벤트로 전송
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", title, message, type);
        }

        /// <summary>
        /// 특정 사용자에게 토스트 알림 전송
        /// </summary>
        /// <param name="userId">대상 사용자 ID</param>
        /// <param name="title">알림 제목</param>
        /// <param name="message">알림 메시지</param>
        /// <param name="type">알림 타입</param>
        public async Task SendNotificationToUser(string userId, string title, string message, string type = "info")
        {
            // 특정 사용자에게 "ReceiveNotification" 이벤트로 전송
            await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", title, message, type);
        }

        /// <summary>
        /// 특정 그룹에 토스트 알림 전송
        /// </summary>
        /// <param name="groupName">대상 그룹명</param>
        /// <param name="title">알림 제목</param>
        /// <param name="message">알림 메시지</param>
        /// <param name="type">알림 타입</param>
        public async Task SendNotificationToGroup(string groupName, string title, string message, string type = "info")
        {
            // 특정 그룹에 "ReceiveNotification" 이벤트로 전송
            await _hubContext.Clients.Group(groupName).SendAsync("ReceiveNotification", title, message, type);
        }

        /// <summary>
        /// 모든 사용자에게 팝업 메시지 전송
        /// </summary>
        /// <param name="title">팝업 제목</param>
        /// <param name="message">팝업 메시지</param>
        /// <param name="type">팝업 타입</param>
        public async Task SendPopupToAll(string title, string message, string type = "info")
        {
            // 모든 클라이언트에 "ReceivePopup" 이벤트로 전송
            await _hubContext.Clients.All.SendAsync("ReceivePopup", title, message, type);
        }

        /// <summary>
        /// 특정 사용자에게 팝업 메시지 전송
        /// </summary>
        /// <param name="userId">대상 사용자 ID</param>
        /// <param name="title">팝업 제목</param>
        /// <param name="message">팝업 메시지</param>
        /// <param name="type">팝업 타입</param>
        public async Task SendPopupToUser(string userId, string title, string message, string type = "info")
        {
            // 특정 사용자에게 "ReceivePopup" 이벤트로 전송
            await _hubContext.Clients.User(userId).SendAsync("ReceivePopup", title, message, type);
        }
    }
}
