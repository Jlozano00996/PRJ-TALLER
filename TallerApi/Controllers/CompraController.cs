using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Application.Contracts.Services;
using Taller.Domain.EntityModels;

namespace TallerApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CompraController : Controller
    {
        public CompraController(ICompraService service)
        {
            _service = service;
        }
        readonly ICompraService _service;

        [HttpGet]
        [ActionName(nameof(List))]
        public ActionResult<IEnumerable<Compra>>List()
        {
            return _service.List().ToList();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(Get))]
        public ActionResult<Compra> Get(int id) 
        {
            return _service.Get(id);
        }

        [HttpPost]
        [ActionName(nameof(Post))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Post(Compra compra)
        {
            _service.Insert(compra);
            return CreatedAtAction(nameof(Get), new { id = compra.CompraId }, compra);
        }

        [HttpPut]
        [ActionName(nameof(Put))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(Compra compra)
        {
            try
            {
                _service.Update(compra);
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
