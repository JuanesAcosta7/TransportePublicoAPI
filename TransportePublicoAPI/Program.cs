using Microsoft.EntityFrameworkCore;
using TransportePublicoAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuración de la base de datos (DbContext)
builder.Services.AddDbContext<TransporteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransporteDbConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuracion de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Permitir solicitudes desde cualquier origen
                   .AllowAnyMethod()  // Permitir cualquier método (GET, POST, etc.)
                   .AllowAnyHeader(); // Permitir cualquier cabecera
        });
});

builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

// Mapeo de los Hubs SignalR
app.MapHub<BusHub>("/bushub");

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
