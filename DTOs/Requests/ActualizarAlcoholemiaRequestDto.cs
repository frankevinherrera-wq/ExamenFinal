namespace ExamenGrupal.DTOs.Requests;

public class ActualizarAlcoholemiaRequestDto
{
    public decimal GradoAlcoholemiaGral { get; set; }
    public string EstadoAlcoholemia { get; set; } = string.Empty;
    public string NumeroActaDosaje { get; set; } = string.Empty;
    public string Laboratorio { get; set; } = string.Empty;
}
