using AutoMapper;
using concesionarioAPI.Config;
using concesionarioAPI.Models.Auto;
using concesionarioAPI.Models.Auto.Dto;
using concesionarioAPI.Repositories;
using concesionarioAPI.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace concesionarioAPI.Services
{
    public class AutoServices
    {
        private readonly IMapper _mapper;
        private readonly IAutoRepository _autoRepo;
        private readonly CombustibleServices _combustibleServices;

        public AutoServices(IMapper mapper, IAutoRepository autoRepo, CombustibleServices combustibleServices)
        {
            _mapper = mapper;
            _autoRepo = autoRepo;
            _combustibleServices = combustibleServices;
        }

        private async Task<Auto> GetOneByIdOrException(int id)
        {
            // Icluimos la entidad Combustible para que la traiga con la consulta.
            // ?
            var auto = await _autoRepo.GetOne(a => a.Id == id);
            if (auto == null)
            {
                throw new CustomHttpException($"No se encontro el auto con Id = {id}", HttpStatusCode.NotFound);
            }
            return auto;
        }

        public async Task<List<AutosDTO>> GetAll()
        {
            var autos = await _autoRepo.GetAll();
            return _mapper.Map<List<AutosDTO>>(autos);
        }

        public async Task<AutoDTO> GetOneById(int id)
        {
            var auto = await GetOneByIdOrException(id);
            //var combustible = _combustibleServices.GetOneById(auto.CombustibleId);
            //auto.Combustible = combustible;
            return _mapper.Map<AutoDTO>(auto);
        }

        public async Task<Auto> CreateOne(CreateAutoDTO createAutoDto)
        {
            Auto auto = _mapper.Map<Auto>(createAutoDto);

            // Es importante llamar a este método para que verifique que existe el combustible
            await _combustibleServices.GetOneById(auto.CombustibleId);
       
            await _autoRepo.Add(auto);
            return auto;
        }

        public async Task<Auto> UpdateOneById(int id, UpdateAutoDTO updateAutoDto)
        {
            Auto auto = await GetOneByIdOrException(id);

            var autoMapped = _mapper.Map(updateAutoDto, auto);

            await _combustibleServices.GetOneById(autoMapped.CombustibleId);

            await _autoRepo.Update(autoMapped);

            return autoMapped;
        }

        public async Task DeleteOneById(int id)
        {
            var auto = await GetOneByIdOrException(id);

            await _autoRepo.Delete(auto);
        }
    }
}
