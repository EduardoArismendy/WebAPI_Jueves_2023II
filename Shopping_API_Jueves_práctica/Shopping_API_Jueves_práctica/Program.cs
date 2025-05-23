using Microsoft.EntityFrameworkCore;
using Shopping_API_Jueves_práctica.DAL.Entities;
using Shopping_API_Jueves_práctica.Domain.Interfaces;
using Shopping_API_Jueves_práctica.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Contenedor de dependencias
builder.Services.AddScoped<ICountryService, CountryService>();
//builder.Services.AddTransient<ICountryService, CountryService>(); Otras formas - Diferencias en el ciclo de vida
//builder.Services.AddSingleton<ICountryService, CountryService>(); - Consultar mas

//Esta es la línea de code que necesito para configurar la DB
builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString
    ("DefaultConnection"))); //Configuración a la base de datos


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
