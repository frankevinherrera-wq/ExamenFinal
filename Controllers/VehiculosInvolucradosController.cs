using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;
using ExamenGrupal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamenGrupal.Controllers;

[ApiController]
[Route("api/v1")]
public class VehiculosInvolucradosController : ControllerBase
{
    private readonly IVehiculoInvolucradoService _vehiculoService;

    public VehiculosInvolucradosController(IVehiculoInvolucradoService vehiculoService)
    {
        _vehiculoService = vehiculoService;
    }

    [HttpPost("vehiculos-involucrados")]
    public async Task<VehiculoInvolucradoResponseDto> Crear(VehiculoInvolucradoRequestDto request)
    {
        return await _vehiculoService.CrearAsync(request);
    }

    [HttpGet("accidentes/{accidenteId:int}/vehiculos")]
    public async Task<ICollection<VehiculoInvolucradoResponseDto>> ListarPorAccidente(int accidenteId)
    {
        return await _vehiculoService.ListarPorAccidenteAsync(accidenteId);
    }
}
