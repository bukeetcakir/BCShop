using BCShop.Data.Concrete;
using BCShop.Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BCShop.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(User u)
        {
            if (u.Email == "admin@admin.com" && u.Password == "admin")
            {
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, u.Email),
					new Claim(ClaimTypes.Role, "Admin")
				};

				var identity = new ClaimsIdentity(claims, "MyCookieAuthenticationScheme");
				var principal = new ClaimsPrincipal(identity);

				var authenticationProperties = new AuthenticationProperties
				{
					IsPersistent = true
				};

				HttpContext.SignInAsync("MyCookieAuthenticationScheme", principal, authenticationProperties).Wait();

				return RedirectToAction("Index", "Admin");
            }
            else
            {
                Context c = new Context();
                var data = c.Users.FirstOrDefault(x => x.Email == u.Email && x.Password == u.Password);
                if (data != null)
                {

                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, u.Email)
                    };
                    var useridentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    return View();
                }
            }
        }
        

    }
}
