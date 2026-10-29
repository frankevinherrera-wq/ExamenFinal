using System.ComponentModel.DataAnnotations;

namespace ExamenGrupal.DTOs.Requests;

public class OficialRequestDto
{
    [Required]
    [MaxLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Grado { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string NumeroEscalafon { get; set; } = string.Empty;

    [Required]
    [MaxLength(80)]
    public string Cargo { get; set; } = string.Empty;

    [MaxLength(80)]
    public string? Unidad { get; set; }

    [Required]
    public bool? Activo { get; set; }
}
