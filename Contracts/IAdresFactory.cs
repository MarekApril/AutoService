using System.Collections.Generic;
using AutoServis.Models;

namespace AutoServis.Contracts
{
    public interface IAdresFactory
    {
        int Create(CreateAdresDto dto);
        AdresDto GetById(int id);
        IEnumerable<AdresDto> GetAll();
        bool Delete(int id);
    }
}