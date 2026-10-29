using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenGrupal.models
{
    public class Accidente
    {
        public int Id { get; set; }
        public string CodigoCaso { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; }
        public string TipoAccidente { get; set; } = string.Empty;
        public string Gravedad { get; set; } = string.Empty;
        public string Distrito { get; set; } = string.Empty;
        public string ZonaBarrio { get; set; } = string.Empty;
        public string DireccionReferencia { get; set; } = string.Empty;
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public string? CondicionClimatica { get; set; }
        public string? EstadoCalzada { get; set; }
        public string? EstadoCaso { get; set; }
        public string? JuzgadoOInstitucion { get; set; }
        public string? NumeroCuadernoInvestigacion { get; set; }
        public string? MotivoPase { get; set; }
        public string? Observaciones { get; set; }
        public DateTime CreatedAt { get; set; }



        public int? OficialAsignadoId { get; set; }
        public Oficial? OficialAsignado { get; set; }

        public PeritajeTecnico? PeritajeTecnico { get; set; }
        public ICollection<VehiculoInvolucrado> VehiculosInvolucrados { get; set; } = new List<VehiculoInvolucrado>();
        public ICollection<PersonaInvolucrada> PersonasInvolucradas { get; set; } = new List<PersonaInvolucrada>();

    }
}