using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PruebasVetPetV1.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cita = new HashSet<Citum>();
            Mascota = new HashSet<Mascotum>();
        }

        public int ClienteId { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string TipoDocumento { get; set; } = null!;
        public string NroIdentidad { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Telefono { get; set; }

        [JsonIgnore]
        public virtual ICollection<Citum> Cita { get; set; }
        [JsonIgnore]
        public virtual ICollection<Mascotum> Mascota { get; set; }
    }
}
