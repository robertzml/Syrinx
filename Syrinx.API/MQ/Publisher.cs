using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Syrinx.API.MQ
{
    using Syrinx.Base.Common;   

    public class Publisher
    {
        /// <summary>
        /// 队列名称
        /// </summary>
        private readonly string queueName = "ControlQueue";

        public void Send(string text)
        {
            IConnectionFactory factory = new ConnectionFactory()
            {
                HostName = AppSettings.RabbitMQHostName,
                Port = AppSettings.RabbitMQPort,
                UserName = AppSettings.RabbitMQUserName,
                Password = AppSettings.RabbitMQPassword
            };

            using (var connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                var body = Encoding.UTF8.GetBytes(text);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: properties,
                                     body: body);
               
                Console.WriteLine("[x] Sent {0}", text);
            }

        }
    }
}
