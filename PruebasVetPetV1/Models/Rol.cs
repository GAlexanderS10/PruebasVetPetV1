using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PruebasVetPetV1.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int RolId { get; set; }
        public string Nombre { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
