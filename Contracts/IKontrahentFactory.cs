using System.Collections.Generic;
using AutoServis.Models;

namespace AutoServis.Contracts
{
    public interface IKontrahentFactory
    {
        int Create(CreateKontrahentDto dto);
        KontrahentDto GetById(int id);
        public IEnumerable<KontrahentDto> GetAll();
        bool Delete(int id);
        UpdateKontrahentDto Update(int id, UpdateKontrahentDto dto);
    }
}