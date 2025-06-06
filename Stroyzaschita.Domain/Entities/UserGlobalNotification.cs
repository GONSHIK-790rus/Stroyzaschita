namespace Stroyzaschita.Domain.Entities;

public class UserGlobalNotification {
    public Guid UserId { get; set; }
    public int NotificationId { get; set; }
    public DateTime? ReadAt { get; set; }

    public User User { get; set; } = default!;
    public GlobalNotification Notification { get; set; } = default!;
}
