using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdopcionMascotas.Attributes
{
    public class AdminAuthRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            // Verifica si el administrador ha iniciado sesión
            if (session.GetString("AdminLoggedIn") != "true")
            {
                context.Result = new RedirectToActionResult("Login", "Auth", new { area = "Admin" });
                return;
            }
            
            base.OnActionExecuting(context);
        }
    }
}