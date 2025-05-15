using BarberAgendado.Configurations;
using BarberAgendado.Data.Repositories;
using BarberAgendado.Data.Repositories.Interfaces;
using BarberAgendado.Domain.Services;
using BarberAgendado.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddDbContextConfig();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IBarberRepository, BarberRepository>();
builder.Services.AddScoped<IServiceItemRepository, ServiceItemRepository>();

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<BarberService>();
builder.Services.AddScoped<ServiceItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalErrorHandler>();

app.UseAuthorization();

app.MapControllers();

app.Run();
