using System.Text.Json;

using RabbitMQ.Client;

using Project.Rabbit.Producer.src.Models;
using System.Text;

namespace Project.Rabbit.Producer.src.Services;
public class MessagingService : IMessagingService
{
    private readonly ConnectionFactory connectionFactory = new ConnectionFactory { HostName = "localhost" };

    public void SendMessageToRabbit(Notification notification)
    {
        var conn = connectionFactory.CreateConnection();
        
        var channel = conn.CreateModel();

        channel.QueueDeclare(
            queue: "notifications",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var message = JsonSerializer.Serialize(notification);

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(string.Empty, "notifications", null, body);
    }
}