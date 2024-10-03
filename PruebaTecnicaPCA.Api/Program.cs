using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaPCA.Core.Interfaces;
using PruebaTecnicaPCA.Core.Services;
using PruebaTecnicaPCA.Infrastructure.Data;
using PruebaTecnicaPCA.Infrastructure.Filters;
using PruebaTecnicaPCA.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    // Agregar filtro para las excepciones
    options.Filters.Add<GlobalExceptionFilter>();
});
// Agregar cadena de conexión a la base de datos
builder.Services.AddDbContext<PruebaTecnicaPcaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaTecnicaPCA")));
// Agregar automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Agregar dependencias de repositorio
builder.Services.AddScoped<IVueloRepository, VueloRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IEstadisticaRepository, EstadisticaRepository>();
// Agregar dependencias de servicio
builder.Services.AddScoped<IVueloService, VueloService>();
builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<IEstadisticaService, EstadisticaService>();
// Agregar validaciones con Fluent
builder.Services.AddMvc().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
