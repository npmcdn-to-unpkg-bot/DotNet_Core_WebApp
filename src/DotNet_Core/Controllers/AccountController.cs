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

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Bristrong.Official.WebService.Controllers
{
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
        public async Task SignIn(SignInModel signInModel)
        {
            var signInUser = _adminDbContext.UserSet.FirstOrDefault(u => u.UserName == signInModel.UserName && u.Password == signInModel.Password);
            if (signInUser != null)
            {
                Claim name = new Claim("UserName", signInModel.UserName);
                Claim pwd = new Claim("Password", signInModel.Password);
                List<Claim> claims = new List<Claim> { name, pwd };

                var identity = new ClaimsIdentity(claims, "UserInfo");
                await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }
            else
            {
                throw new Exception("用户名或密码错误！");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task AddUser(User user)
        {
            try
            {
                _adminDbContext.UserSet.Add(user);
                await _adminDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task DeleteUser(int userId)
        {
            var user = _adminDbContext.UserSet.First(u => u.Id == userId);
            _adminDbContext.UserSet.Remove(user);
            await _adminDbContext.SaveChangesAsync();
        }

    }

    public class SignInModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
