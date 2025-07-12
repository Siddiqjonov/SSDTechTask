using MassTransit;
using WebApiA.Entities;

namespace WebApiA.RabbitMQClient;

public class RabbitMQProducer : IRabbitMQProducer
{
    private readonly IPublishEndpoint _publish;

    public RabbitMQProducer(IPublishEndpoint publish)
    {
        _publish = publish;
    }

    public async void SendMessage(User message)
    {
        await _publish.Publish(message);
    }
}
