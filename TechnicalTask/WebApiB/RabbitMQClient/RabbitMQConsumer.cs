using MassTransit;
using Models;

//using WebApiB.Entities;
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
        await _userService.SaveUserAsync(user);
    }
}