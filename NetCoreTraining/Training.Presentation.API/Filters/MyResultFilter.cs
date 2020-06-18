using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Training.Presentation.API.Filters
{
    public class MyResultFilter : Attribute, IResultFilter
    {
        private readonly ILogger _logger;

        public MyResultFilter(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<MyResultFilter>();
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($"MyResultFilter OnResultExecuted Controller {context.Controller.GetType().Name} Action {context.ActionDescriptor.DisplayName} Method {context.HttpContext.Request.Method}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($"MyResultFilter OnResultExecuting Controller {context.Controller.GetType().Name} Action {context.ActionDescriptor.DisplayName} Method {context.HttpContext.Request.Method}");
            context.HttpContext.Response.Headers.Add("MyResultFilter", Guid.NewGuid().ToString());
        }
    }
}
