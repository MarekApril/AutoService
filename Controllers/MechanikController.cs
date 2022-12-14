using System.Collections.Generic;
using AutoServis.Models;
using Microsoft.AspNetCore.Mvc;
using AutoServis.Contracts;

namespace AutoServis.Controllers
{
    [Route("mechanik")]
    public class MechanikController : ControllerBase
    {
        private IMechanikFactory _mechanikFactory;

        public MechanikController(IMechanikFactory mechanikFactory)
        {
            _mechanikFactory = mechanikFactory;
        }

        [HttpPost]
        public int Post([FromBody] MechanikDto dto)
        {
            var adresId = _mechanikFactory.Create(dto);
            return adresId;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MechanikDto>> GetAll()
        {
            var kontrahents = _mechanikFactory.GetAll();
            return Ok(kontrahents);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _mechanikFactory.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<MechanikDto> GetById([FromRoute] int id)
        {
            var mechanik = _mechanikFactory.GetById(id);
            return Ok(mechanik);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRestaurant([FromBody] MechanikDto dto, [FromRoute] int id)
        {
            var isUpdated = _mechanikFactory.Update(id, dto);
            return Ok(isUpdated);
        }
    }
}
