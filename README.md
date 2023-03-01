# TestRabbitMQ

What is RabbitMQ? You can find more information in https://www.rabbitmq.com/

Create an example using RabbitMQ


I need to create a system that I need process files. The users upload files, then I put them in a queue. I use rabbit to process these files and give to users a response.

To install rabbitmq in you project you have to run this command

```bash
dotnet add package RabbitMQ.Client --version 6.4.0
```

In this folder (Consumers) I will create my consumers. In this case I need create only one consumer, that call ConsumerFiles.cs.

If you need more than one consumer you could create others consumers.

After create my consumer I need to registry it in my program.cs or startup.cs

## Usage

```c#
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMqConfig"));
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddHostedService<ConsumerFiles>();
```

To send a message to a queue in RabbitMQ I created a controller and a page that contain a button. In this button I created this code above:

```c#
//Define my connection string. 
string connectionString = "localhost";
string queueName = "ImportFiles";

MessageModel messageInput = new MessageModel{
    Content = "Teste",
    CreatedAt = DateTime.Now,
    FromId = 1,
    ToId = 2,
};
try
{
    //Create a connection com rabbitmq
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
            
```            
