using WebApiA.Entities;

namespace WebApiA.RabbitMQClient;

public interface IRabbitMQProducer
{
    void SendMessage(User message);
}
