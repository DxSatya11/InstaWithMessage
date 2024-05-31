using Instagram.Application.Business.Commands.User;
using Instagram.Application.Business.Handlers.UserHandler.CommandHandler;
using Instagram.Application.Business.Mapper;
using Instagram.Application.Business.Message;
using Instagram.Domain.IRepository;
using Instagram.Domain.IRepository.FollowRelation;
using Instagram.Domain.IRepository.Password;
using Instagram.Domain.IRepository.Post;
using Instagram.Infrastructure.Data;
using Instagram.Infrastructure.Repository.FollowRelation;
using Instagram.Infrastructure.Repository.Password;
using Instagram.Infrastructure.Repository.Post;
using Instagram.Infrastructure.Repository.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Adding Cors
builder.Services.AddCors(option =>
{
    option.AddPolicy(
        "CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
        //.AllowCredentials()
        //.SetIsOriginAllowed((host) => true)
        //);
});

//Register SQL Database
builder.Services.AddDbContext<InstagramDbContext>(s => s.UseSqlServer(builder.Configuration.GetConnectionString("Studentdb")),ServiceLifetime.Scoped);
//For blobe storage
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("AzureBlobStorage");


//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfil).Assembly);

//Add Mediator
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly));


// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IFollowRepository, FollowRepository>();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//SignalR Register
builder.Services.AddSignalR();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseRouting();

app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapHub<ChatHub>("/chathub");
//    endpoints.MapControllers();
//});


//app.UseWebSockets(new WebSocketOptions
//{
//    KeepAliveInterval = TimeSpan.FromSeconds(120),
//});

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chathub");
    endpoints.MapControllers();
});

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
