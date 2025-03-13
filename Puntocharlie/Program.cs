using Microsoft.EntityFrameworkCore;
using Puntocharlie.Data;
using Puntocharlie.Models;
using Puntocharlie.PuntoChaelieMapper;
using Puntocharlie.Repositorio;
using Puntocharlie.Repositorio.IRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Se agrega el servicio de Repositorio
builder.Services.AddScoped<ICitaRespositorio, CitaRepositorio>();
builder.Services.AddScoped<ITecnicoRepositorio, TecnicoRepositorio>();
builder.Services.AddScoped<IPuntoServicioRepositorio, PuntoServicioRepositorio>();

//Se agrega el servicio de AutoMapper
builder.Services.AddAutoMapper(typeof(PuntoCharlieMapper));

var app = builder.Build();

//Ejecutar el Seeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
    await Seeder.SeederAsync(context);
}

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
