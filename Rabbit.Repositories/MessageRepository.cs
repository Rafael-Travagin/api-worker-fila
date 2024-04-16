using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rabbit.Models.Entities;
using Rabbit.Models.Interface;
using System.Text.Json;
using RabbitMQ.Client;
using static System.Net.WebRequestMethods;

namespace Rabbit.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public void SendMessage(Message message)
        {
            Console.WriteLine("inicio rabbit config");

            var factory = new ConnectionFactory {
                HostName = "localhost",
                UserName = "user",
                Password = "123456",
                VirtualHost = "/"
            };
            
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            Console.WriteLine("conectou rabbit");

            channel.QueueDeclare(queue: "testMessageQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string messageJson = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(messageJson);

           
            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "testMessageQueue",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($" [x] Sent {messageJson}");

        }
    }
}