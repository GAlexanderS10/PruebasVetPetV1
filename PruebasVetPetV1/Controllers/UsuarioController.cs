using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasVetPetV1.Entities;
using PruebasVetPetV1.Models;

namespace PruebasVetPetV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly PRUEBASVETPETContext _dbContext;

        public UsuarioController(PRUEBASVETPETContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListarUsuarios()
        {
            var usuarios = await _dbContext.Usuarios.ToListAsync();

            return usuarios;
        }

        // GET: api/RolxUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios_Roles>>> GetUsuarios()
        {
            var usuarios = await _dbContext.Usuarios
                .Select(u => new Usuarios_Roles
                {
                    UsuarioId = u.UsuarioId,
                    Nombres = u.Nombres,
                    Apellidos = u.Apellidos,
                    Nacionalidad = u.Nacionalidad,
                    TipoDocumento = u.TipoDocumento,   
                    NroIdentidad = u.NroIdentidad, 
                    Email = u.Email,
                    UserName = u.UserName,
                    Passwo = u.Passwo,
                    RolId = u.RolId
                })
                .ToListAsync();

            return usuarios;
        }

        // GET: api/RolxUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios_Roles>> GetUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios
                .Where(u => u.UsuarioId == id)
                .Select(u => new Usuarios_Roles
                {
                    UsuarioId = u.UsuarioId,
                    Nombres = u.Nombres,
                    Apellidos = u.Apellidos,
                    Nacionalidad = u.Nacionalidad,
                    TipoDocumento = u.TipoDocumento,
                    NroIdentidad = u.NroIdentidad,
                    Email = u.Email,
                    UserName = u.UserName,
                    Passwo = u.Passwo,
                    RolId = u.RolId
                })
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST: api/RolxUsuarios
        [HttpPost]
        public async Task<ActionResult<Usuarios_Roles>> PostUsuario(Usuarios_Roles usuario)
        {
            var usuarioEntity = new Usuario
            {
                 UsuarioId = usuario.UsuarioId,
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Nacionalidad = usuario.Nacionalidad,
                    TipoDocumento = usuario.TipoDocumento,   
                    NroIdentidad = usuario.NroIdentidad, 
                    Email = usuario.Email,
                    UserName = usuario.UserName,
                    Passwo = usuario.Passwo,
                    RolId = usuario.RolId
            };

            // Encriptar la contraseña utilizando bcrypt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(usuarioEntity.Passwo);
            usuarioEntity.Passwo = passwordHash;

            _dbContext.Usuarios.Add(usuarioEntity);
            await _dbContext.SaveChangesAsync();

            usuario.UsuarioId = usuarioEntity.UsuarioId;

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, usuario);
        }

        // POST: api/RolxUsuarios/login
        [HttpPost("Login")]
        public async Task<ActionResult<Usuarios_Roles>> Login(LoginRequest request)
        {
            var usuarioEncontrado = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (usuarioEncontrado == null)
            {
                return NotFound("El usuario no existe");
            }

            // Verificar la contraseña utilizando bcrypt
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(request.Passwo, usuarioEncontrado.Passwo);

            if (!passwordMatch)
            {
                return Unauthorized("La contraseña es incorrecta");
            }

            var usuarioRolxUsuarios = new Usuarios_Roles
            {
                UsuarioId = usuarioEncontrado.UsuarioId,
                Nombres = usuarioEncontrado.Nombres,
                Apellidos = usuarioEncontrado.Apellidos,
                Nacionalidad = usuarioEncontrado.Nacionalidad,
                TipoDocumento = usuarioEncontrado.TipoDocumento,
                NroIdentidad = usuarioEncontrado.NroIdentidad,
                Email  = usuarioEncontrado.Email,
                UserName = usuarioEncontrado.UserName,
                Passwo = usuarioEncontrado.Passwo,
                RolId = usuarioEncontrado.RolId
            };

            return Ok(usuarioRolxUsuarios);
        }


        // PUT: api/RolxUsuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuarios_Roles usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            var usuarioEntity = await _dbContext.Usuarios.FindAsync(id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }

            usuarioEntity.Nombres = usuario.Nombres;
            usuarioEntity.Apellidos = usuario.Apellidos;
            usuarioEntity.UserName = usuario.UserName;
            usuarioEntity.Passwo = usuario.Passwo;
            usuarioEntity.RolId = usuario.RolId;

            // Encriptar la contraseña utilizando bcrypt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(usuarioEntity.Passwo);
            usuarioEntity.Passwo = passwordHash;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/RolxUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}