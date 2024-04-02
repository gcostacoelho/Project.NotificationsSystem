using Project.Rabbit.Producer.src.Models;

namespace Project.Rabbit.Producer.src.Services;
public interface IMessagingService
{
    void SendMessageToRabbit(Notification notification);
}