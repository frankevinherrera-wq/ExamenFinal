using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;
using ExamenGrupal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamenGrupal.Controllers;

[ApiController]
[Route("api/v1/personas-involucradas")]
public class PersonasInvolucradasController : ControllerBase
{
    private readonly IPersonaInvolucradaService _personaService;

    public PersonasInvolucradasController(IPersonaInvolucradaService personaService)
    {
        _personaService = personaService;
    }

    [HttpPost]
    public async Task<PersonaInvolucradaResponseDto> Crear(PersonaInvolucradaRequestDto request)
    {
        return await _personaService.CrearAsync(request);
    }

    [HttpPatch("{id:int}/alcoholemia")]
    public async Task<PersonaInvolucradaResponseDto?> ActualizarAlcoholemia(
        int id,
        ActualizarAlcoholemiaRequestDto request)
    {
        return await _personaService.ActualizarAlcoholemiaAsync(
            id,
            request.GradoAlcoholemiaGral,
            request.EstadoAlcoholemia,
            request.NumeroActaDosaje,
            request.Laboratorio);
    }
}
