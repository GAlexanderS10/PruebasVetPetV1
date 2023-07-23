using Microsoft.EntityFrameworkCore;
using PruebasVetPetV1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// Configuración del contexto de la base de datos
builder.Services.AddDbContext<PRUEBASVETPETContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaCn")));



var app = builder.Build();

// Configurar la canalización de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Configurar el middleware de enrutamiento
app.UseRouting();

// Configurar la política CORS
app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:3000") // React
          .AllowAnyHeader()
          .AllowAnyMethod();
});


// Configurar los endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();