using Microsoft.AspNetCore.SignalR;

namespace NotificationTest.Common
{
    /// <summary>
    /// 클라이언트와의 실시간 통신을 담당하는 SignalR 허브 클래스입니다.
    /// 그룹 가입/탈퇴 및 연결/해제 이벤트를 처리합니다.
    /// </summary>
    public class NotificationHub : Hub
    {
        /// <summary>
        /// 클라이언트를 지정한 그룹에 추가합니다.
        /// </summary>
        /// <param name="groupName">추가할 그룹 이름</param>
        public async Task JoinGroup(string groupName)
        {
            // 현재 연결된 클라이언트(ConnectionId)를 지정한 그룹에 추가
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        /// <summary>
        /// 클라이언트를 지정한 그룹에서 제거합니다.
        /// </summary>
        /// <param name="groupName">제거할 그룹 이름</param>
        public async Task LeaveGroup(string groupName)
        {
            // 현재 연결된 클라이언트(ConnectionId)를 지정한 그룹에서 제거
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        /// <summary>
        /// 클라이언트가 허브에 연결될 때 호출됩니다.
        /// (필요시 연결 시 추가 작업 구현 가능)
        /// </summary>
        public override async Task OnConnectedAsync()
        {
            // 기본 동작(아무 작업 없음)
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// 클라이언트가 허브에서 연결 해제될 때 호출됩니다.
        /// (필요시 해제 시 추가 작업 구현 가능)
        /// </summary>
        /// <param name="exception">연결 해제 원인 예외(있을 경우)</param>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // 기본 동작(아무 작업 없음)
            await base.OnDisconnectedAsync(exception);
        }
    }
}
