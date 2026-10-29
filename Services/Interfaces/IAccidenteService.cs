using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;

namespace ExamenGrupal.Services.Interfaces;

public interface IAccidenteService
{
    Task<List<AccidenteResponseDto>> ListarAsync(
        string? distrito,
        string? gravedad,
        DateTime? fechaDesde);

    Task<AccidenteResponseDto?> ObtenerPorIdAsync(int id);

    Task<AccidenteResponseDto> CrearAsync(AccidenteRequestDto request);

    Task<AccidenteResponseDto?> ActualizarEstadoAsync(
        int id,
        string estadoCaso,
        string juzgadoOInstitucion,
        string numeroCuadernoInvestigacion,
        string motivoPase);
}
