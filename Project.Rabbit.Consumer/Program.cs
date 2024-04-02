using System.Text;
using System.Text.Json;
using Project.Rabbit.Consumer.src.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var connectionFactory = new ConnectionFactory { HostName = "localhost" };

var conn = connectionFactory.CreateConnection();

var channel = conn.CreateModel();

channel.QueueDeclare(
    queue: "notifications",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

Console.WriteLine("Aguardando mensagens.");

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var bodyReceived = ea.Body.ToArray();

    var messageString = Encoding.UTF8.GetString(bodyReceived);

    var notification = JsonSerializer.Deserialize<Notification>(messageString);

    Console.WriteLine($"Assunto: {notification?.Subject}\n{notification?.Body}");
};

channel.BasicConsume(queue: "notifications", autoAck: true, consumer: consumer);

Console.ReadLine();