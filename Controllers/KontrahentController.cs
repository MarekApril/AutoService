using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoServis.Contracts;
using AutoServis.Entities;
using AutoServis.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoServis.Controllers
{
    [Route("kontrahent")]
    public class KontrahentController : ControllerBase
    {
        private IKontrahentFactory _kontrahentFactory;

        public KontrahentController(IKontrahentFactory kontrahentFactory)
        {
            _kontrahentFactory = kontrahentFactory;
        }

        [HttpPost]
        public int Post([FromBody] CreateKontrahentDto dto)
        {
            var adresId = _kontrahentFactory.Create(dto);
            return adresId;
        }

        [HttpGet("{id}")]
        public ActionResult<KontrahentDto> GetById([FromRoute] int id)
        {
            var adres = _kontrahentFactory.GetById(id);
            return Ok(adres);
        }

        [HttpGet]
        public ActionResult<IEnumerable<KontrahentDto>> GetAll()
        {
            var kontrahents = _kontrahentFactory.GetAll();
            return Ok(kontrahents);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _kontrahentFactory.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRestaurant([FromBody] UpdateKontrahentDto dto, [FromRoute] int id)
        {
            var isUpdated = _kontrahentFactory.Update(id, dto);
            return Ok(isUpdated);
        }
    }
}
