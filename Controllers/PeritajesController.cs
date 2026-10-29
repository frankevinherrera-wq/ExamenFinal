using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;
using ExamenGrupal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamenGrupal.Controllers;

[ApiController]
[Route("api/v1/peritajes")]
public class PeritajesController : ControllerBase
{
    private readonly IPeritajeTecnicoService _peritajeService;

    public PeritajesController(IPeritajeTecnicoService peritajeService)
    {
        _peritajeService = peritajeService;
    }

    [HttpPost]
    public async Task<PeritajeTecnicoResponseDto> Crear(PeritajeTecnicoRequestDto request)
    {
        return await _peritajeService.CrearAsync(request);
    }
}
