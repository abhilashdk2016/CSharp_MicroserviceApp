using System;
using System.Text;
using EventBuRabbitMQ.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EventBuRabbitMQ.Producer
{
    public class EventBusRabbitMQProducer
    {
        private readonly IRabbitMQConnection _connection;

        public EventBusRabbitMQProducer(IRabbitMQConnection connection)
        {
            _connection = connection;
        }

        public void PublishBasketCheckout(string queueName, BasketCheckoutEvent basketCheckoutEvent)
        {
            using(var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queueName, false, false, false, null);
                var message = JsonConvert.SerializeObject(basketCheckoutEvent);
                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.DeliveryMode = 2;

                channel.ConfirmSelect();
                channel.BasicPublish(exchange: "", routingKey: queueName, mandatory: true, basicProperties: properties, body: body);
                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArgs) =>
                {
                    Console.WriteLine("Sent RabbitMQ");
                };
                channel.ConfirmSelect();
            }
        }
    }
}
