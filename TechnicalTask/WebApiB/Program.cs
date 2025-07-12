using MassTransit;
using Microsoft.EntityFrameworkCore;
using WebApiB.Data;
using WebApiB.RabbitMQClient;
using WebApiB.Services;

namespace WebApiB;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("PostgresConnection")));

        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<RabbitMQConsumer>();

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("user-queue", e =>
                {
                    e.ConfigureConsumer<RabbitMQConsumer>(ctx);
                });
            });
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
