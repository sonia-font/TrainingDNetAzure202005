using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Training.Presentation.API.Filters;

namespace Training.Presentation.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger) => this._logger = logger;


        // GET api/values
        /// <summary>
        /// Retrieves values.
        /// </summary>
        [HttpGet]
        [MyAuthorizationFilter]
        [ServiceFilter(typeof(MyActionFilter))]
        [ServiceFilter(typeof(MyResultFilter))]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation($"This is a test Log");
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Retrieves a specific value.
        /// </summary>
        // GET api/values/5
        [HttpGet("{id}")]
        [ServiceFilter(typeof(MyActionFilter))]
        [ServiceFilter(typeof(MyResultFilter))]
        [MyAuthorizationFilter]
        public ActionResult<string> Get(int id)
        {
            return "value is " + id.ToString();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
