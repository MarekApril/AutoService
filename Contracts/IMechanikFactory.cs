using System.Collections.Generic;
using AutoServis.Models;

namespace AutoServis.Contracts
{
    public interface IMechanikFactory
    {
        int Create(MechanikDto dto);
        public IEnumerable<MechanikDto> GetAll();
        bool Delete(int id);
        MechanikDto GetById(int id);
        MechanikDto Update(int id, MechanikDto dto);
    }
}