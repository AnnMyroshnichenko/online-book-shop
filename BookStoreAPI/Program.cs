using BookStore.Infrastructure.Persistance;
using BookStore.Infrastructure.Extensions;
using BookStore.Infrastructure.Seeders;
using BookStore.Application.Extensions;
using Serilog;
using Serilog.Events;
using BookStoreAPI.Middlewares;
using BookStore.Domain.Entities;
using Microsoft.OpenApi.Models;
using BookStoreAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IBookSeeder>();
await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
