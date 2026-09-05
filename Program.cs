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

//CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

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

app.UseCors("ReactFrontend");

app.UseAuthorization();

app.MapControllers();
app.Run();