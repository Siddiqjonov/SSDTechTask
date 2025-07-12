using MassTransit;
using WebApiB.Entities;
using WebApiB.Services;

namespace WebApiB.RabbitMQClient;

public class RabbitMQConsumer : IConsumer<User>
{
    private readonly IUserService _userService;

    public RabbitMQConsumer(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Consume(ConsumeContext<User> context)
    {
        var user = context.Message;

        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine($"{user.Name} and {user.Email}");
        }

        //await _userService.SaveUserAsync(user);
    }
}