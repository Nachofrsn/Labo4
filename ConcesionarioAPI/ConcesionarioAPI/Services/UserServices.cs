using AutoMapper;
using concesionarioAPI.Config;
using concesionarioAPI.Models.Auto.Dto;
using concesionarioAPI.Models.Auto;
using concesionarioAPI.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Net;
using concesionarioAPI.Models.User;
using concesionarioAPI.Models.User.Dto;

namespace concesionarioAPI.Services
{
    public class UserServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IEncoderServices _encoderServices;

        public UserServices(ApplicationDbContext db, IMapper mapper, IEncoderServices encoderServices)
        {
            _db = db;
            _mapper = mapper;
            _encoderServices = encoderServices;
        }
        private User GetOneByIdOrException(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new CustomHttpException($"No se encontro el auto con Id = {id}", HttpStatusCode.NotFound);
            }
            return user;
        }

        public List<UsersDTO> GetAll()
        {
            var users = _db.Users.Select(u => u).ToList();
            return _mapper.Map<List<UsersDTO>>(users);
        }

        public UserDTO GetOneById(int id)
        {
            var user = GetOneByIdOrException(id);
            return _mapper.Map<UserDTO>(user);
        }

        public User CreateOne(CreateUserDTO createUserDTO)
        {
            User user = _mapper.Map<User>(createUserDTO);

            user.Password = _encoderServices.Encode(user.Password);

            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public User UpdateOneById(int id, UpdateUserDTO updateUserDto)
        {
            User user = GetOneByIdOrException(id);

            var userMapped = _mapper.Map(updateUserDto, user);

            _db.Users.Update(userMapped);
            _db.SaveChanges();

            return userMapped;
        }

        public void DeleteOneById(int id)
        {
            var user = GetOneByIdOrException(id);

            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
