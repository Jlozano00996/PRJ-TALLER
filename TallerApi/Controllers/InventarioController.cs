using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Application.Contracts.Services;
using Taller.Domain.EntityModels;

namespace TallerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : Controller
    {
        public InventarioController(IInventarioService service)
        {
            _service = service;
        }
        readonly IInventarioService _service;

        [HttpGet]
        [ActionName(nameof(List))]
        public ActionResult<IEnumerable<Inventario>> List()
        {
            return _service.List().ToList();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(Get))]
        public ActionResult<Inventario> Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPost]
        [ActionName(nameof(Post))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Post(Inventario inventario)
        {
            _service.Insert(inventario);
            return CreatedAtAction(nameof(Get), new { id = inventario.InventarioId }, inventario);
        }

        [HttpPut]
        [ActionName(nameof(Put))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(Inventario inventario)
        {
            try
            {
                _service.Update(inventario);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ActionName(nameof(Delete))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
