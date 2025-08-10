using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Parkease.Middleware
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value ?? "/";

            // Rutas permitidas sin autenticación
            if (path.StartsWith("/Home/Login") || path.StartsWith("/Home/Register") || path.StartsWith("/Home/AccesoDenegado"))
            {
                await _next(context);
                return;
            }

            // Verificar si el usuario tiene sesión activa
            if (string.IsNullOrEmpty(context.Session.GetString("User")))
            {
                context.Response.Redirect("/Home/Login");
                return;
            }

            await _next(context);
        }
    }
}