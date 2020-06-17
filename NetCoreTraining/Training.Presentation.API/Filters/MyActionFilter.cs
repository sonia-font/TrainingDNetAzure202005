using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Training.Presentation.API.Filters
{
    public class MyActionFilter : Attribute, IActionFilter
    {
        private ILogger _logger;

        public MyActionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MyActionFilter>();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"MyActionFilter OnActionExecuted Controller {context.Controller.GetType().Name} Action {context.ActionDescriptor.DisplayName} Method {context.HttpContext.Request.Method}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"MyActionFilter OnActionExecuting Controller {context.Controller.GetType().Name} Action {context.ActionDescriptor.DisplayName} Method {context.HttpContext.Request.Method}");
        }
    }
}
