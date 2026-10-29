using ExamenGrupal.Data;
using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;
using ExamenGrupal.models;
using ExamenGrupal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamenGrupal.Services;

public class VehiculoInvolucradoService : IVehiculoInvolucradoService
{
    private readonly AppDbContext _context;

    public VehiculoInvolucradoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VehiculoInvolucradoResponseDto> CrearAsync(VehiculoInvolucradoRequestDto request)
    {

        if (!request.AccidenteId.HasValue || !request.SoatVigente.HasValue)
        {
            throw new ArgumentException("Los datos del vehiculo estan incompletos.", nameof(request));
        }

        var accidenteExiste = await _context.Accidentes
            .AnyAsync(accidente => accidente.Id == request.AccidenteId.Value);

        if (!accidenteExiste)
        {
            throw new KeyNotFoundException("No se encontro el accidente.");
        }

        var vehiculo = new VehiculoInvolucrado
        {
            Placa = request.Placa,
            Marca = request.Marca,
            Modelo = request.Modelo,
            TipoVehiculo = request.TipoVehiculo,
            Color = request.Color,
            NumeroChasis = request.NumeroChasis,
            SoatVigente = request.SoatVigente.Value,
            Aseguradora = request.Aseguradora,
            DescripcionDanios = request.DescripcionDanios,
            RemolcadoA = request.RemolcadoA,
            AccidenteId = request.AccidenteId.Value,
            CreatedAt = DateTime.UtcNow
        };

        _context.VehiculosInvolucrados.Add(vehiculo);
        await _context.SaveChangesAsync();

        return Mapear(vehiculo);
    }

    public async Task<ICollection<VehiculoInvolucradoResponseDto>> ListarPorAccidenteAsync(int accidenteId)
    {
        var vehiculos = await _context.VehiculosInvolucrados
            .AsNoTracking()
            .Include(vehiculo => vehiculo.PersonasInvolucradas)
            .Where(vehiculo => vehiculo.AccidenteId == accidenteId)
            .OrderBy(vehiculo => vehiculo.Id)
            .ToListAsync();

        return vehiculos.Select(Mapear).ToList();
    }

    private static VehiculoInvolucradoResponseDto Mapear(VehiculoInvolucrado vehiculo)
    {
        return new VehiculoInvolucradoResponseDto
        {
            Id = vehiculo.Id,
            AccidenteId = vehiculo.AccidenteId,
            Placa = vehiculo.Placa,
            Marca = vehiculo.Marca,
            Modelo = vehiculo.Modelo,
            TipoVehiculo = vehiculo.TipoVehiculo,
            Color = vehiculo.Color,
            NumeroChasis = vehiculo.NumeroChasis,
            SoatVigente = vehiculo.SoatVigente,
            Aseguradora = vehiculo.Aseguradora,
            DescripcionDanios = vehiculo.DescripcionDanios,
            RemolcadoA = vehiculo.RemolcadoA,
            CreatedAt = vehiculo.CreatedAt,
            PersonasInvolucradas = vehiculo.PersonasInvolucradas
                .Select(persona => new PersonaInvolucradaResponseDto
                {
                    Id = persona.Id,
                    AccidenteId = persona.AccidenteId,
                    VehiculoId = persona.VehiculoId,
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    Ci = persona.Ci,
                    Telefono = persona.Telefono,
                    Rol = persona.Rol,
                    NumeroLicencia = persona.NumeroLicencia,
                    CategoriaLicencia = persona.CategoriaLicencia,
                    GradoAlcoholemiaGral = persona.GradoAlcoholemiaGral,
                    EstadoAlcoholemia = persona.EstadoAlcoholemia,
                    NumeroActaDosaje = persona.NumeroActaDosaje,
                    Laboratorio = persona.Laboratorio,
                    EstadoSalud = persona.EstadoSalud,
                    CentroMedicoTraslado = persona.CentroMedicoTraslado,
                    DiagnosticoPreliminar = persona.DiagnosticoPreliminar,
                    CreatedAt = persona.CreatedAt
                })
                .ToList()
        };
    }
}
