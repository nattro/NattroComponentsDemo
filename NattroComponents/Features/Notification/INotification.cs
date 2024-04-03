namespace NattroComponents.Features.Notification;

public interface INotification
{
    void SendMessage(string screenName, string messageBody);
}
