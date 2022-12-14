using System.Collections.Generic;
using AutoServis.Models;

namespace AutoServis.Contracts
{
    public interface ISamochodFactory
    {
        int Create(SamochodDto dto);
        SamochodDto GetById(int id);
        bool Delete(int id);
        IEnumerable<SamochodDto>  GetAll();
    }
}