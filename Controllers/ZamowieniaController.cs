using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoServis.Contracts;
using AutoServis.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoServis.Controllers
{
    [Route("zamowienia")]
    public class ZamowieniaController : ControllerBase
    {
        private IZamowieniaFactory _zamowienia;

        public ZamowieniaController(IZamowieniaFactory zamowienia)
        {
            _zamowienia = zamowienia;
        }

        [HttpPost]
        public int Post([FromBody] CreateZamowieniaDto dto)
        {
            var adresId = _zamowienia.Create(dto);
            return adresId;
        }

        [HttpGet("{id}")]
        public ActionResult<ZamowieniaDto> GetById([FromRoute] int id)
        {
            var adres = _zamowienia.GetById(id);
            return Ok(adres);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _zamowienia.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRestaurant([FromBody] ZamowieniaDto dto, [FromRoute] int id)
        {
            var isUpdated = _zamowienia.Update(id, dto);
            return Ok(isUpdated);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ZamowieniaDto>> GetAll()
        {
            var zamowieniaDto = _zamowienia.GetAll();
            return Ok(zamowieniaDto);
        }
    }
}
