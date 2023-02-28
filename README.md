# TestRabbitMQ

Create an example using RabbitMQ


I need to create a system that I need process files. The users upload files, then I put them in a queue. I use rabbit to process these files and give to users a response.

In this folder (Consumers) I will create my consumers. In this case I need create only one consumer, that call ConsumerFiles.cs.

If you need more than one consumer you could create others consumers.

After create my consumer I need to registry it in my program.cs or startup.cs

## Usage

```c#
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMqConfig"));
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddHostedService<ConsumerFiles>();
