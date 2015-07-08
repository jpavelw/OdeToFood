using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        // exceutes before it goes into the action
        // I can use this to save the time when the action
        // started to excecute
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // I can get information about the call using filterContext
            base.OnActionExecuting(filterContext);
        }

        // excecutes right after the action is called
        // I can use this to save the time when the action
        // finished excecuting
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // I can get information about the result of the action using filterContext (errors)
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}