using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;
using ExamenGrupal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamenGrupal.Controllers;

[ApiController]
[Route("api/v1/accidentes")]
public class AccidentesController : ControllerBase
{
    private readonly IAccidenteService _accidenteService;

    public AccidentesController(IAccidenteService accidenteService)
    {
        _accidenteService = accidenteService;
    }

    [HttpGet]
    public async Task<List<AccidenteResponseDto>> Listar(
        [FromQuery] string? distrito,
        [FromQuery] string? gravedad,
        [FromQuery] DateTime? fechaDesde)
    {
        return await _accidenteService.ListarAsync(distrito, gravedad, fechaDesde);
    }

    [HttpGet("{id:int}")]
    public async Task<AccidenteResponseDto?> ObtenerPorId(int id)
    {
        return await _accidenteService.ObtenerPorIdAsync(id);
    }

    [HttpPost]
    public async Task<AccidenteResponseDto> Crear(AccidenteRequestDto request)
    {
        return await _accidenteService.CrearAsync(request);
    }

    [HttpPatch("{id:int}/estado")]
    public async Task<AccidenteResponseDto?> ActualizarEstado(
        int id,
        ActualizarEstadoAccidenteRequestDto request)
    {
        return await _accidenteService.ActualizarEstadoAsync(
            id,
            request.EstadoCaso,
            request.JuzgadoOInstitucion,
            request.NumeroCuadernoInvestigacion,
            request.MotivoPase);
    }
}
