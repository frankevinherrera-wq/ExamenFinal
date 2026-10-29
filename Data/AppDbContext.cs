using Microsoft.EntityFrameworkCore;
using ExamenGrupal.models; 
namespace ExamenGrupal.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Oficial> Oficiales {get;set;}
    public DbSet<Accidente> Accidentes {get;set;}
    public DbSet<PeritajeTecnico> PeritajesTecnicos {get;set;}
    public DbSet<VehiculoInvolucrado> VehiculosInvolucrados {get;set;}
    public DbSet<PersonaInvolucrada> PersonasInvolucradas {get;set;}


}