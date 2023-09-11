
using ProyectoIntegradorSoftteck.DataAccess;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Services.Interfaces;
using ProyectoIntegradorSoftteck.Services.Implementaciones;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ContextDB>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();




var app = builder.Build();

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
