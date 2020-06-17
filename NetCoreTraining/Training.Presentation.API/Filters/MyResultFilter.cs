using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Training.Presentation.API.Filters
{
    public class MyResultFilter : Attribute, IResultFilter
    {
        private ILogger _logger;

        public MyResultFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MyResultFilter>();
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($"MyResultFilter OnResultExecuted Controller {context.Controller.GetType().Name} Action {context.ActionDescriptor.DisplayName} Method {context.HttpContext.Request.Method}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($"MyResultFilter OnResultExecuting Controller {context.Controller.GetType().Name} Action {context.ActionDescriptor.DisplayName} Method {context.HttpContext.Request.Method}");
        }
    }
}
