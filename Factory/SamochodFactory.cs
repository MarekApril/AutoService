using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoServis.Contracts;
using AutoServis.Entities;
using AutoServis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AutoServis.Factory
{
    public class SamochodFactory : ISamochodFactory
    {
        private AutoServiceDbContext _context;
        private IMapper _mapper;
        private ISendGridEmailFactory _sendGridEmail;

        public SamochodFactory(AutoServiceDbContext context, IMapper mapper, ISendGridEmailFactory sendGridEmail)
        {
            _sendGridEmail = sendGridEmail;
            _mapper = mapper;
            _context = context;
        }

        public int Create(SamochodDto dto)
        {
            var samochod = _mapper.Map<Samochod>(dto);
            var id = GetId(dto.ImieMechanika, dto.NazwiskoMechanika);

            samochod.MechanikId = id;
            _context.Samochody.Add(samochod);
            _context.SaveChanges();

            _sendGridEmail.SendEmailAsync($"{dto.Email}", "Rejestracja naprawy powiodła się",
                $"Dzień dobry <hr/><strong> {dto.ImieKlienta} {dto.NazwiskoKlienta}</strong> Twoje auto będzie naprawione niebawem");

            return samochod.Id;
        }

        public SamochodDto GetById(int id)
        {
            var samochod = _context.Samochody.Include(c => c.Mechanik).FirstOrDefault(c => c.Id == id);
            var samochodDto = _mapper.Map<SamochodDto>(samochod);
            return samochodDto;
        }

        public bool Delete(int id)
        {
            var samochod = _context
                .Samochody
                .FirstOrDefault(r => r.Id == id);

            _context.Remove(samochod);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<SamochodDto> GetAll()
        {
            var samochody = _context
                .Samochody
                .Include(r => r.Mechanik)
                .ToList();

            var mechanikcyDto = _mapper.Map<List<SamochodDto>>(samochody);
            return mechanikcyDto;
        }

        private int GetId(string imie, string nazwisko)
        {
            var mechanik = _context.Mechanicy.FirstOrDefault(c => c.Imie == imie && c.Nazwisko == nazwisko);
            if (mechanik == null)
            {
                mechanik = _context.Mechanicy.FirstOrDefault();
            }
            return mechanik.Id;
        }
    }
}
