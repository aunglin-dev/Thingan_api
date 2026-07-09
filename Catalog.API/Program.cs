using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
var catalogConnectionString = builder.Configuration.GetConnectionString("CatalogDatabase")
    ?? throw new InvalidOperationException("Connection string 'CatalogDatabase' was not found.");
var httpsPort = builder.Configuration["ASPNETCORE_HTTPS_PORT"] ?? builder.Configuration["HTTPS_PORT"];

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSharedExceptionHandling();
builder.Services.AddHealthChecks()
    .AddNpgSql(catalogConnectionString, name: "postgresql");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSharedExceptionHandling();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!string.IsNullOrWhiteSpace(httpsPort))
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapHealthChecks("/health");
app.MapControllers();

app.Run();
