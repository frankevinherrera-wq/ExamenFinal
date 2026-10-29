using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenGrupal.models
{
    public class PeritajeTecnico
    {
        public int Id { get; set; }
        public DateTime FechaPeritaje { get; set; }
        public decimal? VelocidadEstimadaImpactoKmh { get; set; }
        public decimal? HuellaFrenadoMetros { get; set; }
        public string FactorDeterminante { get; set; } = string.Empty;
        public string Conclusiones { get; set; } = string.Empty;
        public string? CroquisUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public int AccidenteId { get; set; }
        public Accidente? Accidente { get; set; }

        public int PeritoId { get; set; }
        public Oficial? Perito { get; set; }
    }
}