using System.Collections.Generic;
using AutoServis.Contracts;
using AutoServis.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoServis.Controllers
{
    [Route("samochod")]
    public class SamochodController : ControllerBase
    {
        private ISamochodFactory _samochodFactory;

        public SamochodController(ISamochodFactory samochodFactory)
        {
            _samochodFactory = samochodFactory;
        }

        [HttpPost]
        public int Post([FromBody] SamochodDto dto)
        {
            var adresId = _samochodFactory.Create(dto);
            return adresId;
        }

        [HttpGet("{id}")]
        public ActionResult<SamochodDto> GetById([FromRoute] int id)
        {
            var mechanik = _samochodFactory.GetById(id);
            return Ok(mechanik);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _samochodFactory.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }


        [HttpGet]
        public ActionResult<IEnumerable<SamochodDto>> GetAll()
        {
            var samochod = _samochodFactory.GetAll();
            return Ok(samochod);
        }
    }
}
