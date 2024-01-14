using System.Security.Claims;
using BankAPI.Infrastructure.ComponentRegistrar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();
app.Use(async (context, next) =>
{
    context.User.AddIdentity(new ClaimsIdentity(new []{new Claim(ClaimTypes.Name, "9A1ED33A-B590-4C42-BB45-280C073C9F69")}));
    await next.Invoke(context);
});

app.MapControllers();

app.Run();