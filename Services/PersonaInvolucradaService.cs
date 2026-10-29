using ExamenGrupal.Data;
using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;
using ExamenGrupal.models;
using ExamenGrupal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamenGrupal.Services;

public class PersonaInvolucradaService : IPersonaInvolucradaService
{
    private readonly AppDbContext _context;

    public PersonaInvolucradaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PersonaInvolucradaResponseDto> CrearAsync(PersonaInvolucradaRequestDto request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (!request.AccidenteId.HasValue)
        {
            throw new ArgumentException("El accidente es obligatorio.", nameof(request));
        }

        var accidenteExiste = await _context.Accidentes
            .AnyAsync(accidente => accidente.Id == request.AccidenteId.Value);

        if (!accidenteExiste)
        {
            throw new KeyNotFoundException("No se encontro el accidente.");
        }

        if (request.VehiculoId.HasValue)
        {
            var vehiculo = await _context.VehiculosInvolucrados
                .FirstOrDefaultAsync(item => item.Id == request.VehiculoId.Value);

            if (vehiculo == null)
            {
                throw new KeyNotFoundException("No se encontro el vehiculo.");
            }

            if (vehiculo.AccidenteId != request.AccidenteId.Value)
            {
                throw new ArgumentException("El vehiculo no pertenece al accidente indicado.", nameof(request));
            }
        }

        var persona = new PersonaInvolucrada
        {
            Nombres = request.Nombres,
            Apellidos = request.Apellidos,
            Ci = request.Ci,
            Telefono = request.Telefono,
            Rol = request.Rol,
            NumeroLicencia = request.NumeroLicencia,
            CategoriaLicencia = request.CategoriaLicencia,
            GradoAlcoholemiaGral = request.GradoAlcoholemiaGral,
            EstadoAlcoholemia = request.EstadoAlcoholemia,
            NumeroActaDosaje = request.NumeroActaDosaje,
            Laboratorio = request.Laboratorio,
            EstadoSalud = request.EstadoSalud,
            CentroMedicoTraslado = request.CentroMedicoTraslado,
            DiagnosticoPreliminar = request.DiagnosticoPreliminar,
            AccidenteId = request.AccidenteId.Value,
            VehiculoId = request.VehiculoId,
            CreatedAt = DateTime.UtcNow
        };

        _context.PersonasInvolucradas.Add(persona);
        await _context.SaveChangesAsync();

        return Mapear(persona);
    }

    public async Task<PersonaInvolucradaResponseDto?> ActualizarAlcoholemiaAsync(
        int id,
        decimal gradoAlcoholemiaGral,
        string estadoAlcoholemia,
        string numeroActaDosaje,
        string laboratorio)
    {
        var persona = await _context.PersonasInvolucradas
            .FirstOrDefaultAsync(persona => persona.Id == id);

        if (persona == null)
        {
            return null;
        }

        persona.GradoAlcoholemiaGral = gradoAlcoholemiaGral;
        persona.EstadoAlcoholemia = estadoAlcoholemia;
        persona.NumeroActaDosaje = numeroActaDosaje;
        persona.Laboratorio = laboratorio;

        await _context.SaveChangesAsync();
        return Mapear(persona);
    }

    private static PersonaInvolucradaResponseDto Mapear(PersonaInvolucrada persona)
    {
        return new PersonaInvolucradaResponseDto
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
        };
    }
}
