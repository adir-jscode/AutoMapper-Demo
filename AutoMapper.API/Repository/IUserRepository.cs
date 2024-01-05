using AutoMapper.API.Dtos;
using AutoMapper.API.Models;

namespace AutoMapper.API.Repository
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        IEnumerable<User> GetUsers();

        User GetById(Guid id);
    }
}
