using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Application.Contracts.Services;
using Taller.Application.Services;
using Taller.Domain.EntityModels;

namespace TallerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioController : Controller
    {
        public PrecioController(IPrecioService service)
        {
            _service = service;
        }
        readonly IPrecioService _service;

        [HttpGet]
        [ActionName(nameof(List))]
        public ActionResult<IEnumerable<Precio>> List()
        {
            return _service.List().ToList();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(Get))]
        public ActionResult<Precio> Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPost]
        [ActionName(nameof(Post))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Post(Precio precio)
        {
            _service.Insert(precio);
            return CreatedAtAction(nameof(Get), new { id = precio.PrecioId }, precio);
        }

        [HttpPut]
        [ActionName(nameof(Put))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(Precio precio)
        {
            try
            {
                _service.Update(precio);
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
