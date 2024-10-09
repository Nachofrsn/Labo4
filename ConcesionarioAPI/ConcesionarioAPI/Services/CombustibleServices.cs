using AutoMapper;
using concesionarioAPI.Config;
using concesionarioAPI.Models.Combustible;
using concesionarioAPI.Models.Combustible.Dto;
using concesionarioAPI.Repositories;
using concesionarioAPI.Utils.Exceptions;
using System.Net;

namespace concesionarioAPI.Services
{
    public class CombustibleServices
    {
        private readonly IMapper _mapper;
        private readonly ICombustibleRepository _combustibleRepo;

        public CombustibleServices(IMapper mapper, ICombustibleRepository combustibleRepo)
        {
            _mapper = mapper;
            _combustibleRepo = combustibleRepo;
        }

        public async Task<List<Combustible>> GetAll()
        {
            var combustibles = await _combustibleRepo.GetAll();
            return combustibles.ToList();
        }

        public async Task<Combustible> GetOneById(int id)
        {
            var combustible = await _combustibleRepo.GetOne(c => c.Id == id);
            if (combustible == null)
            { 
                throw new CustomHttpException($"No se encontro el Combustible con Id = {id}", HttpStatusCode.NotFound);
            }
            return combustible;
        }

        public async Task<Combustible> CreateOne(CreateCombustibleDTO createCombustibleDto)
        {
            Combustible combustible = _mapper.Map<Combustible>(createCombustibleDto);

            await _combustibleRepo.Add(combustible);
            return combustible;
        }

        public async Task<Combustible> UpdateOneById(int id, UpdateCombustibleDTO updateAutoDto)
        {
            Combustible combustible = await GetOneById(id);

            var combustibleMapped = _mapper.Map(updateAutoDto, combustible);

            await _combustibleRepo.Update(combustibleMapped);

            return combustibleMapped;
        }

        public async Task DeleteOneById(int id)
        {
            var combustible = await GetOneById(id);

            await _combustibleRepo.Delete(combustible);
        }
    }
}
