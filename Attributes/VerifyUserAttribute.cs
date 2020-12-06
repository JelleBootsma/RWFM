using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class VerifyUserAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var user = filterContext.HttpContext.Session.GetString("username");
        if (user == null){
            filterContext.Result = new RedirectToRouteResult(new {
                controller = "Login",
                action = "Index" });    
        }
    }
}