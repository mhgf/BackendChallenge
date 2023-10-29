using BackendChallenge.Behaviours;
using BackendChallenge.core.Commands.User;
using BackendChallenge.core.Entity;
using BackendChallenge.core.Notification;
using BackendChallenge.core.Repositories;
using BackendChallenge.core.Services;
using BackendChallenge.Filters;
using BackendChallenge.infra.Database;
using BackendChallenge.infra.Database.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<NotificationContext>();

// Entity Framework
builder.Services.AddEntityFrameworkNpgsql();
builder.Services.AddNpgsql<DatabaseContext>(builder.Configuration.GetConnectionString("Database"));

builder.Services.AddScoped<IUserRepository, UserRepository>();


// Add services to the container.
builder.Services.AddControllers(opt => opt.Filters.Add<NotificationFilter>()).AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.AddOpenBehavior(typeof(ContextBehaviour<,>));
});

builder.Services.AddScoped<IRequestHandler<CreateUserCommand, User?>, UserCreateHandler>();

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
