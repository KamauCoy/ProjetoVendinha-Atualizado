using Vendinha.Data;
using Vendinha.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

Environment.SetEnvironmentVariable(
    "ConnectionStrings__Default",
    "Server=localhost;Port=5432;Database=Vendinha;User Id=postgres;Password=1234"

);
builder.Services.AddTransient<ClienteService>();
builder.Services.AddTransient<VendinhaDbContext>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
