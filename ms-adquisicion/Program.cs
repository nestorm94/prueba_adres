using Microsoft.EntityFrameworkCore;
using ms_adquisicion.database;
using ms_adquisicion.services;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------
// Configuración de Servicios
// ------------------------------------------

// Agrega los controladores al contenedor de servicios
builder.Services.AddControllers();

// Configura y agrega Swagger (para documentación de la API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura la conexión a la base de datos con SQL Server
builder.Services.AddDbContext<DBAdquisicionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconection")));

// Inyección de dependencias para el servicio de adquisiciones
builder.Services.AddScoped<IAdquisicionService, AdquisicionService>();

var app = builder.Build();

// ------------------------------------------
// Configuración del Middleware
// ------------------------------------------

// Habilita Swagger en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapea los controladores (endpoints de la API)
app.MapControllers();

// Inicia la aplicación
app.Run();
