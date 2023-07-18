using Microsoft.AspNetCore.Mvc.Filters;

namespace WebStoreAPI.Authorization
{
    public class MaxLengthFilter : ActionFilterAttribute
    {
        private readonly int _maxLength;
        public MaxLengthFilter(int length)
        {
            _maxLength = length;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Log("OnActionExecuting", filterContext.RouteData);
            //if
            // System.Console.Write("")
            var a = filterContext.RouteData;
           // System.
        }

    }
}
