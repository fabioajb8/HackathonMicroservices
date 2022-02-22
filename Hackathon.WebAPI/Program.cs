using Hackathon.Application;
using Hackathon.Persistence;
using Hackathon.Services;
using Hackathon.WebAPI.Extensions;
using Hackathon.WebAPI.Middleware;
using Hackhaton.WebAPI.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddServices();
builder.Services.ConfigureVersioning();
builder.Services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.ConfigureExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
