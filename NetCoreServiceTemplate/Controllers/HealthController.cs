using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreServiceTemplate.HeatlhCheck;
using StackExchange.Redis;

namespace NetCoreServiceTemplate.Controllers
{
    [Route("api")]
    public class HealthController : Controller
    {
        // GET api/values
        [HttpGet]
        [Route("index")]
        public JsonResult Get(HealthCheckTypes checkType = HealthCheckTypes.Shallow)
        {
            var man  = new SystemHealthManager();
            var status = man.PerformHealthCheck(checkType);
            return Json(status);
        }
    }
}