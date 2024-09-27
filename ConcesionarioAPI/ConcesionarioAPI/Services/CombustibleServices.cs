using AutoMapper;
using concesionarioAPI.Config;
using concesionarioAPI.Models.Combustible;
using concesionarioAPI.Models.Combustible.Dto;
using concesionarioAPI.Utils.Exceptions;
using System.Net;

namespace concesionarioAPI.Services
{
    public class CombustibleServices
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public CombustibleServices(IMapper mapper, ApplicationDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public List<Combustible> GetAll()
        {
            return _db.Combustibles.Select(c => c).ToList();
        }

        public Combustible GetOneById(int id)
        {
            var combustible = GetAll().FirstOrDefault(c => c.Id == id);
            if (combustible == null)
            { 
                throw new CustomHttpException($"No se encontro el Combustible con Id = {id}", HttpStatusCode.NotFound);
            }
            return combustible;
        }

        public Combustible CreateOne(CreateCombustibleDTO createCombustibleDto)
        {
            Combustible combustible = _mapper.Map<Combustible>(createCombustibleDto);

            _db.Combustibles.Add(combustible);
            _db.SaveChanges();
            return combustible;
        }

        public Combustible UpdateOneById(int id, UpdateCombustibleDTO updateAutoDto)
        {
            Combustible combustible = GetOneById(id);

            var combustibleMapped = _mapper.Map(updateAutoDto, combustible);

            _db.Combustibles.Update(combustibleMapped);
            _db.SaveChanges();

            return combustibleMapped;
        }

        public void DeleteOneById(int id)
        {
            var combustible = GetOneById(id);

            _db.Combustibles.Remove(combustible);
            _db.SaveChanges();
        }
    }
}
