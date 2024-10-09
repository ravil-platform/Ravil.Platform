using Application.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : GenericBaseController<WeatherForecastController>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(IMediator mediator, Logging.Base.ILogger<WeatherForecastController> logger) 
            : base(mediator, logger)
        {
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            throw new ArgumentNullException();
            //var d = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //    {
            //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //        TemperatureC = Random.Shared.Next(-20, 55),
            //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //    })
            //    .ToArray();

            //var result =
            //    new FluentResults.Result<WeatherForecast[]>();
            //result.WithValue(d);

            //return FluentResult(result);
        }
    }
}
