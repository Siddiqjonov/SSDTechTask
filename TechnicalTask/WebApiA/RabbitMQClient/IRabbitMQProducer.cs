using Models;

namespace WebApiA.RabbitMQClient;

public interface IRabbitMQProducer
{
    Task SendMessage(User message);
}
