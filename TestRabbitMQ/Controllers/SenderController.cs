using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using TestRabbitMQ.Models;

namespace TestRabbitMQ.Controllers
{
    public class SenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("sender")]
        public async Task<IActionResult> Sender()
        {
            string connectionString = "amqp://thiago:thiago@3.85.129.153:5672";
            string queueName = "teste1";

            MessageInputModel messageInput = new MessageInputModel{
                Content = "Teste",
                CreatedAt = DateTime.Now,
                FromId = 1,
                ToId = 2,
            };
            try
            {
                var factory = new ConnectionFactory()
                {
                    Uri = new Uri(connectionString)
                };


                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: queueName,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                var stringfiedMessage = JsonConvert.SerializeObject(messageInput);
                channel.BasicPublish(exchange: "",
                                         routingKey: queueName,
                                         basicProperties: null,
                                         body: Encoding.UTF8.GetBytes(stringfiedMessage));

                return await Task.Run(() => View("Index"));

            }
            catch (Exception ex)
            {
                return await Task.Run(() => View("Index"));

            }
        }
    }
}
