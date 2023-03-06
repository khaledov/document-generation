using AutoMapper;
using EventBus.Messages.Common;
using EventBus.Messages.Events;
using MassTransit;
using Subscription.API.EventBusConsumers;
using Subscription.API.Models;
using Subscription.Application.Services;
using Subscription.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPdfGeneratorService, PdfGeneratorService>();
// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<PdfGenerationRequestedConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ConfigureEndpoints(ctx);
        //cfg.ReceiveEndpoint(EventBusConstants.PDF_QUEUE, c => {
        //    c.ConfigureConsumer<PdfGenerationRequestedConsumer>(ctx);
        //});
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

app.MapPost("v1/document", async (IPublishEndpoint _publishEndpoint, IMapper mapper, SubscriptionRequest model) =>
{
    var @event = mapper.Map<PdfGenerationRequested>(model);
    await _publishEndpoint.Publish<PdfGenerationRequested>(@event);
    return Results.NoContent();
});

app.Run();

