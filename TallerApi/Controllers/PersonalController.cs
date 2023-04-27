using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Application.Contracts.Services;
using Taller.Application.Services;
using Taller.Domain.EntityModels;

namespace TallerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : Controller
    {
        public PersonalController(IPersonalService service)
        {
            _service = service;
        }
        readonly IPersonalService _service;

        [HttpGet]
        [ActionName(nameof(List))]
        public ActionResult<IEnumerable<Personal>> List()
        {
            return _service.List().ToList();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(Get))]
        public ActionResult<Personal> Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPost]
        [ActionName(nameof(Post))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Post(Personal personal)
        {
            _service.Insert(personal);
            return CreatedAtAction(nameof(Get), new { id = personal.PersonalId }, personal);
        }

        [HttpPut]
        [ActionName(nameof(Put))]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(Personal personal)
        {
            try
            {
                _service.Update(personal);
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
