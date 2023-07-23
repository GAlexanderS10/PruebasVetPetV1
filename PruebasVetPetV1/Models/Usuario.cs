using System;
using System.Collections.Generic;

namespace PruebasVetPetV1.Models
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Nacionalidad { get; set; } = null!;
        public string TipoDocumento { get; set; } = null!;
        public string NroIdentidad { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Passwo { get; set; } = null!;
        public int RolId { get; set; }

        public virtual Rol Rol { get; set; } = null!;
    }
}
