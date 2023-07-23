using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebasVetPetV1.Models;

namespace PruebasVetPetV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly PRUEBASVETPETContext _dbContext;

        public ServicioController(PRUEBASVETPETContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Servicio
        [HttpGet]
        public ActionResult<IEnumerable<Servicio>> GetServicios()
        {
            try
            {
                var servicios = _dbContext.Servicios;
                return Ok(servicios);
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al obtener los servicios.");
            }
        }

        // GET: api/Servicio/5
        [HttpGet("{id}")]
        public ActionResult<Servicio> GetServicio(int id)
        {
            try
            {
                var servicio = _dbContext.Servicios.Find(id);
                if (servicio == null)
                {
                    return NotFound();
                }
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al obtener el servicio.");
            }
        }

        // POST: api/Servicio
        [HttpPost]
        public ActionResult<Servicio> CreateServicio(Servicio servicio)
        {
            try
            {
                _dbContext.Servicios.Add(servicio);
                _dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetServicio), new { id = servicio.ServicioId }, servicio);
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al crear el servicio.");
            }
        }

        // PUT: api/Servicio/5
        [HttpPut("{id}")]
        public IActionResult UpdateServicio(int id, Servicio updatedServicio)
        {
            try
            {
                var servicio = _dbContext.Servicios.Find(id);
                if (servicio == null)
                {
                    return NotFound();
                }

                servicio.Nombre = updatedServicio.Nombre;
                servicio.Descripcion = updatedServicio.Descripcion;
                servicio.Precio = updatedServicio.Precio;

                _dbContext.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al actualizar el servicio.");
            }
        }

        // DELETE: api/Servicio/5
        [HttpDelete("{id}")]
        public IActionResult DeleteServicio(int id)
        {
            try
            {
                var servicio = _dbContext.Servicios.Find(id);
                if (servicio == null)
                {
                    return NotFound();
                }

                _dbContext.Servicios.Remove(servicio);
                _dbContext.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return StatusCode(500, "Error al eliminar el servicio.");
            }
        }
    }
}