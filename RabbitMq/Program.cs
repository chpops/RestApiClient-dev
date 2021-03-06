﻿using RabbitMQ.Client;
using System.Text;

namespace RabbitMq
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "root",
                Password = "root"
            };
            
            using(var connection = factory.CreateConnection())
            using(var model = connection.CreateModel())
            {
                model.QueueDeclare("test-queue", durable: true, exclusive: false, autoDelete: false);

                string stringMessage = "MilkShake RabbitMq message check.";
                var body = Encoding.UTF8.GetBytes(stringMessage);

                model.BasicPublish(exchange: string.Empty, routingKey: "test-queue", body: body);
            }
        }
    }
}
