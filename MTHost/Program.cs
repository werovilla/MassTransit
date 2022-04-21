using System.Configuration;
using System.Reflection;
using CreateOrder;
using CreateOrder.Consumers;
using CreateOrder.Interfaces;
using CreateOrder.Services;
using MassTransit;
using Microsoft.CodeAnalysis.FlowAnalysis;
using MTHost;
using MTHost.Configurations;
using MTHost.Services;
using ReceiveOrder.Consumers;
using ReceiveOrder.Controllers;
using ReceiveOrder.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<MassTransitService>();
builder.Services.AddSingleton<IOrderController, OrderController>();
builder.Services.AddSingleton<ICreateOrderService, CreateOrderService>();

builder.Host.ConfigureServices((hostContext, services) =>
{
    services.AddMassTransit(x =>
    {
        x.SetKebabCaseEndpointNameFormatter();
        x.SetInMemorySagaRepositoryProvider();

        var entryAssembly = Assembly.GetEntryAssembly();
        x.AddConsumer(typeof(CreateOrderConsumer));
        x.AddConsumer(typeof(OrderCreatedConsumer));
        x.AddSagaStateMachines(entryAssembly);
        x.AddSagas(entryAssembly);
        x.AddActivities(entryAssembly);
        
        /*This switch statement shows the type of MassTransit that can be configured in appsettings.Development.json
          e.g.: "MassTransitBus": "InMemory" | "MassTransitBus": "RabbitMQ" | "MassTransitBus": "Azure"  | "MassTransitBus": "Azure"*/
        switch (hostContext.Configuration.GetValue<string>("MassTransitBus"))
        {
            case "InMemory":
                x.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });
                break;
            case "RabbitMQ":
                var rabbitMQconfig = new RabbitMQConfig(hostContext.Configuration);
                x.UsingRabbitMq((cxt, cfg) => {
                    cfg.Host(rabbitMQconfig.HostAddress , rabbitMQconfig.VirtualHost, h =>
                    {
                        h.Username(rabbitMQconfig.Username);
                        h.Password(rabbitMQconfig.Password);
                    });
                    cfg.ConfigureEndpoints(cxt);
                });
                break;
            case "Azure":
                var azureConfig = new AzureConfig(hostContext.Configuration);
                x.UsingAzureServiceBus((cxt, cfg) =>
                {
                    cfg.Host(azureConfig.ConnectionString);
                    cfg.ConfigureEndpoints(cxt);
                });
                break;
            case "AWS":
                var awsConfig = new AWSConfig(hostContext.Configuration);
                x.UsingAmazonSqs((context, cfg) =>
                {
                    cfg.Host(awsConfig.Host, h => {
                        h.AccessKey(awsConfig.AccessKey);
                        h.SecretKey(awsConfig.SecretKey);
                    });
        
                    cfg.ConfigureEndpoints(context);
                });
                break;
            case "Kafka":
                // x.AddRider(rider =>
                // {
                //     rider.AddConsumer<KafkaMessageConsumer>();
                //
                //     rider.UsingKafka((context, k) =>
                //     {
                //         k.Host("localhost:9092");
                //
                //         k.TopicEndpoint<KafkaMessage>("topic-name", "consumer-group-name", e =>
                //         {
                //             e.ConfigureConsumer<KafkaMessageConsumer>(context);
                //         });
                //     });
                // });
                break;
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();