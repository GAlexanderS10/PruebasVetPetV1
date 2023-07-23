using System;
using System.Collections.Generic;

namespace PruebasVetPetV1.Models
{
    public partial class Citum
    {
        public int NumCita { get; set; }
        public string? DniPropietario { get; set; }
        public string? NombreMascota { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public string? Servicio { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public string? Estado { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
