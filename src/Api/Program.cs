using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure.Contexts;
using Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument();
builder.Services.AddUserHandlers();
builder.Services.AddMediator();
builder.Services.AddRepositories();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints();
app.UseSwaggerGen();

await app.RunAsync();