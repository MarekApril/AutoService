using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoServis.Contracts;
using AutoServis.Entities;
using AutoServis.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutoServis.Controllers
{
   // [EnableCors("CorsApi")]
    [Route("adres")]
    public class AdresController : ControllerBase
    {
        private IAdresFactory _adresFactory;
        private AutoServiceDbContext _autoServiceDb;

        public AdresController(AutoServiceDbContext autoServiceDb, IAdresFactory adresFactory)
        {
            _autoServiceDb = autoServiceDb;
            _adresFactory = adresFactory;
        }

        [HttpPost]
        public int Post([FromBody] CreateAdresDto dto)
        {
            var adresId = _adresFactory.Create(dto);
            return adresId;
        }

        [HttpGet("{id}")]
        public ActionResult<AdresDto> GetById([FromRoute] int id)
        {
            var adres = _adresFactory.GetById(id);
            return Ok(adres);
        }

        [HttpGet]
        public ActionResult<IEnumerable<KontrahentDto>> GetAll()
        {
            var kontrahents = _adresFactory.GetAll();
            return Ok(kontrahents);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _adresFactory.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
