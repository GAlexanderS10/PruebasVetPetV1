using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasVetPetV1.Models;

namespace PruebasVetPetV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly PRUEBASVETPETContext _dbContext;

        public ClienteController(PRUEBASVETPETContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var clientes = await _dbContext.Clientes.ToListAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al obtener los clientes.");
            }
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var cliente = await _dbContext.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al obtener el cliente.");
            }
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
        {
            try
            {
                _dbContext.Clientes.Add(cliente);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.ClienteId }, cliente);
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al crear el cliente.");
            }
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Cliente updatedCliente)
        {
            try
            {
                var cliente = await _dbContext.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                cliente.Nombres = updatedCliente.Nombres;
                cliente.Apellidos = updatedCliente.Apellidos;
                cliente.TipoDocumento = updatedCliente.TipoDocumento;
                cliente.NroIdentidad = updatedCliente.NroIdentidad;
                cliente.Email = updatedCliente.Email;
                cliente.Telefono = updatedCliente.Telefono;

                await _dbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al actualizar el cliente.");
            }
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                var cliente = await _dbContext.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al eliminar el cliente.");
            }
        }
    }
}