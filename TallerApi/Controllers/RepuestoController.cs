using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Taller.Application.Contracts.Services;
using Taller.Domain.EntityModels;

namespace TallerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepuestoController : Controller
    {
        public RepuestoController(IRepuestoService service)
        {
            _service = service;
        }
        readonly IRepuestoService _service;

        [HttpGet]
        [ActionName(nameof(List))]
        public ActionResult<IEnumerable<Repuesto>> List()
        {
            return _service.List().ToList();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(Get))]
        public ActionResult<Repuesto> Get(int id) 
        {
            return _service.Get(id);
        }

        [HttpPost]
        [ActionName(nameof(Post))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Post(Repuesto repuesto) 
        {
            _service.Insert(repuesto);
            return CreatedAtAction(nameof(Get), new {id = repuesto.RepuestoId}, repuesto);
        }

        [HttpPut]
        [ActionName(nameof(Put))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(Repuesto repuesto)
        {
            try
            {
                _service.Update(repuesto);
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
