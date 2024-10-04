using AutoMapper;
using concesionarioAPI.Config;
using concesionarioAPI.Models.Auto;
using concesionarioAPI.Models.Auto.Dto;
using concesionarioAPI.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace concesionarioAPI.Services
{
    public class AutoServices
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly CombustibleServices _combustibleServices;

        public AutoServices(IMapper mapper, ApplicationDbContext db, CombustibleServices combustibleServices)
        {
            _mapper = mapper;
            _db = db;
            _combustibleServices = combustibleServices;
        }

        private Auto GetOneByIdOrException(int id)
        {
            // Icluimos la entidad Combustible para que la traiga con la consulta.
            var auto = _db.Autos.Include(a => a.Combustible).FirstOrDefault(a => a.Id == id);
            if (auto == null)
            {
                throw new CustomHttpException($"No se encontro el auto con Id = {id}", HttpStatusCode.NotFound);
            }
            return auto;
        }

        public List<AutosDTO> GetAll()
        {
            var autos = _db.Autos.Select(a => a).ToList();
            return _mapper.Map<List<AutosDTO>>(autos);
        }

        public AutoDTO GetOneById(int id)
        {
            var auto = GetOneByIdOrException(id);
            //var combustible = _combustibleServices.GetOneById(auto.CombustibleId);
            //auto.Combustible = combustible;
            return _mapper.Map<AutoDTO>(auto);
        }

        public Auto CreateOne(CreateAutoDTO createAutoDto)
        {
            Auto auto = _mapper.Map<Auto>(createAutoDto);

            // Es importante llamar a este método para que verifique que existe el combustible
            _combustibleServices.GetOneById(auto.CombustibleId);
       
            _db.Autos.Add(auto);
            _db.SaveChanges();
            return auto;
        }

        public Auto UpdateOneById(int id, UpdateAutoDTO updateAutoDto)
        {
            Auto auto = GetOneByIdOrException(id);

            var autoMapped = _mapper.Map(updateAutoDto, auto);

            _combustibleServices.GetOneById(autoMapped.CombustibleId);

            _db.Autos.Update(autoMapped);
            _db.SaveChanges();

            return autoMapped;
        }

        public void DeleteOneById(int id)
        {
            var auto = GetOneByIdOrException(id);

            _db.Autos.Remove(auto);
            _db.SaveChanges();
        }
    }
}
