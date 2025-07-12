using WebApiA.Dtos;
using WebApiA.Entities;
using WebApiA.Exceptions;
using WebApiA.FluentValidation;
using WebApiA.RabbitMQClient;

namespace WebApiA.Services;

public class UserService : IUserService
{
    private readonly IRabbitMQProducer _producer;

    public UserService(IRabbitMQProducer producer)
    {
        _producer = producer;
    }

    public async Task CreateUser(UserCreateDto userDto)
    {
        var validator = new UserCreateDtoValidator();
        var result = validator.Validate(userDto);
        if (!result.IsValid)
        {
            var errors = string.Concat(result.Errors.Select(e => e.ErrorMessage + " "));
            throw new ValidationFailedException(errors);
        }

        var message = new User
        {
            Id = 0,
            Name = userDto.Name,
            Email = userDto.Email
        };

        await _producer.SendMessage(message);
    }
}