using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;

namespace ExamenGrupal.Services.Interfaces;

public interface IPeritajeTecnicoService
{
    Task<PeritajeTecnicoResponseDto> CrearAsync(PeritajeTecnicoRequestDto request);
}
