using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};

using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(
    queue: "device-events",

    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null);

// Odbior wiadomosci 
var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (_, ea) =>
{
    var json = Encoding.UTF8.GetString(ea.Body.Span);

    var message = JsonSerializer.Deserialize<DeviceStateChanged>(json);

    if (message is not null)
    {
        Console.WriteLine($"{message.DeviceId}: {message.State}");
    }

    await channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
};

await channel.BasicConsumeAsync(
    queue: "device-events",
    autoAck: false,
    consumer: consumer);

Console.WriteLine("Listening...");
Console.ReadLine();

public sealed class DeviceStateChanged
{
    public string DeviceId { get; set; } = "";
    public string State { get; set; } = "";
}