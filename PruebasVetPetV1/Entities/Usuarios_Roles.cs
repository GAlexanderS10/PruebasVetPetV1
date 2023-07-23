namespace PruebasVetPetV1.Entities
{
    public class Usuarios_Roles
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
    }
}
