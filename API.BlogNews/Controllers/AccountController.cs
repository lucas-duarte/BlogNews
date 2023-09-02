using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.BlogNews.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Create(Models.Register model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Models.Login model)
        {

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest("Login Invalido");
        }

        [HttpGet("ListUsers")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(userManager.Users.Select(u => u.UserName));
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("Logout Realizado!!!");
        }


    }
}
