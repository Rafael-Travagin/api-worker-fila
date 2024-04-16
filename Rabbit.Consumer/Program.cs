using Rabbit.Models.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var factory = new ConnectionFactory { 
    HostName = "localhost",
    UserName = "user",
    Password = "123456",
    VirtualHost = "/"
 };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "testMessageQueue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    try
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($"message:{message}.");
        var messageModel = JsonSerializer.Deserialize<Message>(message);
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine($"Id:{messageModel?.Id}, Titulo:{messageModel?.Titulo},Texto:{messageModel?.Texto}");
        channel.BasicAck(ea.DeliveryTag, false);
    }
    catch {
        channel.BasicNack(ea.DeliveryTag, false, true);
    }
    
};
channel.BasicConsume(queue: "testMessageQueue",
                     autoAck: false,  //autoAck: false
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();