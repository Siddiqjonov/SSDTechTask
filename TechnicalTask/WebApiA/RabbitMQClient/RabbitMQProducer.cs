using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models;
//using WebApiA.Entities;

namespace WebApiA.RabbitMQClient;

public class RabbitMQProducer : IRabbitMQProducer
{
    private readonly IPublishEndpoint _publish;
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public RabbitMQProducer(ISendEndpointProvider sendEndpointProvider, IPublishEndpoint publish)
    {
        _sendEndpointProvider = sendEndpointProvider;
        _publish = publish;
    }

    public async Task SendMessage(User message)
    {
        Console.WriteLine("Before publish");
        await _publish.Publish(message);
        Console.WriteLine("After publish");
        int a = 3;
        int b = a + 9;
        
    }

    public async Task Send(User user)
    {
        // queue nomini ko'rsatish (rabbitmq ichida queue yaratadi avtomatik)
        Console.WriteLine("$");
        var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:user-queue"));
        await endpoint.Send(user);
    }
}