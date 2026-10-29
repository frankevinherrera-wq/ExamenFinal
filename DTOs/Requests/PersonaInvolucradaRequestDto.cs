using System.ComponentModel.DataAnnotations;

namespace ExamenGrupal.DTOs.Requests;

public class PersonaInvolucradaRequestDto
{
    [Required]
    [MaxLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [Required]
    [MaxLength(25)]
    public string Ci { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Telefono { get; set; }

    [MaxLength(30)]
    public string? Rol { get; set; }

    [MaxLength(30)]
    public string? NumeroLicencia { get; set; }

    [MaxLength(10)]
    public string? CategoriaLicencia { get; set; }

    [Range(0, 99.99)]
    public decimal? GradoAlcoholemiaGral { get; set; }

    [MaxLength(20)]
    public string? EstadoAlcoholemia { get; set; }

    [MaxLength(40)]
    public string? NumeroActaDosaje { get; set; }

    [MaxLength(120)]
    public string? Laboratorio { get; set; }

    [MaxLength(30)]
    public string? EstadoSalud { get; set; }

    [MaxLength(120)]
    public string? CentroMedicoTraslado { get; set; }

    public string? DiagnosticoPreliminar { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? AccidenteId { get; set; }

    [Range(1, int.MaxValue)]
    public int? VehiculoId { get; set; }
}
