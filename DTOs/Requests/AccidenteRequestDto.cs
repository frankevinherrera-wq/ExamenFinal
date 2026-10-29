using System.ComponentModel.DataAnnotations;

namespace ExamenGrupal.DTOs.Requests;

public class AccidenteRequestDto
{
    [Required(ErrorMessage = "El codigo de caso es obligatorio.")]
    [MaxLength(30)]
    public string CodigoCaso { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha y hora son obligatorias.")]
    public DateTime? FechaHora { get; set; }

    [Required(ErrorMessage = "El tipo de accidente es obligatorio.")]
    [MaxLength(60)]
    public string TipoAccidente { get; set; } = string.Empty;

    [Required(ErrorMessage = "La gravedad es obligatoria.")]
    [MaxLength(30)]
    public string Gravedad { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Distrito { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string ZonaBarrio { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string DireccionReferencia { get; set; } = string.Empty;

    [Range(typeof(decimal), "-90", "90")]
    public decimal? Latitud { get; set; }

    [Range(typeof(decimal), "-180", "180")]
    public decimal? Longitud { get; set; }
    [MaxLength(40)]
    public string? CondicionClimatica { get; set; }
    [MaxLength(40)]
    public string? EstadoCalzada { get; set; }
    [MaxLength(40)]
    public string? EstadoCaso { get; set; }

    [MaxLength(200)]
    public string? JuzgadoOInstitucion { get; set; }

    [MaxLength(50)]
    public string? NumeroCuadernoInvestigacion { get; set; }

    [MaxLength(500)]
    public string? MotivoPase { get; set; }

    public string? Observaciones { get; set; }

    [Range(1, int.MaxValue)]
    public int? OficialAsignadoId { get; set; }
}
