using ExamenGrupal.DTOs.Requests;
using ExamenGrupal.DTOs.Responses;

namespace ExamenGrupal.Services.Interfaces;

public interface IVehiculoInvolucradoService
{
    Task<VehiculoInvolucradoResponseDto> CrearAsync(VehiculoInvolucradoRequestDto request);

    Task<ICollection<VehiculoInvolucradoResponseDto>> ListarPorAccidenteAsync(int accidenteId);
}
