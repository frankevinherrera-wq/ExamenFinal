using ExamenGrupal.Data;
using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;
using ExamenGrupal.models;
using ExamenGrupal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamenGrupal.Services;

public class AccidenteService : IAccidenteService
{
    private readonly AppDbContext _context;

    public AccidenteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AccidenteResponseDto>> ListarAsync(
    string? distrito,
    string? gravedad,
    DateTime? fechaDesde)
{
    var query = _context.Accidentes
        .AsNoTracking()
        .Include(a => a.OficialAsignado)
        .Include(a => a.PeritajeTecnico)
        .Include(a => a.VehiculosInvolucrados)
        .Include(a => a.PersonasInvolucradas)
        .AsQueryable();

    if (!string.IsNullOrWhiteSpace(distrito))
    {
        query = query.Where(a => a.Distrito == distrito);
    }

    if (!string.IsNullOrWhiteSpace(gravedad))
    {
        query = query.Where(a => a.Gravedad == gravedad);
    }

    if (fechaDesde.HasValue)
    {
        var fechaUtc = DateTime.SpecifyKind(fechaDesde.Value, DateTimeKind.Utc);
        query = query.Where(a => a.FechaHora >= fechaUtc);
    }

    var accidentes = await query
        .OrderByDescending(a => a.FechaHora)
        .ToListAsync();

    return accidentes.Select(Mapear).ToList();
}

    public async Task<AccidenteResponseDto?> ObtenerPorIdAsync(int id)
    {
        var accidente = await _context.Accidentes
            .AsNoTracking()
            .Include(a => a.OficialAsignado)
            .Include(a => a.PeritajeTecnico)
            .Include(a => a.VehiculosInvolucrados)
            .Include(a => a.PersonasInvolucradas)
            .FirstOrDefaultAsync(a => a.Id == id);

        return accidente == null ? null : Mapear(accidente);
    }

    public async Task<AccidenteResponseDto> CrearAsync(AccidenteRequestDto request)
    {
        var accidente = new Accidente
        {
            CodigoCaso = request.CodigoCaso,
            FechaHora = request.FechaHora ?? DateTime.UtcNow,
            TipoAccidente = request.TipoAccidente,
            Gravedad = request.Gravedad,
            Distrito = request.Distrito,
            ZonaBarrio = request.ZonaBarrio,
            DireccionReferencia = request.DireccionReferencia,
            Latitud = request.Latitud,
            Longitud = request.Longitud,
            CondicionClimatica = request.CondicionClimatica,
            EstadoCalzada = request.EstadoCalzada,
            EstadoCaso = request.EstadoCaso ?? "en_investigacion",
            Observaciones = request.Observaciones,
            OficialAsignadoId = request.OficialAsignadoId,
            CreatedAt = DateTime.UtcNow
        };

        _context.Accidentes.Add(accidente);
        await _context.SaveChangesAsync();

        return (await ObtenerPorIdAsync(accidente.Id))!;
    }

    public async Task<AccidenteResponseDto?> ActualizarEstadoAsync(
        int id,
        string estadoCaso,
        string juzgadoOInstitucion,
        string numeroCuadernoInvestigacion,
        string motivoPase)
    {
        var accidente = await _context.Accidentes.FindAsync(id);
        if (accidente == null) return null;

        accidente.EstadoCaso = estadoCaso;
        accidente.JuzgadoOInstitucion = juzgadoOInstitucion;
        accidente.NumeroCuadernoInvestigacion = numeroCuadernoInvestigacion;
        accidente.MotivoPase = motivoPase;

        await _context.SaveChangesAsync();
        return await ObtenerPorIdAsync(id);
    }

    private static AccidenteResponseDto Mapear(Accidente a)
    {
        return new AccidenteResponseDto
        {
            Id = a.Id,
            CodigoCaso = a.CodigoCaso,
            FechaHora = a.FechaHora,
            TipoAccidente = a.TipoAccidente,
            Gravedad = a.Gravedad,
            Distrito = a.Distrito,
            ZonaBarrio = a.ZonaBarrio,
            DireccionReferencia = a.DireccionReferencia,
            Latitud = a.Latitud,
            Longitud = a.Longitud,
            CondicionClimatica = a.CondicionClimatica,
            EstadoCalzada = a.EstadoCalzada,
            EstadoCaso = a.EstadoCaso,
            JuzgadoOInstitucion = a.JuzgadoOInstitucion,
            NumeroCuadernoInvestigacion = a.NumeroCuadernoInvestigacion,
            MotivoPase = a.MotivoPase,
            Observaciones = a.Observaciones,
            CreatedAt = a.CreatedAt,
            OficialAsignadoId = a.OficialAsignadoId
        };
    }
}