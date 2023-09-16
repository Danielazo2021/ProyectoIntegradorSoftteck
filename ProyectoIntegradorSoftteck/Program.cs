
using ProyectoIntegradorSoftteck.DataAccess;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Services.Interfaces;
using ProyectoIntegradorSoftteck.Services.Implementaciones;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ContextDB>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Umsa Softtek", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autorizacion JWT",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type= ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, new string[]{ }
                    }
                });

});

builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"))
           .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
});

//builder.Services.AddAuthorization(option =>
//{
//    option.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "1"));
//});


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//           .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
//           {
//               ValidateIssuerSigningKey = true,
//               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
//               ValidateIssuer = false,
//               ValidateAudience = false
//           });


builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<ITrabajoRepository, TrabajoRepository>();
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWorkService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
