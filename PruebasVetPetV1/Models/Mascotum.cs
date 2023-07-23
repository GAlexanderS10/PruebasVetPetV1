using System;
using System.Collections.Generic;

namespace PruebasVetPetV1.Models
{
    public partial class Mascotum
    {
        public int MascotaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especie { get; set; } = null!;
        public string Raza { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public string Color { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Microchip { get; set; } = null!;
        public string Registro { get; set; } = null!;
        public int? ClienteId { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
