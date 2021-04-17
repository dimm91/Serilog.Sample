using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serilog.Sample.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult LogMessage([FromBody] Message model)
        {
            _logger.LogInformation($"test1: {model}");
            _logger.LogWarning($"test1: {model}");
            _logger.LogError($"test1: {model}");

            return Ok();
        }

        [HttpPost("MessageFoo")]
        public IActionResult LogMessageFoo([FromBody] MessageFoo model)
        {
            //We add the '@' (destructuring operator) to Preserving Object Structure
            _logger.LogInformation("test1: {@model}", model);
            _logger.LogWarning("test1: {@model}", model);
            _logger.LogError("test1: {@model}", model);

            return Ok();
        }

        #region Models
        public record Message(string Id, string Body);

        public class MessageFoo
        {
            public string Id { get; set; }
            public string Body { get; set; }

        }
        #endregion

    }
}
