using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Syrinx.MQ.Service
{
    using Syrinx.Base.Options;

    /// <summary>
    /// RabbitMQ 实现
    /// </summary>
    public class RabbitQueue : IMessageQueue, IDisposable
    {
        #region Field
        private readonly ILogger _logger;

        /// <summary>
        /// MQ连接
        /// </summary>
        private IConnection connection;
        #endregion //Field

        #region Constructor
        public RabbitQueue(IOptions<RabbitOptions> option, ILogger<RabbitQueue> logger)
        {
            this._logger = logger;

            try
            {
                IConnectionFactory factory = new ConnectionFactory()
                {
                    HostName = option.Value.HostName,
                    Port = option.Value.Port,
                    UserName = option.Value.UserName,
                    Password = option.Value.Password
                };

                this.connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "connect to rabbit mq failed.");
            }
        }

        public void Dispose()
        {
            this._logger.LogInformation("Rabbit Queue closed.");
            this.connection.Close();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 推送控制消息
        /// </summary>
        /// <param name="message">消息内容</param>
        public void PushControl(string message)
        {
            string queueName = "ControlQueue";

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: properties,
                                     body: body);

                this._logger.LogInformation($"publish control msg: {message}");
            }
        }

        /// <summary>
        /// 推送状态反馈消息
        /// </summary>
        /// <param name="message">消息内容</param>
        public void PushFeedback(string message)
        {
            string queueName = "FeedbackQueue";

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: properties,
                                     body: body);

                this._logger.LogInformation($"publish feedback msg: {message}");
            }
        }

        /// <summary>
        /// 推送特殊指令
        /// </summary>
        /// <param name="message">消息内容</param>
        public void PushSpecial(string message)
        {
            string queueName = "SpecialQueue";

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: properties,
                                     body: body);

                this._logger.LogInformation($"publish special msg: {message}");
            }
        }
        #endregion //Method
    }
}
