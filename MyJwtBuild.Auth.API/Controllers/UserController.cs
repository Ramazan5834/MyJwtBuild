using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyJwtBuild.BUSINESS.Interfaces;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DTO.UserDtos;

namespace MyJwtBuild.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UserRegisterToSystem(UserRegisterDto userRegisterDto)
        {
            User user = _mapper.Map<User>(userRegisterDto);
            await _userService.RegisterUserToSystemAsync(user);
            return Ok();
        }
    }
}
