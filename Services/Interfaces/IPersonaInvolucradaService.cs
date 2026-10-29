using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;

namespace ExamenGrupal.Services.Interfaces;

public interface IPersonaInvolucradaService
{
    Task<PersonaInvolucradaResponseDto> CrearAsync(PersonaInvolucradaRequestDto request);

    Task<PersonaInvolucradaResponseDto?> ActualizarAlcoholemiaAsync(
        int id,
        decimal gradoAlcoholemiaGral,
        string estadoAlcoholemia,
        string numeroActaDosaje,
        string laboratorio);
}
