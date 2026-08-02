using Microsoft.EntityFrameworkCore;
using UserService.DbContexts;
using UserService.Factory;
using UserService.Helper;
using UserService.IFactory;
using UserService.IRepository;
using UserService.IServices;
using UserService.Repository;
using UserService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddDbContext<ChatApplicationDbContext>(options =>
//{
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddDbContextFactory<ChatApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("UserServiceDb"));
});

builder.Services.AddHttpClient<IAuthServiceClient, AuthServiceClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7018/");
});

builder.Services.AddScoped<IDbChatApplicationContextFactory, DbChatApplicationContextFactory>();
builder.Services.AddScoped<IUserService,UserServices>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddHttpClient<IHttpClientHelper, HttpClientHelper>();
//builder.Services.AddScoped<IAuthServiceClient,Auth>

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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