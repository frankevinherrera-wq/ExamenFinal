using System.ComponentModel.DataAnnotations;

namespace ExamenGrupal.DTOs.Requests;

public class PeritajeTecnicoRequestDto
{
    [Required]
    public DateTime? FechaPeritaje { get; set; }

    [Range(typeof(decimal), "0", "79228162514264337593543950335")]
    public decimal? VelocidadEstimadaImpactoKmh { get; set; }

    [Range(typeof(decimal), "0", "79228162514264337593543950335")]
    public decimal? HuellaFrenadoMetros { get; set; }

    [Required]
    public string FactorDeterminante { get; set; } = string.Empty;

    [Required]
    public string Conclusiones { get; set; } = string.Empty;

    [MaxLength(255)]
    [Url(ErrorMessage = "El formato de la URL del croquis no es valido.")]
    public string? CroquisUrl { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? AccidenteId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? PeritoId { get; set; }
}
