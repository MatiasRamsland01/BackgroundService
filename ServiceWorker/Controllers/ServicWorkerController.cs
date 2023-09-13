using Microsoft.AspNetCore.Mvc;
using ServiceWorker;
using System.Net;
using System.Reflection;

namespace ServiceWorker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicWorkerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private readonly IQueue _queue;

        private readonly ILogger<ServicWorkerController> _logger;

        public ServicWorkerController(ILogger<ServicWorkerController> logger, IQueue queue)
        {
            _logger = logger;
            _queue = queue;
        }   
        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Post()
        {
            _queue.Enqueue(new MathExpression(2));
            _queue.Enqueue(new MathExpression(6));
            _queue.Enqueue(new MathExpression(1));
            _queue.Enqueue(new MathExpression(131));
            _queue.Enqueue(new MathExpression(45));
            _queue.Enqueue(new MathExpression(234));
            Response.StatusCode = 200;
            return new OkResult();
        }
    }
}
