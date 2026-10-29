using ExamenGrupal.Data;
using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;
using ExamenGrupal.models;
using ExamenGrupal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamenGrupal.Services;

public class PeritajeTecnicoService : IPeritajeTecnicoService
{
    private readonly AppDbContext _context;

    public PeritajeTecnicoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PeritajeTecnicoResponseDto> CrearAsync(PeritajeTecnicoRequestDto request)
    {

        if (!request.AccidenteId.HasValue || !request.PeritoId.HasValue || !request.FechaPeritaje.HasValue)
        {
            throw new ArgumentException("Los datos del peritaje estan incompletos.", nameof(request));
        }

        var accidenteExiste = await _context.Accidentes
            .AnyAsync(accidente => accidente.Id == request.AccidenteId.Value);

        if (!accidenteExiste)
        {
            throw new KeyNotFoundException("No se encontro el accidente.");
        }

        var peritoExiste = await _context.Oficiales
            .AnyAsync(oficial => oficial.Id == request.PeritoId.Value);

        if (!peritoExiste)
        {
            throw new KeyNotFoundException("No se encontro el perito.");
        }

        var peritajeExiste = await _context.PeritajesTecnicos
            .AnyAsync(peritaje => peritaje.AccidenteId == request.AccidenteId.Value);

        if (peritajeExiste)
        {
            throw new InvalidOperationException("El accidente ya tiene un peritaje tecnico.");
        }

        var peritaje = new PeritajeTecnico
        {
            AccidenteId = request.AccidenteId.Value,
            PeritoId = request.PeritoId.Value,
            FechaPeritaje = AFechaUtc(request.FechaPeritaje.Value),
            VelocidadEstimadaImpactoKmh = request.VelocidadEstimadaImpactoKmh,
            HuellaFrenadoMetros = request.HuellaFrenadoMetros,
            FactorDeterminante = request.FactorDeterminante,
            Conclusiones = request.Conclusiones,
            CroquisUrl = request.CroquisUrl,
            CreatedAt = DateTime.UtcNow
        };

        _context.PeritajesTecnicos.Add(peritaje);
        await _context.SaveChangesAsync();

        return Mapear(peritaje);
    }

    private static PeritajeTecnicoResponseDto Mapear(PeritajeTecnico peritaje)
    {
        return new PeritajeTecnicoResponseDto
        {
            Id = peritaje.Id,
            AccidenteId = peritaje.AccidenteId,
            PeritoId = peritaje.PeritoId,
            FechaPeritaje = peritaje.FechaPeritaje,
            VelocidadEstimadaImpactoKmh = peritaje.VelocidadEstimadaImpactoKmh,
            HuellaFrenadoMetros = peritaje.HuellaFrenadoMetros,
            FactorDeterminante = peritaje.FactorDeterminante,
            Conclusiones = peritaje.Conclusiones,
            CroquisUrl = peritaje.CroquisUrl,
            CreatedAt = peritaje.CreatedAt
        };
    }

    private static DateTime AFechaUtc(DateTime fecha)
    {
        return fecha.Kind switch
        {
            DateTimeKind.Utc => fecha,
            DateTimeKind.Local => fecha.ToUniversalTime(),
            _ => DateTime.SpecifyKind(fecha, DateTimeKind.Utc)
        };
    }
}
