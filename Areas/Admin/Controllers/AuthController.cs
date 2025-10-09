using Microsoft.AspNetCore.Mvc;

namespace AdopcionMascotas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("AdminLoggedIn") == "true")
            {
                return RedirectToAction("Index", "Mascotas");
            }
            
            return View();
        }

        //Login con metodo POST
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Trae las credenciales desde el .env
            var adminUsername = Environment.GetEnvironmentVariable("ADMIN_USERNAME");
            var adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");


            if (username == adminUsername && password == adminPassword)
            {
                HttpContext.Session.SetString("AdminLoggedIn", "true");
                HttpContext.Session.SetString("AdminUsername", username);

                return RedirectToAction("Index", "Mascotas");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        //Logout con metodo GET
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("AdminLoggedIn");
            HttpContext.Session.Remove("AdminUsername");
            
            
            return RedirectToAction("Login");
        }
    }
}