using AutoMapper.API.Dtos;
using AutoMapper.API.Models;
using AutoMapper.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

        [HttpPost]

        public IActionResult CreateUser(UserCreateDto user)
        {
            //_userRepository.CreateUser(user);
           var newUser= _mapper.Map<User>(user);
           var createdUser= _userRepository.CreateUser(newUser);

            var userReadDto = _mapper.Map<UserDto>(createdUser);


            return Ok(userReadDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userRepository.GetUsers();
            var userReadDto = _mapper.Map<List<UserDto>>(users);
            return Ok(userReadDto);
        }

        [HttpGet("id")]

        public IActionResult Get(Guid id)
        {
            var user = _userRepository.GetById(id);
            //var readUser = new UserDto()
            //{
            //    FullName = $"{user.FirstName} {user.LastName}",
            //    Email = user.Email,
            //    Age = HelperFunctions.HelperFunctions.GetCurrentAge(user.DateOfBirth),
                
            //};

            var readUser = _mapper.Map<UserDto>(user); // destination to source
            return Ok(readUser);
        }
    }
}
