namespace ExamenGrupal.DTOs.Requests;

public class ActualizarEstadoAccidenteRequestDto
{
    public string EstadoCaso { get; set; } = string.Empty;
    public string JuzgadoOInstitucion { get; set; } = string.Empty;
    public string NumeroCuadernoInvestigacion { get; set; } = string.Empty;
    public string MotivoPase { get; set; } = string.Empty;
}
