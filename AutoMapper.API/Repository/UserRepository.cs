using AutoMapper.API.Models;

namespace AutoMapper.API.Repository
{
    public class UserRepository : IUserRepository
    {
        public List<User> users = new List<User>()
        {
            new User {Id= new Guid("45408c64-1af9-4ea4-a9e0-f835b13d980b"),FirstName="Md Sarafat Ali",LastName="Adir",Email="adir.ixr@gmail.com",Password="1111",DateOfBirth = Convert.ToDateTime("08/07/1999")}
        };
        public User CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            users.Add(user);
            return user;
        }

        public User GetById(Guid id)
        {
           var getuser = users.Where(u => u.Id == id).FirstOrDefault();
           return getuser;
        }

        public IEnumerable<User> GetUsers()
        {
            var allUsers = users.ToList();
            return allUsers;
        }
    }
}
