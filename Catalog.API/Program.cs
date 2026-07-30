using Catalog.API.Extensions;
using Catalog.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add framework services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Add infrastructure services via extension method
builder.Services.AddCosmosDbServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
