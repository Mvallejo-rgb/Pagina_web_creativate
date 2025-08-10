using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Parkease.Filters
{
    public class AuthorizeSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            if (session.GetInt32("idConductor") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "controller", "Auth" },
                        { "action", "Login" }
                    }
                );
            }
            base.OnActionExecuting(context);
        }
    }
}
