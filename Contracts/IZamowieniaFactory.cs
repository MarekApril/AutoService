using System.Collections.Generic;
using AutoServis.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoServis.Contracts
{
    public interface IZamowieniaFactory
    {
        int Create(CreateZamowieniaDto dto);
        ZamowieniaDto GetById(int id);
        bool Delete(int id);
        ZamowieniaDto Update(int id, ZamowieniaDto dto);
        IEnumerable<ZamowieniaDto> GetAll();
    }
}