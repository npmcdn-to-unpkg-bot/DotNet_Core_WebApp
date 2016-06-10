using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Bristrong.Official.WebService.Models;
using System.Security.Cryptography;
using System.Text;
using Bristrong.Official.WebService.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Bristrong.Official.WebService.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private AdminDbContext _adminDbContext;
        public AccountController(AdminDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }

        [HttpPost]
        [Route("SignIn")]
        [AllowAnonymous]
        public async Task SignIn(LoginViewModel model)
        {
            var signInUser = _adminDbContext.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            if (signInUser != null)
            {
                Claim name = new Claim("UserName", model.UserName);
                Claim pwd = new Claim("Password", model.Password);
                List<Claim> claims = new List<Claim> { name, pwd };

                var identity = new ClaimsIdentity(claims, "UserInfo");
                await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }
            else
            {
                throw new Exception("用户名或密码错误！");
            }
        }

        [HttpGet]
        public async Task<IEnumerable<AppUserViewModel>> Get()
        {
            return await Task.FromResult(_adminDbContext.Users.Select(u =>
                new AppUserViewModel
                {
                    Id = u.Id,
                    UserName = u.UserName
                }));
        }

        [HttpPost]
        public async Task AddUser(AppUser user)
        {
            try
            {
                _adminDbContext.Users.Add(user);
                await _adminDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task DeleteUser(int userId)
        {
            var user = _adminDbContext.Users.First(u => u.Id == userId);
            _adminDbContext.Users.Remove(user);
            await _adminDbContext.SaveChangesAsync();
        }

    }
}
