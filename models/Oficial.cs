using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenGrupal.models
{
    public class Oficial
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Grado { get; set; } = string.Empty;
        public string NumeroEscalafon { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string? Unidad { get; set; }
        public bool Activo { get; set; }
        public DateTime CreatedAt { get; set; }


        public ICollection<Accidente> Accidentes { get; set; } = new List<Accidente>();
        public ICollection<PeritajeTecnico> PeritajesTecnicos { get; set; } = new List<PeritajeTecnico>();

    }
}