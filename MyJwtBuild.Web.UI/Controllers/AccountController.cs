using Microsoft.AspNetCore.Mvc;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.Web.UI.ApiServices.AuthApi.Interfaces;
using MyJwtBuild.Web.UI.ApiServices.DataApi.Interfaces;

namespace MyJwtBuild.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthApiService _authApiService;
        public AccountController(IAuthApiService authApiService)
        {
           _authApiService = authApiService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            user.SurName = "";
            user.Name = "";
            user.Email = "";
            user.Id = 0;
            user.RoleId = 0;
            bool result = await _authApiService.LoginFromUsSystemAsync(user);
            if (result)
            {
                return RedirectToAction("YouLogin", "Home");
            }
            return RedirectToAction("YouNotLogin", "Home");

        }
    }
}
