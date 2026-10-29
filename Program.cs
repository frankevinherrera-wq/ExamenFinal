using ExamenGrupal.Data;
using ExamenGrupal.Services;
using ExamenGrupal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAccidenteService, AccidenteService>();
builder.Services.AddScoped<IPeritajeTecnicoService, PeritajeTecnicoService>();
builder.Services.AddScoped<IVehiculoInvolucradoService, VehiculoInvolucradoService>();
builder.Services.AddScoped<IPersonaInvolucradaService, PersonaInvolucradaService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();