using System.ComponentModel.DataAnnotations;

namespace ExamenGrupal.DTOs.Requests;

public class VehiculoInvolucradoRequestDto
{
    [Required]
    [MaxLength(15)]
    public string Placa { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Marca { get; set; }

    [MaxLength(50)]
    public string? Modelo { get; set; }

    [MaxLength(50)]
    public string? TipoVehiculo { get; set; }

    [MaxLength(30)]
    public string? Color { get; set; }

    [MaxLength(50)]
    public string? NumeroChasis { get; set; }

    [Required]
    public bool? SoatVigente { get; set; }

    [MaxLength(80)]
    public string? Aseguradora { get; set; }

    public string? DescripcionDanios { get; set; }

    [MaxLength(120)]
    public string? RemolcadoA { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? AccidenteId { get; set; }
}
