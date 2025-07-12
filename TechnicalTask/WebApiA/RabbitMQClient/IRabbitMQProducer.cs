using WebApiA.Entities;

namespace WebApiA.RabbitMQClient;

public interface IRabbitMQProducer
{
    Task SendMessage(User message);
}
