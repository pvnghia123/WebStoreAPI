using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreConsoleTest
{
    // [System.AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Property)]
    public class MaxLengthAttribute : ActionFilterAttribute
    {
        private readonly int _maxLength;
        public MaxLengthAttribute(int length)
        {
            _maxLength = length;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Log("OnActionExecuting", filterContext.RouteData);
            //if
            System.Console.Write("chay qua day");
            var a = filterContext.RouteData;
            // System.
        }
    }
}
