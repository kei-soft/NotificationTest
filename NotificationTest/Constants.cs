namespace NotificationTest
{
    public class NotificationItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public string Type { get; set; } = "info";
        public DateTime Timestamp { get; set; }
    }

    public class PopupItem
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public string Type { get; set; } = "info";
    }
}
