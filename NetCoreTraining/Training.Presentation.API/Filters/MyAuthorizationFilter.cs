using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Training.Application.Services;

namespace Training.Presentation.API.Filters
{
    public class MyAuthorizationFilter : Attribute, IAuthorizationFilter
    {


        public MyAuthorizationFilter()
        {
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Get SessionService from IOC Explicit
            var service = context.HttpContext.RequestServices.GetService<ISessionService>();
            //Get LoggerFactory from IOC Explicit
            var loggerFactory = context.HttpContext.RequestServices.GetService<ILoggerFactory>();

            var logger = loggerFactory.CreateLogger<MyAuthorizationFilter>();
            logger.LogInformation($"MyAuthorizationFilter Calling SessionService");
            if (!service.UserLoggedIn())
            {
                context.Result = new UnauthorizedResult();
                logger.LogInformation($"MyAuthorizationFilter User not Loggedin");
            }
            else
                logger.LogInformation($"MyAuthorizationFilter User Loggedin");

            logger.LogInformation($"MyAuthorizationFilter End Authorization Filter");
        }
    }
}
