using Microsoft.AspNetCore.Mvc;
using MyJwtBuild.DTO.UserDtos;
using MyJwtBuild.Web.UI.ApiServices.AuthApi.Interfaces;

namespace MyJwtBuild.Web.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiService _userApiService;
        public UserController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            await _userApiService.UserRegisterToSystemAsync(userRegisterDto);
            return RedirectToAction("Index","Home");
        }


    }
}
