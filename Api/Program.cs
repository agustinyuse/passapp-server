using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Environment.IsDevelopment();

builder.Services
          .AddApplication()
          .AddInfrastructure(builder.Configuration, builder.Environment.IsDevelopment());

builder.Host.UseSerilog((context, configuration) =>
                        configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
